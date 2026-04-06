using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class InteropRuntimeSmokeTests
{
    [Fact]
    public void RandomAndNoise_CanCreateAndSample()
    {
        TCOD_Random* random = null;
        TCOD_Noise* noise = null;

        try
        {
            random = TCOD_random_new(TCOD_random_algo_t.TCOD_RNG_MT);
            Assert.False(random == null);

            noise = TCOD_noise_new(2, 0.5f, 2.0f, random);
            Assert.False(noise == null);

            var f = new float[] { 0.1f, 0.2f };
            float value;
            fixed (float* fPtr = f.AsSpan())
                value = TCOD_noise_get(noise, fPtr);
            Assert.False(float.IsNaN(value));
            Assert.False(float.IsInfinity(value));
        }
        finally
        {
            if (noise != null)
            {
                TCOD_noise_delete(noise);
            }

            if (random != null)
            {
                TCOD_random_delete(random);
            }
        }
    }

    [Fact]
    public void Image_CanLoadAndDelete()
    {
        var imagePath = Path.Combine(AppContext.BaseDirectory, "terminal.png");
        Assert.True(File.Exists(imagePath), $"Expected image file at {imagePath}");
        using var allocator = new ArenaNativeAllocator(1024);
        var imagePathPtr = CString.FromString(allocator, imagePath);
        var image = TCOD_image_load(imagePathPtr);
        allocator.Free(imagePathPtr);
        Assert.False(image == null);

        try
        {
            int width,
                height;
            TCOD_image_get_size(image, &width, &height);
            Assert.True(width > 0);
            Assert.True(height > 0);
        }
        finally
        {
            TCOD_image_delete(image);
        }
    }

    [Fact]
    public void MapPathAndDijkstra_CanComputeAndDelete()
    {
        TCOD_Map* map = null;
        TCOD_Path* path = null;
        TCOD_Dijkstra* dijkstra = null;

        try
        {
            map = TCOD_map_new(10, 10);
            Assert.False(map == null);

            TCOD_map_clear(map, true, true);

            path = TCOD_path_new_using_map(map, 1.41f);
            Assert.False(path == null);

            var pathFound = TCOD_path_compute(path, 0, 0, 9, 9);
            Assert.True(pathFound == true);
            var pathLength = TCOD_path_size(path);
            Assert.True(pathLength > 0);

            dijkstra = TCOD_dijkstra_new(map, 1.41f);
            Assert.False(dijkstra == null);

            TCOD_dijkstra_compute(dijkstra, 0, 0);
            var dist = TCOD_dijkstra_get_distance(dijkstra, 9, 9);
            Assert.False(float.IsNaN(dist));
            Assert.True(dist >= 0);
        }
        finally
        {
            if (dijkstra != null)
            {
                TCOD_dijkstra_delete(dijkstra);
            }

            if (path != null)
            {
                TCOD_path_delete(path);
            }

            if (map != null)
            {
                TCOD_map_delete(map);
            }
        }
    }

    [Fact]
    public void HeapAndPathfinder_CanInitializeAndDispose()
    {
        var heap = new TCOD_Heap();
        var initResult = TCOD_heap_init(&heap, (nuint)4);
        Assert.True(initResult >= 0);

        Assert.True(heap.data_size >= 4);

        var data = new byte[] { 11, 22, 33, 44 };
        int pushResult;
        fixed (void* d = data.AsSpan())
            pushResult = TCOD_minheap_push(&heap, 5, d);
        Assert.True(pushResult >= 0);

        var popped = new byte[4];
        fixed (void* p = popped.AsSpan())
            TCOD_minheap_pop(&heap, p);
        Assert.Equal(new byte[] { 11, 22, 33, 44 }, popped);

        TCOD_heap_uninit(&heap);

        var slope = new ulong[] { 8, 8 };
        TCOD_Pathfinder* pathfinder;
        fixed (ulong* u = slope.AsSpan())
            pathfinder = TCOD_pf_new(2, u);
        Assert.False(pathfinder == null);
        TCOD_pf_delete(pathfinder);
    }
}
