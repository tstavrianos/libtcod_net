using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BindingsPostProcessor;

public class SdlStructRemover
{
    private static readonly string[] SdlTypes = new[]
    {
        "SDL_Window",
        "SDL_Renderer",
        "SDL_Texture",
        "SDL_Surface",
        "SDL_Event",
        "SDL_Rect"
    };

    public string Process(string content)
    {
        if (string.IsNullOrEmpty(content))
            return content;

        string output = content;

        foreach (var typeName in SdlTypes)
        {
            // Remove the placeholder struct and any immediately preceding attribute lines
            var pattern = @"(?ms)^\s*(?:\[[^\]]+\]\s*\r?\n)*\s*public\s+partial\s+struct\s+" + 
                         Regex.Escape(typeName) + @"\s*\{\s*\}\s*";
            
            output = Regex.Replace(output, pattern, "");
        }

        // Also handle SDL_Event partial struct patterns
        output = Regex.Replace(output, @"\[StructLayout\(LayoutKind\.Explicit\)\]\r?\n\s*(public partial struct SDL_Event)", "$1");

        return output;
    }
}
