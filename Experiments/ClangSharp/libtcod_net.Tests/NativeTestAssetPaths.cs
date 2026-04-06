namespace libtcod_net.Tests;

internal static class NativeTestAssetPaths
{
    public static string NativeData(params string[] segments)
    {
        var parts = new string[segments.Length + 2];
        parts[0] = AppContext.BaseDirectory;
        parts[1] = "native-data";
        Array.Copy(segments, 0, parts, 2, segments.Length);
        var path = Path.Combine(parts);
        Assert.True(File.Exists(path), $"Expected test asset at {path}");
        return path;
    }
}
