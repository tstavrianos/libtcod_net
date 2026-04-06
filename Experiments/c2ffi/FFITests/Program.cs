using System;
using System.IO;
using System.Text.Json;

namespace FFITests;

// TODO:
//   Delegates
//   sbyte* -> string overloads with marshaling

internal static class Program
{
    internal static readonly string[] TypeReplacements =
    {
        "SDL_Event*",
        "SDL_Window*",
        "SDL_Renderer*",
        "SDL_Texture*",
        "SDL_Surface*",
        "SDL_Rect*",
    };

    public static void Main(string[] args)
    {
        var inputPath = ResolveInputPath(args);
        var entries =
            JsonSerializer.Deserialize<FFIEntry[]>(
                File.ReadAllText(inputPath),
                SourceGenerationContext.Default.FFIEntryArray
            ) ?? Array.Empty<FFIEntry>();

        var generator = new BindingGenerator(entries);
        var output = generator.Generate();
        var outputPath = ResolveOutputPath(args, inputPath);
        File.WriteAllText(outputPath, output);
        Console.WriteLine("Generated " + outputPath);
    }

    private static string ResolveInputPath(string[] args)
    {
        if (args.Length > 0 && File.Exists(args[0]))
            return args[0];

        var candidates = new[]
        {
            "libtcod.json",
            Path.Combine("FFITests", "libtcod.json"),
            Path.Combine(AppContext.BaseDirectory, "libtcod.json"),
        };

        foreach (var candidate in candidates)
        {
            if (File.Exists(candidate))
                return candidate;
        }

        throw new FileNotFoundException(
            "Could not locate libtcod.json. Pass it as the first argument.",
            "libtcod.json"
        );
    }

    private static string ResolveOutputPath(string[] args, string inputPath)
    {
        if (args.Length > 1)
            return args[1];

        var directory = Path.GetDirectoryName(inputPath);
        if (string.IsNullOrWhiteSpace(directory))
            return "bindings.txt";

        return Path.Combine(directory, "bindings.txt");
    }
}
