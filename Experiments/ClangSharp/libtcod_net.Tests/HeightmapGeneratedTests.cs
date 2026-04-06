using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class HeightmapGeneratedTests
{
    [Fact]
    public void HeightmapGetMinMax_OnFreshMapMatchesObservedInteropBehavior()
    {
        var heightmap = TCOD_heightmap_new(1, 1);
        Assert.False(heightmap == null);

        try
        {
            float min,
                max;
            TCOD_heightmap_get_minmax(heightmap, &min, &max);
            Assert.Equal(0.0f, min);
            Assert.Equal(0.0f, max);
        }
        finally
        {
            TCOD_heightmap_delete(heightmap);
        }
    }

    [Fact]
    public void HeightmapKernelTransform_AllowsNullHeightmap()
    {
        var dx = new[] { 0 };
        var dy = new[] { 0 };
        var weight = new[] { 1.0f };

        fixed (int* x = dx.AsSpan())
        fixed (int* y = dy.AsSpan())
        fixed (float* w = weight.AsSpan())
            TCOD_heightmap_kernel_transform(null, 1, x, y, w, -float.MaxValue, float.MaxValue);
    }
}
