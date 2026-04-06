using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

var inputPath = "merged.json";
var outputPath = "fixed.json";

var input = File.ReadAllText(inputPath);

// c2cs doesn't support the "__restrict" qualifier, so remove it from the input JSON.
input = input.Replace("*restrict", "*");

var root =
    JsonNode.Parse(input) as JsonObject
    ?? throw new InvalidOperationException("The root JSON value must be an object.");

var sdlOpaqueRegex = new Regex(@"^(struct|union)\s+SDL_", RegexOptions.Compiled);
var removedOpaqueNames = new HashSet<string>(StringComparer.Ordinal);

if (root["opaques"] is JsonObject opaques)
{
    var keysToRemove = opaques
        .Select(kvp => kvp.Key)
        .Where(key => sdlOpaqueRegex.IsMatch(key))
        .ToList();

    foreach (var key in keysToRemove)
    {
        removedOpaqueNames.Add(key);
        opaques.Remove(key);
    }
}

// c2cs doesn't support unnamed enums, so remove them from the input JSON.
var removedEnumCount = 0;
if (root["enums"] is JsonObject enums)
{
    var unnamedEnumKeys = enums
        .Select(kvp => kvp.Key)
        .Where(key => key.StartsWith("enum (unnamed", StringComparison.Ordinal))
        .ToList();

    foreach (var key in unnamedEnumKeys)
    {
        enums.Remove(key);
        removedEnumCount++;
    }
}

var rewrittenTypeCount = RewriteTypePointers(root, removedOpaqueNames);

var output = root.ToJsonString(new JsonSerializerOptions { WriteIndented = true });

File.WriteAllText(outputPath, output);

Console.WriteLine($"Removed opaques: {removedOpaqueNames.Count}");
Console.WriteLine($"Removed unnamed enums: {removedEnumCount}");
Console.WriteLine($"Rewritten pointer types: {rewrittenTypeCount}");
Console.WriteLine($"Wrote: {outputPath}");

static int RewriteTypePointers(JsonNode node, HashSet<string> removedOpaqueNames)
{
    var rewritten = 0;

    if (node is JsonObject obj)
    {
        if (obj["type"] is JsonObject typeObj)
        {
            rewritten += TryRewriteType(typeObj, removedOpaqueNames) ? 1 : 0;
        }
        if (obj["return_type"] is JsonObject returnTypeObj)
        {
            rewritten += TryRewriteType(returnTypeObj, removedOpaqueNames) ? 1 : 0;
        }

        foreach (var child in obj)
        {
            if (child.Value is not null)
            {
                rewritten += RewriteTypePointers(child.Value, removedOpaqueNames);
            }
        }
    }
    else if (node is JsonArray array)
    {
        foreach (var child in array)
        {
            if (child is not null)
            {
                rewritten += RewriteTypePointers(child, removedOpaqueNames);
            }
        }
    }

    return rewritten;
}

static bool TryRewriteType(JsonObject typeObj, HashSet<string> removedOpaqueNames)
{
    if (!string.Equals(typeObj["kind"]?.GetValue<string>(), "pointer", StringComparison.Ordinal))
    {
        return false;
    }

    if (typeObj["inner_type"] is not JsonObject innerType)
    {
        return false;
    }

    if (
        !string.Equals(
            innerType["kind"]?.GetValue<string>(),
            "opaqueType",
            StringComparison.Ordinal
        )
    )
    {
        return false;
    }

    var innerName = innerType["name"]?.GetValue<string>();
    if (string.IsNullOrWhiteSpace(innerName) || !removedOpaqueNames.Contains(innerName))
    {
        return false;
    }

    var typeName = typeObj["name"]?.GetValue<string>() ?? string.Empty;
    var expectedConst = $"const {innerName} *";
    var expectedMutable = $"{innerName} *";

    if (string.Equals(typeName, expectedConst, StringComparison.Ordinal))
    {
        typeObj["name"] = "const void *";
    }
    else if (string.Equals(typeName, expectedMutable, StringComparison.Ordinal))
    {
        typeObj["name"] = "void *";
    }
    else
    {
        return false;
    }

    innerType["name"] = "void";
    return true;
}
