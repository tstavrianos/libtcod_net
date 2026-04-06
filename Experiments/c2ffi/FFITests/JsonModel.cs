using System.Text.Json.Serialization;

namespace FFITests;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(FFIEntry[]))]
internal partial class SourceGenerationContext : JsonSerializerContext { }

internal class FFIEntry
{
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("ns")]
    public int NS { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("bit-size")]
    public int? BitSize { get; set; }

    [JsonPropertyName("bit-alignment")]
    public int? BitAlignment { get; set; }

    [JsonPropertyName("type")]
    public FFIEntryType? Type { get; set; }

    [JsonPropertyName("fields")]
    public FFIField[]? Fields { get; set; }

    [JsonPropertyName("variadic")]
    public bool Variadic { get; set; }

    [JsonPropertyName("inline")]
    public bool Inline { get; set; }

    [JsonPropertyName("storage-class")]
    public string? StorageClass { get; set; }

    [JsonPropertyName("parameters")]
    public FFIFunctionParameter[]? Parameters { get; set; }

    [JsonPropertyName("return-type")]
    public FFIFunctionReturnType? ReturnType { get; set; }
}

internal class FFIFunctionReturnType
{
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("bit-size")]
    public int? BitSize { get; set; }

    [JsonPropertyName("bit-alignment")]
    public int? BitAlignment { get; set; }

    [JsonPropertyName("type")]
    public FFIEntryType? Type { get; set; }
}

internal class FFIFunctionParameter
{
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public FFIEntryType? Type { get; set; }
}

internal class FFIEntryType
{
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("ns")]
    public int? NS { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("bit-size")]
    public int? BitSize { get; set; }

    [JsonPropertyName("bit-alignment")]
    public int? BitAlignment { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("fields")]
    public FFIField[]? Fields { get; set; }

    [JsonPropertyName("type")]
    public FFIEntryType? Type { get; set; }
}

internal class FFIField
{
    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("value")]
    public long? Value { get; set; }

    [JsonPropertyName("bit-offset")]
    public int? BitOffset { get; set; }

    [JsonPropertyName("bit-size")]
    public int? BitSize { get; set; }

    [JsonPropertyName("bit-alignment")]
    public int? BitAlignment { get; set; }

    [JsonPropertyName("type")]
    public FFIEntryType? Type { get; set; }
}
