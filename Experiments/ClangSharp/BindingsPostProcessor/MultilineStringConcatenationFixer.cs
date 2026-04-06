using System;
using System.Text.RegularExpressions;

namespace BindingsPostProcessor;

public class MultilineStringConcatenationFixer
{
    public string Process(string content)
    {
        if (string.IsNullOrEmpty(content))
            return content;

        // Fix broken multi-line string concatenation emitted in [Obsolete(...)] attributes
        // Pattern: "text"\n    "more text" should become: "text" +\n    "more text"
        var pattern = @"""(\r?\n)(\s+)""";
        var replacement = @""" +" + Environment.NewLine + @"$2""";

        return Regex.Replace(content, pattern, replacement);
    }
}
