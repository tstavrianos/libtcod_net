using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFITests;

internal sealed class BindingGenerator
{
    private readonly IReadOnlyList<FFIEntry> _entries;
    private readonly Dictionary<string, FFIEntry> _entriesByName;
    private readonly Dictionary<(string Tag, int Id), FFIEntry> _entriesByTagAndId;
    private readonly Dictionary<int, string> _namedStructById;
    private readonly Dictionary<int, string> _namedUnionById;
    private readonly Dictionary<int, string> _namedEnumById;
    private readonly HashSet<string> _neededStructs = new(StringComparer.Ordinal);
    private readonly HashSet<string> _neededUnions = new(StringComparer.Ordinal);
    private readonly HashSet<string> _neededEnums = new(StringComparer.Ordinal);
    private readonly HashSet<string> _neededDelegates = new(StringComparer.Ordinal);
    private readonly HashSet<string> _neededTypedefAliases = new(StringComparer.Ordinal);
    private readonly HashSet<string> _opaqueTypes = new(StringComparer.Ordinal);
    private readonly HashSet<string> _voidPtrTypes;

    public BindingGenerator(IReadOnlyList<FFIEntry> entries)
    {
        _entries = entries;
        _entriesByName = _entries
            .Where(e => !string.IsNullOrWhiteSpace(e.Name))
            .GroupBy(e => e.Name!, StringComparer.Ordinal)
            .ToDictionary(
                g => g.Key,
                g => g.OrderByDescending(e => e.Fields?.Length ?? 0).First(),
                StringComparer.Ordinal
            );

        _entriesByTagAndId = _entries
            .Where(e => !string.IsNullOrWhiteSpace(e.Tag) && e.Id.HasValue)
            .GroupBy(e => (e.Tag!, e.Id!.Value))
            .ToDictionary(g => g.Key, g => g.OrderByDescending(e => e.Fields?.Length ?? 0).First());

        _namedStructById = BuildNamedIdMap(":struct");
        _namedUnionById = BuildNamedIdMap(":union");
        _namedEnumById = BuildNamedIdMap(":enum");

        _voidPtrTypes = new HashSet<string>(
            Program.TypeReplacements.Select(t => t.TrimEnd('*').Trim()).Where(t => t.Length > 0),
            StringComparer.Ordinal
        );
    }

    public string Generate()
    {
        var functions = _entries
            .Where(e =>
                e.Tag == "function" && e.Name?.StartsWith("TCOD_", StringComparison.Ordinal) == true
            )
            .Where(e => !e.Variadic)
            .OrderBy(e => e.Name, StringComparer.Ordinal)
            .ToArray();

        var functionBodies = new List<string>(functions.Length * 2);
        foreach (var function in functions)
        {
            functionBodies.AddRange(BuildFunctionSignatures(function));
            TrackRequiredTypes(function.ReturnType?.Type, function.ReturnType?.Tag);
            if (function.Parameters is null)
                continue;

            foreach (var parameter in function.Parameters)
                TrackRequiredTypes(parameter.Type);
        }

        ExpandTypeDependencies();

        var sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine("namespace libtcod_net.Generated");
        sb.AppendLine("{");

        AppendOpaqueTypes(sb);
        AppendEnums(sb);
        AppendDelegates(sb);
        AppendUnions(sb);
        AppendStructs(sb);

        sb.AppendLine("    public static unsafe partial class LibTcodNative");
        sb.AppendLine("    {");
        foreach (var signature in functionBodies)
        {
            sb.AppendLine(
                "        [DllImport(\"libtcod\", CallingConvention = CallingConvention.Cdecl)]"
            );
            sb.Append("        public static extern ");
            sb.AppendLine(signature);
            sb.AppendLine();
        }
        sb.AppendLine("    }");
        sb.AppendLine("}");
        return sb.ToString();
    }

