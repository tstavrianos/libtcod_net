using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BindingsPostProcessor;

public class ObsoleteDeclarationRemover
{
    public string Process(string content)
    {
        if (string.IsNullOrEmpty(content))
            return content;

        var lineBreak = content.Contains("\r\n") ? "\r\n" : "\n";
        var lines = content.Split(new[] { lineBreak }, StringSplitOptions.None);
        var result = new List<string>();

        int i = 0;
        while (i < lines.Length)
        {
            var line = lines[i];
            var trimmed = line.Trim();

            // Check if this line starts an [Obsolete] attribute
            if (!trimmed.StartsWith("[Obsolete"))
            {
                result.Add(line);
                i++;
                continue;
            }

            // Skip the entire [Obsolete(...)] attribute
            int j = i;
            while (j < lines.Length)
            {
                if (lines[j].TrimEnd().EndsWith("]"))
                {
                    j++;
                    break;
                }
                j++;
            }

            // Skip whitespace
            while (j < lines.Length && string.IsNullOrWhiteSpace(lines[j]))
            {
                j++;
            }

            // Skip any other attributes (like [DllImport])
            while (j < lines.Length && lines[j].TrimStart().StartsWith("["))
            {
                j++;
            }

            if (j >= lines.Length)
            {
                i++;
                continue;
            }

            var declarationLine = lines[j].TrimStart();
            bool isStructOrEnum = Regex.IsMatch(declarationLine, @"^\b(public|internal|protected|private)\b.*\b(struct|enum)\b");
            bool isFunction = Regex.IsMatch(declarationLine, @"^\b(public|internal|protected|private)\b.*\(.*\)");

            if (!isStructOrEnum && !isFunction)
            {
                result.Add(line);
                i++;
                continue;
            }

            // Remove preceding attribute lines
            while (result.Count > 0)
            {
                var last = result[result.Count - 1];
                if (last.TrimStart().StartsWith("["))
                {
                    result.RemoveAt(result.Count - 1);
                    continue;
                }
                break;
            }

            // Find the end of the declaration
            int end = j;
            if (isStructOrEnum)
            {
                int depth = 0;
                bool startedBody = false;

                for (int k = j; k < lines.Length; k++)
                {
                    int openCount = CountChar(lines[k], '{');
                    int closeCount = CountChar(lines[k], '}');

                    if (openCount > 0)
                    {
                        startedBody = true;
                        depth += openCount;
                    }
                    if (closeCount > 0)
                    {
                        depth -= closeCount;
                    }

                    if (startedBody && depth <= 0)
                    {
                        end = k;
                        break;
                    }
                }
            }
            else
            {
                // For functions, find the semicolon
                for (int k = j; k < lines.Length; k++)
                {
                    if (lines[k].Contains(";"))
                    {
                        end = k;
                        break;
                    }
                }
            }

            i = end + 1;
        }

        return string.Join(lineBreak, result);
    }

    private int CountChar(string s, char c)
    {
        int count = 0;
        foreach (char ch in s)
        {
            if (ch == c)
                count++;
        }
        return count;
    }
}
