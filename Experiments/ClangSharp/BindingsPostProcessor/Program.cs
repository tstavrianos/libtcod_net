using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindingsPostProcessor;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine(
                "Usage: BindingsPostProcessor <output-directory> [--skip-wrappers] [--skip-obsolete-removal]"
            );
            return 1;
        }

        string outputDir = args[0];
        bool skipWrappers = args.Contains("--skip-wrappers");
        bool skipObsoleteRemoval = args.Contains("--skip-obsolete-removal");

        if (!Directory.Exists(outputDir))
        {
            Console.Error.WriteLine($"Error: Output directory does not exist: {outputDir}");
            return 1;
        }

        try
        {
            var csFiles = Directory
                .GetFiles(outputDir, "*.cs")
                .Where(f => Path.GetFileName(f) != "NativeTypeNameAttribute.cs")
                .ToList();

            Console.WriteLine($"Processing {csFiles.Count} generated C# files...");

            int processedCount = 0;
            int wrapperCount = 0;
            int removedObsoleteCount = 0;

            foreach (var filePath in csFiles)
            {
                string fileName = Path.GetFileName(filePath);
                string content = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(content))
                    continue;

                bool modified = false;

                // Fix broken multi-line string concatenation in [Obsolete] attributes (FIRST!)
                var stringFixer = new MultilineStringConcatenationFixer();
                string contentAfterStringFix = stringFixer.Process(content);
                if (contentAfterStringFix != content)
                {
                    content = contentAfterStringFix;
                    modified = true;
                }

                // Remove SDL struct declarations
                var sdlRemover = new SdlStructRemover();
                string contentAfterSdlRemoval = sdlRemover.Process(content);
                if (contentAfterSdlRemoval != content)
                {
                    Console.WriteLine($"  Removed SDL structs from {fileName}");
                    content = contentAfterSdlRemoval;
                    modified = true;
                }

                // Remove [Obsolete] declarations (unless skipped)
                if (!skipObsoleteRemoval)
                {
                    var obsoleteRemover = new ObsoleteDeclarationRemover();
                    string contentAfterObsoleteRemoval = obsoleteRemover.Process(content);
                    if (contentAfterObsoleteRemoval != content)
                    {
                        int removed =
                            (
                                content.Split("public ").Length
                                - contentAfterObsoleteRemoval.Split("public ").Length
                            ) / 2;
                        if (removed > 0)
                        {
                            Console.WriteLine(
                                $"  Removed {removed} obsolete declarations from {fileName}"
                            );
                            removedObsoleteCount += removed;
                        }
                        content = contentAfterObsoleteRemoval;
                        modified = true;
                    }
                }

                // Generate managed string wrappers (unless skipped)
                if (!skipWrappers)
                {
                    var wrapperGen = new ManagedStringWrapperGenerator();
                    var result = wrapperGen.Process(content);
                    if (result.GeneratedWrappers > 0)
                    {
                        Console.WriteLine(
                            $"  Generated {result.GeneratedWrappers} managed wrappers in {fileName}"
                        );
                        wrapperCount += result.GeneratedWrappers;
                        content = result.TransformedContent;
                        modified = true;
                    }
                }

                // Remove invalid wrappers with unpassable parameters (e.g., __arglist)
                // This is a safety net in case a varargs signature slips through detection.
                var invalidWrapperRemover = new InvalidWrapperRemover();
                string contentAfterInvalidRemoval = invalidWrapperRemover.Process(content);
                if (contentAfterInvalidRemoval != content)
                {
                    content = contentAfterInvalidRemoval;
                    modified = true;
                }

                if (modified)
                {
                    File.WriteAllText(filePath, content);
                    processedCount++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("✅ Post-processing complete:");
            Console.WriteLine($"   • Files processed: {processedCount}");
            Console.WriteLine($"   • Managed wrappers generated: {wrapperCount}");
            if (!skipObsoleteRemoval)
            {
                Console.WriteLine($"   • Obsolete declarations removed: {removedObsoleteCount}");
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Console.Error.WriteLine(ex.StackTrace);
            return 1;
        }
    }
}
