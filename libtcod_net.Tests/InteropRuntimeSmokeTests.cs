namespace libtcod_net.Tests;

public class InteropRuntimeSmokeTests
{
    [Fact]
    public void RandomAndNoise_CanCreateAndSample()
    {
        nint random = nint.Zero;
        nint noise = nint.Zero;

        try
        {
            random = NativeMethods.TCOD_random_new(TCOD_random_algo_t.TCOD_RNG_MT);
            Assert.NotEqual(nint.Zero, random);

            noise = NativeMethods.TCOD_noise_new(2, 0.5f, 2.0f, random);
            Assert.NotEqual(nint.Zero, noise);

            var value = NativeMethods.TCOD_noise_get(noise, new float[] { 0.1f, 0.2f });
            Assert.False(float.IsNaN(value));
            Assert.False(float.IsInfinity(value));
        }
        finally
        {
            if (noise != nint.Zero)
            {
                NativeMethods.TCOD_noise_delete(noise);
            }

            if (random != nint.Zero)
            {
                NativeMethods.TCOD_random_delete(random);
            }
        }
    }

    [Fact]
    public void Image_CanLoadAndDelete()
    {
        var imagePath = Path.Combine(AppContext.BaseDirectory, "terminal.png");
        Assert.True(File.Exists(imagePath), $"Expected image file at {imagePath}");

        var image = NativeMethods.TCOD_image_load(imagePath);
        Assert.NotEqual(nint.Zero, image);

        try
        {
            NativeMethods.TCOD_image_get_size(image, out var width, out var height);
            Assert.True(width > 0);
            Assert.True(height > 0);
        }
        finally
        {
            NativeMethods.TCOD_image_delete(image);
        }
    }

    [Fact]
    public void MapPathAndDijkstra_CanComputeAndDelete()
    {
        nint map = nint.Zero;
        nint path = nint.Zero;
        nint dijkstra = nint.Zero;

        try
        {
            map = NativeMethods.TCOD_map_new(10, 10);
            Assert.NotEqual(nint.Zero, map);

            NativeMethods.TCOD_map_clear(map, true, true);

            path = NativeMethods.TCOD_path_new_using_map(map, 1.41f);
            Assert.NotEqual(nint.Zero, path);

            var pathFound = NativeMethods.TCOD_path_compute(path, 0, 0, 9, 9);
            Assert.True(pathFound);
            var pathLength = NativeMethods.TCOD_path_size(path);
            Assert.True(pathLength > 0);

            dijkstra = NativeMethods.TCOD_dijkstra_new(map, 1.41f);
            Assert.NotEqual(nint.Zero, dijkstra);

            NativeMethods.TCOD_dijkstra_compute(dijkstra, 0, 0);
            var dist = NativeMethods.TCOD_dijkstra_get_distance(dijkstra, 9, 9);
            Assert.False(float.IsNaN(dist));
            Assert.True(dist >= 0);
        }
        finally
        {
            if (dijkstra != nint.Zero)
            {
                NativeMethods.TCOD_dijkstra_delete(dijkstra);
            }

            if (path != nint.Zero)
            {
                NativeMethods.TCOD_path_delete(path);
            }

            if (map != nint.Zero)
            {
                NativeMethods.TCOD_map_delete(map);
            }
        }
    }

    [Fact]
    public void HeapAndPathfinder_CanInitializeAndDispose()
    {
        var heap = new TCOD_Heap();
        var initResult = NativeMethods.TCOD_heap_init(ref heap, (nuint)4);
        Assert.True(initResult >= 0);

        Assert.True(heap.data_size >= 4);

        var pushResult = NativeMethods.TCOD_minheap_push(
            ref heap,
            5,
            new byte[] { 11, 22, 33, 44 }
        );
        Assert.True(pushResult >= 0);

        var popped = new byte[4];
        NativeMethods.TCOD_minheap_pop(ref heap, popped);
        Assert.Equal(new byte[] { 11, 22, 33, 44 }, popped);

        NativeMethods.TCOD_heap_uninit(ref heap);

        var pathfinder = NativeMethods.TCOD_pf_new(2, new nuint[] { 8, 8 });
        Assert.NotEqual(nint.Zero, pathfinder);
        NativeMethods.TCOD_pf_delete(pathfinder);
    }
}
