using System;
using System.Text.RegularExpressions;

public class InvalidWrapperRemover
{
    public string Process(string content)
    {
        // Split content into lines to process line by line
        var lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        var result = new System.Collections.Generic.List<string>();
        
        int i = 0;
        while (i < lines.Length)
        {
            var line = lines[i];
            
            // Look for managed wrapper comments
            if (line.Contains("// Managed wrapper for"))
            {
                // Check if the following method has __arglist or RuntimeArgumentHandle
                var hasUnpassable = false;
                var methodEnd = -1;
                var braceCount = 0;
                var foundBrace = false;
                
                // Scan forwards to identify the method bounds
                for (int j = i; j < lines.Length; j++)
                {
                    var checkLine = lines[j];
                    
                    // Check for unpassable parameter types (skip comments)
                    if (!checkLine.TrimStart().StartsWith("//"))
                    {
                        if (checkLine.Contains("__arglist") || checkLine.Contains("RuntimeArgumentHandle"))
                        {
                            hasUnpassable = true;
                        }
                    }
                    
                    // Track braces to find method end
                    foreach (var ch in checkLine)
                    {
                        if (ch == '{')
                        {
                            foundBrace = true;
                            braceCount++;
                        }
                        else if (ch == '}')
                        {
                            braceCount--;
                            if (foundBrace && braceCount == 0)
                            {
                                methodEnd = j;
                                break;
                            }
                        }
                    }
                    
                    if (methodEnd >= 0)
                        break;
                }
                
                if (hasUnpassable && methodEnd >= 0)
                {
                    // Remove this wrapper entirely
                    i = methodEnd + 1;
                    // Skip trailing blank lines
                    while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i]))
                    {
                        i++;
                    }
                    continue;
                }
            }
            
            result.Add(line);
            i++;
        }
        
        return string.Join("\r\n", result);
    }
}
