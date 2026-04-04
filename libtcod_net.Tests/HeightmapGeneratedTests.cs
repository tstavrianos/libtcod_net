namespace libtcod_net.Tests;

public class HeightmapGeneratedTests
{
    [Fact]
    public void HeightmapGetMinMax_OnFreshMapMatchesObservedInteropBehavior()
    {
        var heightmap = LibraryImportMethods.TCOD_heightmap_new(1, 1);
        Assert.NotEqual(nint.Zero, heightmap);

        try
        {
            LibraryImportMethods.TCOD_heightmap_get_minmax(heightmap, out var min, out var max);
            Assert.Equal(0.0f, min);
            Assert.Equal(0.0f, max);
        }
        finally
        {
            LibraryImportMethods.TCOD_heightmap_delete(heightmap);
        }
    }

    [Fact]
    public void HeightmapKernelTransform_AllowsNullHeightmap()
    {
        var dx = new[] { 0 };
        var dy = new[] { 0 };
        var weight = new[] { 1.0f };

        LibraryImportMethods.TCOD_heightmap_kernel_transform(
            nint.Zero,
            1,
            dx,
            dy,
            weight,
            -float.MaxValue,
            float.MaxValue
        );
    }
}