    private void ExpandTypeDependencies()
    {
        while (true)
        {
            var beforeStructs = _neededStructs.Count;
            var beforeUnions = _neededUnions.Count;
            var beforeEnums = _neededEnums.Count;
            var beforeDelegates = _neededDelegates.Count;
            var beforeOpaque = _opaqueTypes.Count;

            foreach (var structName in _neededStructs.ToArray())
            {
                var entry = ResolveCompositeEntry("struct", structName);
                if (entry?.Fields is null)
                    continue;

                foreach (var field in entry.Fields)
                    TrackRequiredTypes(field.Type);
            }

            foreach (var unionName in _neededUnions.ToArray())
            {
                var entry = ResolveCompositeEntry("union", unionName);
                if (entry?.Fields is null)
                    continue;

                foreach (var field in entry.Fields)
                    TrackRequiredTypes(field.Type);
            }

            foreach (var delegateName in _neededDelegates.ToArray())
            {
                if (
                    !DelegateDeclarations.Declarations.TryGetValue(
                        delegateName,
                        out var declaration
                    )
                )
                    continue;

                TrackProcessedType(declaration.ReturnType);
                foreach (var parameter in declaration.Parameters)
                    TrackProcessedType(parameter.Type);
            }

            if (
                beforeStructs == _neededStructs.Count
                && beforeUnions == _neededUnions.Count
                && beforeEnums == _neededEnums.Count
                && beforeDelegates == _neededDelegates.Count
                && beforeOpaque == _opaqueTypes.Count
            )
            {
                break;
            }
        }
    }

