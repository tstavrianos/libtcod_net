using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindingsPostProcessor;

public class ManagedStringWrapperGenerator
{
    public ProcessResult Process(string content)
    {
        try
        {
            var tree = CSharpSyntaxTree.ParseText(content);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            var wrappers = new List<MethodWrapperInfo>();

            foreach (var method in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
            {
                // Check if this is a [DllImport] method
                if (
                    !method.AttributeLists.Any(al =>
                        al.Attributes.Any(a =>
                            a.Name is IdentifierNameSyntax id && id.Identifier.Text == "DllImport"
                        )
                    )
                )
                    continue;

                // Check if it's public static extern
                var modifiers = method.Modifiers;
                if (
                    !modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword))
                    || !modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword))
                    || !modifiers.Any(m => m.IsKind(SyntaxKind.ExternKeyword))
                )
                    continue;

                // Check if it has sbyte* parameters
                var sbyteParams = method
                    .ParameterList.Parameters.Where(p =>
                        p.Type?.ToString().Contains("sbyte*") ?? false
                    )
                    .ToList();

                if (sbyteParams.Count == 0)
                    continue;

                // Skip varargs signatures (__arglist) - cannot be forwarded from managed wrappers.
                if (
                    method.ParameterList.Parameters.Any(p =>
                        p.ToString().Contains("__arglist", StringComparison.Ordinal)
                    )
                )
                    continue;

                // Check if this is the type of function we want to wrap
                if (!ShouldGenerateWrapper(method.Identifier.Text))
                    continue;

                var wrapper = GenerateWrapper(method);
                if (wrapper != null)
                    wrappers.Add(wrapper);
            }

            if (wrappers.Count == 0)
                return new ProcessResult { GeneratedWrappers = 0, TransformedContent = content };

            var transformedContent = InsertWrappers(content, wrappers);
            return new ProcessResult
            {
                GeneratedWrappers = wrappers.Count,
                TransformedContent = transformedContent,
            };
        }
        catch (Exception)
        {
            // On parse errors, return unchanged content
            return new ProcessResult { GeneratedWrappers = 0, TransformedContent = content };
        }
    }

    private MethodWrapperInfo? GenerateWrapper(MethodDeclarationSyntax method)
    {
        // Extract indent from the method's leading trivia
        var indent = "        "; // Default 8 spaces
        if (method.GetLeadingTrivia().Any())
        {
            var lastTrivia = method.GetLeadingTrivia().LastOrDefault();
            if (lastTrivia.IsKind(SyntaxKind.WhitespaceTrivia))
                indent = lastTrivia.ToString();
        }

        var isUnsafe = method.Modifiers.Any(m => m.IsKind(SyntaxKind.UnsafeKeyword));
        var returnType = method.ReturnType.ToString();
        var functionName = method.Identifier.Text;
        var parameters = method.ParameterList.Parameters;

        // Separate string parameters (sbyte*) from other parameters
        var stringParams = parameters
            .Where(p => p.Type?.ToString().Contains("sbyte*") ?? false)
            .ToList();
        var otherParams = parameters
            .Where(p => !(p.Type?.ToString().Contains("sbyte*") ?? false))
            .ToList();

        if (stringParams.Count == 0)
            return null;

        var wrapperBuilder = new StringBuilder();
        wrapperBuilder.AppendLine();
        wrapperBuilder.AppendLine($"{indent}// Managed wrapper for {functionName}");
        wrapperBuilder.Append($"{indent}public static ");
        if (isUnsafe)
            wrapperBuilder.Append("unsafe ");
        wrapperBuilder.AppendLine($"{returnType} {functionName}(");

        // Build managed parameter list in original order.
        var managedParams = new List<string>();
        foreach (var param in parameters)
        {
            var paramName = param.Identifier.Text;
            if (param.Type?.ToString().Contains("sbyte*") ?? false)
                managedParams.Add($"{indent}    string {paramName}");
            else
                managedParams.Add($"{indent}    {param}");
        }

        wrapperBuilder.AppendLine(string.Join($",{Environment.NewLine}", managedParams));
        wrapperBuilder.AppendLine($"{indent})");
        wrapperBuilder.AppendLine($"{indent}{{");

        // Build method body - marshal strings
        foreach (var param in stringParams)
        {
            var paramName = param.Identifier.Text;
            wrapperBuilder.AppendLine(
                $"{indent}    var {paramName}Ptr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8({paramName});"
            );
        }

        wrapperBuilder.AppendLine($"{indent}    try");
        wrapperBuilder.AppendLine($"{indent}    {{");

        // Call the native function with parameters in their original order
        bool isVoidReturn = returnType == "void";
        if (isVoidReturn)
        {
            wrapperBuilder.Append($"{indent}        {functionName}(");
        }
        else
        {
            wrapperBuilder.Append($"{indent}        return {functionName}(");
        }

        var callParams = new List<string>();
        // Reconstruct original parameter order
        foreach (var param in parameters)
        {
            var paramName = param.Identifier.Text;
            if (param.Type?.ToString().Contains("sbyte*") ?? false)
                callParams.Add($"(sbyte*){paramName}Ptr.ToPointer()");
            else
                callParams.Add(paramName);
        }

        wrapperBuilder.AppendLine(string.Join(", ", callParams) + ");");
        wrapperBuilder.AppendLine($"{indent}    }}");
        wrapperBuilder.AppendLine($"{indent}    finally");
        wrapperBuilder.AppendLine($"{indent}    {{");

        foreach (var param in stringParams)
        {
            var paramName = param.Identifier.Text;
            wrapperBuilder.AppendLine(
                $"{indent}        System.Runtime.InteropServices.Marshal.FreeCoTaskMem({paramName}Ptr);"
            );
        }

        wrapperBuilder.AppendLine($"{indent}    }}");
        wrapperBuilder.AppendLine($"{indent}}}");

        return new MethodWrapperInfo
        {
            MethodNode = method,
            WrapperCode = wrapperBuilder.ToString(),
        };
    }

    private string InsertWrappers(string content, List<MethodWrapperInfo> wrappers)
    {
        // Sort by end position descending to maintain correct indices when inserting
        var sortedWrappers = wrappers.OrderByDescending(w => w.MethodNode.Span.End).ToList();

        // Build new content with wrappers inserted
        var insertions = new SortedDictionary<int, string>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        foreach (var wrapper in sortedWrappers)
        {
            var methodEnd = wrapper.MethodNode.Span.End;
            insertions[methodEnd] = wrapper.WrapperCode;
        }

        var result = new StringBuilder(content);
        foreach (var (pos, wrapperCode) in insertions)
        {
            result.Insert(pos, wrapperCode);
        }

        return result.ToString();
    }

    private bool ShouldGenerateWrapper(string functionName)
    {
        // Common patterns for functions that should have string wrappers
        var patterns = new[]
        {
            "load",
            "save",
            "open",
            "create",
            "font",
            "bdf",
            "xp",
            "print",
            "put",
            "draw",
            "render",
        };

        return patterns.Any(p => functionName.ToLower().Contains(p));
    }

    public class ProcessResult
    {
        public int GeneratedWrappers { get; set; }
        public required string TransformedContent { get; set; }
    }

    private class MethodWrapperInfo
    {
        public required MethodDeclarationSyntax MethodNode { get; set; }
        public required string WrapperCode { get; set; }
    }
}