    private void AppendDelegates(StringBuilder sb)
    {
        foreach (var delegateName in _neededDelegates.OrderBy(x => x, StringComparer.Ordinal))
        {
            if (!DelegateDeclarations.Declarations.TryGetValue(delegateName, out var declaration))
                continue;

            sb.AppendLine("    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
            sb.Append("    public unsafe delegate ");
            sb.Append(declaration.ReturnType);
            sb.Append(' ');
            sb.Append(SanitizeTypeName(declaration.Name));
            sb.Append('(');

            for (var i = 0; i < declaration.Parameters.Length; i++)
            {
                if (i > 0)
                    sb.Append(", ");

                var parameter = declaration.Parameters[i];
                sb.Append(parameter.Type);
                sb.Append(' ');
                sb.Append(SanitizeIdentifier(parameter.Name, "arg" + i));
            }

            sb.AppendLine(");");
            sb.AppendLine();
        }
    }

    private void AppendOpaqueTypes(StringBuilder sb)
    {
        foreach (var typeName in _opaqueTypes.OrderBy(x => x, StringComparer.Ordinal))
        {
            if (
                _neededStructs.Contains(typeName)
                || _neededUnions.Contains(typeName)
                || _neededEnums.Contains(typeName)
            )
                continue;

            sb.AppendLine("    [StructLayout(LayoutKind.Sequential)]");
            sb.AppendLine("    public unsafe struct " + typeName);
            sb.AppendLine("    {");
            sb.AppendLine("        public byte _opaque;");
            sb.AppendLine("    }");
            sb.AppendLine();
        }
    }

    private void AppendEnums(StringBuilder sb)
    {
        foreach (var enumName in _neededEnums.OrderBy(x => x, StringComparer.Ordinal))
        {
            var enumEntry = ResolveEnumEntryByName(enumName);
            if (enumEntry?.Fields is null || enumEntry.Fields.Length == 0)
                continue;

            sb.AppendLine("    public enum " + enumName + " : int");
            sb.AppendLine("    {");
            for (var i = 0; i < enumEntry.Fields.Length; i++)
            {
                var field = enumEntry.Fields[i];
                var fieldName = SanitizeIdentifier(field.Name, "Value" + i);
                var fieldValue = field.Value ?? i;
                sb.Append("        ");
                sb.Append(fieldName);
                sb.Append(" = ");
                sb.Append(FormatEnumValue(fieldValue));
                sb.AppendLine(",");
            }
            sb.AppendLine("    }");
            sb.AppendLine();
        }
    }

    private void AppendUnions(StringBuilder sb)
    {
        foreach (var unionName in _neededUnions.OrderBy(x => x, StringComparer.Ordinal))
        {
            var unionEntry = ResolveCompositeEntry("union", unionName);
            var nestedInlineArrays = new List<string>();

            sb.AppendLine("    [StructLayout(LayoutKind.Explicit)]");
            sb.AppendLine("    public unsafe struct " + unionName);
            sb.AppendLine("    {");
            if (unionEntry?.Fields is null || unionEntry.Fields.Length == 0)
            {
                sb.AppendLine("        [FieldOffset(0)]");
                sb.AppendLine("        public byte _opaque;");
            }
            else
            {
                for (var i = 0; i < unionEntry.Fields.Length; i++)
                {
                    var field = unionEntry.Fields[i];
                    var fieldName = SanitizeIdentifier(field.Name, "Field" + i);
                    var fieldType = GetFieldDeclarationType(field, i, nestedInlineArrays);
                    sb.AppendLine("        [FieldOffset(0)]");
                    sb.Append("        public ");
                    sb.Append(fieldType);
                    sb.Append(' ');
                    sb.Append(fieldName);
                    sb.AppendLine(";");
                }

                foreach (var nestedInlineArray in nestedInlineArrays)
                    sb.Append(nestedInlineArray);
            }
            sb.AppendLine("    }");
            sb.AppendLine();
        }
    }

    private void AppendStructs(StringBuilder sb)
    {
        foreach (var structName in _neededStructs.OrderBy(x => x, StringComparer.Ordinal))
        {
            var structEntry = ResolveCompositeEntry("struct", structName);
            var nestedInlineArrays = new List<string>();

            sb.AppendLine("    [StructLayout(LayoutKind.Sequential)]");
            sb.AppendLine("    public unsafe struct " + structName);
            sb.AppendLine("    {");
            if (structEntry?.Fields is null || structEntry.Fields.Length == 0)
            {
                sb.AppendLine("        public byte _opaque;");
            }
            else
            {
                for (var i = 0; i < structEntry.Fields.Length; i++)
                {
                    var field = structEntry.Fields[i];
                    var fieldName = SanitizeIdentifier(field.Name, "Field" + i);
                    var fieldType = GetFieldDeclarationType(field, i, nestedInlineArrays);
                    sb.Append("        public ");
                    sb.Append(fieldType);
                    sb.Append(' ');
                    sb.Append(fieldName);
                    sb.AppendLine(";");
                }

                foreach (var nestedInlineArray in nestedInlineArrays)
                    sb.Append(nestedInlineArray);
            }
            sb.AppendLine("    }");
            sb.AppendLine();
        }
    }

    private string GetFieldDeclarationType(
        FFIField field,
        int index,
        List<string> nestedInlineArrays
    )
    {
        if (
            field.Type?.Tag is not ":array"
            || !field.Type.Size.HasValue
            || field.Type.Size.Value <= 0
        )
            return MapFieldType(field.Type);

        var helperName = BuildInlineArrayHelperName(field, index);
        nestedInlineArrays.Add(BuildInlineArrayHelperDeclaration(helperName, field.Type));
        return helperName;
    }

    private string BuildInlineArrayHelperName(FFIField field, int index)
    {
        return "_" + SanitizeTypeName(field.Name ?? "Field" + index) + "_e__FixedBuffer";
    }

    private string BuildInlineArrayHelperDeclaration(string helperName, FFIEntryType arrayType)
    {
        var elementType = arrayType.Type is null ? "byte" : MapFieldType(arrayType.Type);
        var sb = new StringBuilder();
        if (SupportsInlineArray(elementType))
        {
            sb.Append("        [InlineArray(");
            sb.Append(arrayType.Size!.Value);
            sb.AppendLine(")] ");
            sb.AppendLine("        public unsafe partial struct " + helperName);
            sb.AppendLine("        {");
            sb.Append("            public ");
            sb.Append(elementType);
            sb.AppendLine(" e0;");
            sb.AppendLine("        }");
            return sb.ToString();
        }

        sb.AppendLine("        [StructLayout(LayoutKind.Sequential)]");
        sb.AppendLine("        public unsafe struct " + helperName);
        sb.AppendLine("        {");
        for (var i = 0; i < arrayType.Size!.Value; i++)
        {
            sb.Append("            public ");
            sb.Append(elementType);
            sb.Append(" e");
            sb.Append(i);
            sb.AppendLine(";");
        }
        sb.AppendLine("        }");
        return sb.ToString();
    }

    private static bool SupportsInlineArray(string elementType)
    {
        return !elementType.Contains('*', StringComparison.Ordinal);
    }

    private Dictionary<int, string> BuildNamedIdMap(string targetTag)
    {
        var map = new Dictionary<int, string>();
        var bareTag = targetTag.TrimStart(':');
        foreach (
            var alias in _entries.Where(e =>
                e.Tag == "typedef" && !string.IsNullOrWhiteSpace(e.Name)
            )
        )
        {
            var t = alias.Type;
            if (t?.Tag is null || !t.Id.HasValue)
                continue;

            if (t.Tag != targetTag && t.Tag != bareTag)
                continue;

            if (!map.ContainsKey(t.Id.Value))
                map[t.Id.Value] = alias.Name!;
        }
        return map;
    }

    private IEnumerable<string> BuildFunctionSignatures(FFIEntry function)
    {
        var returnType = MapFunctionReturnType(function.ReturnType);
        var parameters = function.Parameters ?? Array.Empty<FFIFunctionParameter>();
        var nativeParamList = new List<string>(parameters.Length);
        var managedParamList = new List<string>(parameters.Length);
        var hasManagedUtf8Overload = false;

        for (var i = 0; i < parameters.Length; i++)
        {
            var parameter = parameters[i];
            var typeName = MapParameterType(parameter.Type);
            var name = SanitizeIdentifier(parameter.Name, "arg" + i);
            nativeParamList.Add(typeName + " " + name);

            if (IsUtf8StringParameter(parameter.Type))
            {
                managedParamList.Add("[MarshalAs(UnmanagedType.LPUTF8Str)] string " + name);
                hasManagedUtf8Overload = true;
            }
            else
            {
                managedParamList.Add(typeName + " " + name);
            }
        }

        var functionName = SanitizeIdentifier(function.Name, "UnknownFunction");
        yield return returnType
            + " "
            + functionName
            + "("
            + string.Join(", ", nativeParamList)
            + ");";

        if (hasManagedUtf8Overload)
        {
            yield return returnType
                + " "
                + functionName
                + "("
                + string.Join(", ", managedParamList)
                + ");";
        }
    }

    private static bool IsUtf8StringParameter(FFIEntryType? type)
    {
        if (type?.Tag is not (":pointer" or ":array"))
            return false;

        return type.Type?.Tag is ":char" or ":signed-char";
    }

    private string MapFunctionReturnType(FFIFunctionReturnType? returnType)
    {
        if (returnType is null)
            return "void";

        if (!string.IsNullOrWhiteSpace(returnType.Tag))
            return MapTypeTag(
                returnType.Tag!,
                returnType.Type,
                isParameter: false,
                useFunctionPointerSyntax: false
            );

        return MapType(returnType.Type, isParameter: false, useFunctionPointerSyntax: false);
    }

    private string MapParameterType(FFIEntryType? type)
    {
        return MapType(type, isParameter: true, useFunctionPointerSyntax: false);
    }

    private string MapFieldType(FFIEntryType? type)
    {
        if (type is null)
            return "void*";

        return MapType(type, isParameter: false, useFunctionPointerSyntax: true);
    }

    private string MapType(FFIEntryType? type, bool isParameter, bool useFunctionPointerSyntax)
    {
        if (type is null || string.IsNullOrWhiteSpace(type.Tag))
            return "void*";

        return MapTypeTag(type.Tag!, type.Type, isParameter, useFunctionPointerSyntax, type);
    }

    private string MapTypeTag(
        string tag,
        FFIEntryType? nested,
        bool isParameter,
        bool useFunctionPointerSyntax,
        FFIEntryType? current = null
    )
    {
        switch (tag)
        {
            case ":void":
                return "void";
            case ":_Bool":
                return "byte";
            case ":char":
            case ":signed-char":
                return "sbyte";
            case ":unsigned-char":
                return "byte";
            case ":short":
                return "short";
            case ":unsigned-short":
                return "ushort";
            case ":int":
                return "int";
            case ":unsigned-int":
                return "uint";
            case ":long":
            case ":long-long":
                return "long";
            case ":unsigned-long":
            case ":unsigned-long-long":
                return "ulong";
            case ":float":
                return "float";
            case ":double":
                return "double";
            case ":pointer":
            case ":array":
            {
                // If the pointed-to type is itself a void*-replacement, collapse to void*
                // rather than emitting void** (e.g. SDL_Window* → void*, not void**).
                var innerName =
                    nested?.Name
                    ?? (
                        nested?.Tag?.StartsWith(":", StringComparison.Ordinal) == false
                            ? nested.Tag
                            : null
                    );
                if (innerName is not null && _voidPtrTypes.Contains(innerName))
                    return "void*";

                return MakePointerType(
                    MapType(nested, isParameter: false, useFunctionPointerSyntax: false)
                );
            }
            case ":function-pointer":
                return "void*";
            case ":struct":
            case "struct":
            {
                var name = ResolveCompositeName("struct", current, nested);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (_voidPtrTypes.Contains(name))
                        return "void*";
                    _neededStructs.Add(name);
                    return name;
                }
                return "void*";
            }
            case ":union":
            case "union":
            {
                var name = ResolveCompositeName("union", current, nested);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (_voidPtrTypes.Contains(name))
                        return "void*";
                    _neededUnions.Add(name);
                    return name;
                }
                return "void*";
            }
            case ":enum":
            case "enum":
            {
                var name = ResolveCompositeName("enum", current, nested);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    _neededEnums.Add(name);
                    return name;
                }
                return "int";
            }
            default:
                return MapNamedOrTypedef(tag, useFunctionPointerSyntax);
        }
    }

    private string MapNamedOrTypedef(string tag, bool useFunctionPointerSyntax)
    {
        if (BuiltinAliasMap.TryGetValue(tag, out var builtin))
            return builtin;

        if (DelegateDeclarations.Declarations.ContainsKey(tag))
        {
            _neededDelegates.Add(tag);
            if (
                useFunctionPointerSyntax
                && DelegateDeclarations.Declarations.TryGetValue(tag, out var declaration)
            )
            {
                return BuildUnmanagedFunctionPointerType(declaration);
            }

            return SanitizeTypeName(tag);
        }

        if (_voidPtrTypes.Contains(tag))
            return "void*";

        if (!_entriesByName.TryGetValue(tag, out var entry))
        {
            if (tag == "__builtin_va_list")
                return "void*";

            var opaque = SanitizeTypeName(tag);
            _opaqueTypes.Add(opaque);
            return opaque;
        }

        if (entry.Tag == "typedef")
        {
            _neededTypedefAliases.Add(tag);
            return ResolveTypedefToCSharp(entry, useFunctionPointerSyntax);
        }

        if (entry.Tag == "struct")
        {
            var name = SanitizeTypeName(entry.Name);
            _neededStructs.Add(name);
            return name;
        }

        if (entry.Tag == "union")
        {
            var name = SanitizeTypeName(entry.Name);
            _neededUnions.Add(name);
            return name;
        }

        if (entry.Tag == "enum")
        {
            var name = SanitizeTypeName(entry.Name);
            _neededEnums.Add(name);
            return name;
        }

        var fallback = SanitizeTypeName(tag);
        _opaqueTypes.Add(fallback);
        return fallback;
    }

    private string ResolveTypedefToCSharp(FFIEntry typedefEntry, bool useFunctionPointerSyntax)
    {
        if (typedefEntry.Type is null)
            return SanitizeTypeName(typedefEntry.Name);

        var type = typedefEntry.Type;
        var aliasName = SanitizeTypeName(typedefEntry.Name);
        if (type.Tag is ":function-pointer" or "function-pointer")
        {
            if (
                DelegateDeclarations.Declarations.TryGetValue(
                    typedefEntry.Name ?? aliasName,
                    out var declaration
                )
            )
            {
                _neededDelegates.Add(typedefEntry.Name ?? aliasName);
                if (useFunctionPointerSyntax)
                    return BuildUnmanagedFunctionPointerType(declaration);
                return aliasName;
            }

            return "void*";
        }

        if (type.Tag is ":struct" or "struct")
        {
            if (!string.IsNullOrWhiteSpace(type.Name))
            {
                var concrete = SanitizeTypeName(type.Name);
                _neededStructs.Add(concrete);
                return concrete;
            }

            _neededStructs.Add(aliasName);
            return aliasName;
        }

        if (type.Tag is ":union" or "union")
        {
            if (!string.IsNullOrWhiteSpace(type.Name))
            {
                var concrete = SanitizeTypeName(type.Name);
                _neededUnions.Add(concrete);
                return concrete;
            }

            _neededUnions.Add(aliasName);
            return aliasName;
        }

        if (type.Tag is ":enum" or "enum")
        {
            if (!string.IsNullOrWhiteSpace(type.Name))
            {
                var concrete = SanitizeTypeName(type.Name);
                _neededEnums.Add(concrete);
                return concrete;
            }

            _neededEnums.Add(aliasName);
            return aliasName;
        }

        return MapType(type, isParameter: false, useFunctionPointerSyntax: false);
    }

    private string? ResolveCompositeName(string kind, FFIEntryType? current, FFIEntryType? nested)
    {
        var preferred = current?.Name ?? nested?.Name;
        if (!string.IsNullOrWhiteSpace(preferred))
            return SanitizeTypeName(preferred);

        var id = current?.Id ?? nested?.Id;
        if (!id.HasValue)
            return null;

        return kind switch
        {
            "struct" when _namedStructById.TryGetValue(id.Value, out var s) => SanitizeTypeName(s),
            "union" when _namedUnionById.TryGetValue(id.Value, out var u) => SanitizeTypeName(u),
            "enum" when _namedEnumById.TryGetValue(id.Value, out var e) => SanitizeTypeName(e),
            _ => null,
        };
    }

    private FFIEntry? ResolveCompositeEntry(string tag, string name)
    {
        if (_entriesByName.TryGetValue(name, out var byName) && byName.Tag == tag)
            return byName;

        if (
            _entriesByName.TryGetValue(name, out var typedef)
            && typedef.Tag == "typedef"
            && typedef.Type is not null
        )
        {
            var t = typedef.Type;
            if (t.Tag == ":" + tag || t.Tag == tag)
            {
                if (
                    t.Id.HasValue
                    && _entriesByTagAndId.TryGetValue((tag, t.Id.Value), out var byTagAndId)
                )
                    return byTagAndId;

                // Fallback: synthesize from typedef metadata (including incomplete forward decls).
                return new FFIEntry
                {
                    Tag = tag,
                    Name = name,
                    Fields = t.Fields,
                    BitSize = t.BitSize,
                    BitAlignment = t.BitAlignment,
                };
            }
        }

        return _entries.FirstOrDefault(e => e.Tag == tag && e.Name == name);
    }

    private FFIEntry? ResolveEnumEntryByName(string name)
    {
        var direct = ResolveCompositeEntry("enum", name);
        if (direct is not null)
            return direct;

        if (
            _entriesByName.TryGetValue(name, out var typedef)
            && typedef.Tag == "typedef"
            && typedef.Type?.Tag == ":enum"
            && typedef.Type.Id.HasValue
            && _entriesByTagAndId.TryGetValue(("enum", typedef.Type.Id.Value), out var enumEntry)
        )
        {
            return enumEntry;
        }

        return null;
    }

    private void TrackRequiredTypes(FFIEntryType? type, string? immediateTag = null)
    {
        if (type is null && !string.IsNullOrWhiteSpace(immediateTag))
            return;

        if (!string.IsNullOrWhiteSpace(immediateTag))
            _ = MapTypeTag(
                immediateTag!,
                type,
                isParameter: false,
                useFunctionPointerSyntax: false
            );

        if (type is null)
            return;

        _ = MapType(type, isParameter: false, useFunctionPointerSyntax: false);
        TrackRequiredTypes(type.Type);

        if (type.Fields is null)
            return;

        foreach (var field in type.Fields)
            TrackRequiredTypes(field.Type);
    }

    private void TrackProcessedType(string processedType)
    {
        if (string.IsNullOrWhiteSpace(processedType))
            return;

        var typeName = processedType.Trim();
        while (typeName.EndsWith("*", StringComparison.Ordinal))
            typeName = typeName[..^1].TrimEnd();

        if (typeName.Length == 0 || ProcessedBuiltinTypes.Contains(typeName))
            return;

        _ = MapNamedOrTypedef(typeName, useFunctionPointerSyntax: false);
    }

    private string BuildUnmanagedFunctionPointerType(DelegateDeclaration declaration)
    {
        var parts = declaration.Parameters.Select(p => p.Type).Concat([declaration.ReturnType]);
        return "delegate* unmanaged[Cdecl]<" + string.Join(", ", parts) + ">";
    }

    private static string SanitizeIdentifier(string? raw, string fallback)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return fallback;

        var cleaned = SanitizeTypeName(raw);
        if (char.IsDigit(cleaned[0]))
            cleaned = "_" + cleaned;

        if (CSharpKeywords.Contains(cleaned))
            return "@" + cleaned;

        return cleaned;
    }

    private static string SanitizeTypeName(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return "Anonymous";

        var chars = raw.Select(c => char.IsLetterOrDigit(c) || c == '_' ? c : '_').ToArray();
        var value = new string(chars);
        if (string.IsNullOrWhiteSpace(value))
            return "Anonymous";
        if (char.IsDigit(value[0]))
            return "_" + value;
        return value;
    }

    private static string MakePointerType(string baseType)
    {
        if (string.IsNullOrWhiteSpace(baseType) || baseType == "void")
            return "void*";

        return baseType + "*";
    }

    private static string FormatEnumValue(long value)
    {
        if (value <= int.MaxValue && value >= int.MinValue)
            return value.ToString();

        var unsigned = unchecked((ulong)value);
        return "unchecked((int)0x" + unsigned.ToString("X8") + ")";
    }

    private static readonly HashSet<string> CSharpKeywords = new(StringComparer.Ordinal)
    {
        "abstract",
        "as",
        "base",
        "bool",
        "break",
        "byte",
        "case",
        "catch",
        "char",
        "checked",
        "class",
        "const",
        "continue",
        "decimal",
        "default",
        "delegate",
        "do",
        "double",
        "else",
        "enum",
        "event",
        "explicit",
        "extern",
        "false",
        "finally",
        "fixed",
        "float",
        "for",
        "foreach",
        "goto",
        "if",
        "implicit",
        "in",
        "int",
        "interface",
        "internal",
        "is",
        "lock",
        "long",
        "namespace",
        "new",
        "null",
        "object",
        "operator",
        "out",
        "override",
        "params",
        "private",
        "protected",
        "public",
        "readonly",
        "ref",
        "return",
        "sbyte",
        "sealed",
        "short",
        "sizeof",
        "stackalloc",
        "static",
        "string",
        "struct",
        "switch",
        "this",
        "throw",
        "true",
        "try",
        "typeof",
        "uint",
        "ulong",
        "unchecked",
        "unsafe",
        "ushort",
        "using",
        "virtual",
        "void",
        "volatile",
        "while",
    };
    private static readonly Dictionary<string, string> BuiltinAliasMap = new(StringComparer.Ordinal)
    {
        ["int8_t"] = "sbyte",
        ["uint8_t"] = "byte",
        ["int16_t"] = "short",
        ["uint16_t"] = "ushort",
        ["int32_t"] = "int",
        ["uint32_t"] = "uint",
        ["int64_t"] = "long",
        ["uint64_t"] = "ulong",
        ["size_t"] = "nuint",
        ["intptr_t"] = "nint",
        ["uintptr_t"] = "nuint",
        ["wchar_t"] = "char",
    };
    private static readonly HashSet<string> ProcessedBuiltinTypes = new(StringComparer.Ordinal)
    {
        "void",
        "byte",
        "sbyte",
        "short",
        "ushort",
        "int",
        "uint",
        "long",
        "ulong",
        "float",
        "double",
        "char",
        "nint",
        "nuint",
    };
}
