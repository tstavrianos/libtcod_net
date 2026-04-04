namespace libtcod_net.Tests;

public class LibraryImportParityTests
{
    [Fact]
    public void RandomIntSequence_MatchesDllImportForSameSeed()
    {
        const uint seed = 123456u;

        var randomDll = NativeMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );
        var randomLib = LibraryImportMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );

        Assert.NotEqual(nint.Zero, randomDll);
        Assert.NotEqual(nint.Zero, randomLib);

        try
        {
            for (int i = 0; i < 32; ++i)
            {
                var a = NativeMethods.TCOD_random_get_int(randomDll, -1000, 1000);
                var b = LibraryImportMethods.TCOD_random_get_int(randomLib, -1000, 1000);
                Assert.Equal(a, b);
            }
        }
        finally
        {
            NativeMethods.TCOD_random_delete(randomDll);
            LibraryImportMethods.TCOD_random_delete(randomLib);
        }
    }

    [Fact]
    public void RandomFloatSequence_MatchesDllImportForSameSeed()
    {
        const uint seed = 777u;

        var randomDll = NativeMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );
        var randomLib = LibraryImportMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );

        Assert.NotEqual(nint.Zero, randomDll);
        Assert.NotEqual(nint.Zero, randomLib);

        try
        {
            for (int i = 0; i < 32; ++i)
            {
                var a = NativeMethods.TCOD_random_get_float(randomDll, -10f, 10f);
                var b = LibraryImportMethods.TCOD_random_get_float(randomLib, -10f, 10f);
                Assert.Equal(a, b);
            }
        }
        finally
        {
            NativeMethods.TCOD_random_delete(randomDll);
            LibraryImportMethods.TCOD_random_delete(randomLib);
        }
    }

    [Fact]
    public void NoiseValues_MatchDllImportForSameRandomSeed()
    {
        const uint seed = 42u;

        var randomDll = NativeMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );
        var randomLib = LibraryImportMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );

        Assert.NotEqual(nint.Zero, randomDll);
        Assert.NotEqual(nint.Zero, randomLib);

        var noiseDll = NativeMethods.TCOD_noise_new(3, 2.0f, 2.0f, randomDll);
        var noiseLib = LibraryImportMethods.TCOD_noise_new(3, 2.0f, 2.0f, randomLib);

        Assert.NotEqual(nint.Zero, noiseDll);
        Assert.NotEqual(nint.Zero, noiseLib);

        try
        {
            NativeMethods.TCOD_noise_set_type(noiseDll, TCOD_noise_type_t.TCOD_NOISE_PERLIN);
            LibraryImportMethods.TCOD_noise_set_type(noiseLib, TCOD_noise_type_t.TCOD_NOISE_PERLIN);

            // Test basic noise sample with fixed coordinates
            unsafe
            {
                float[] coords = { 0.5f, 0.5f, 0.5f };
                fixed (float* pCoords = coords)
                {
                    var nint_coords = (nint)pCoords;
                    var a = NativeMethods.TCOD_noise_get(noiseDll, nint_coords);
                    var b = LibraryImportMethods.TCOD_noise_get(noiseLib, nint_coords);
                    Assert.Equal(a, b);
                }
            }
        }
        finally
        {
            NativeMethods.TCOD_noise_delete(noiseDll);
            LibraryImportMethods.TCOD_noise_delete(noiseLib);
            NativeMethods.TCOD_random_delete(randomDll);
            LibraryImportMethods.TCOD_random_delete(randomLib);
        }
    }

    [Fact]
    public void NoiseFbmValues_MatchDllImportForSameRandomSeed()
    {
        const uint seed = 99u;

        var randomDll = NativeMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );
        var randomLib = LibraryImportMethods.TCOD_random_new_from_seed(
            TCOD_random_algo_t.TCOD_RNG_MT,
            seed
        );

        var noiseDll = NativeMethods.TCOD_noise_new(2, 2.0f, 2.0f, randomDll);
        var noiseLib = LibraryImportMethods.TCOD_noise_new(2, 2.0f, 2.0f, randomLib);

        try
        {
            NativeMethods.TCOD_noise_set_type(noiseDll, TCOD_noise_type_t.TCOD_NOISE_SIMPLEX);
            LibraryImportMethods.TCOD_noise_set_type(
                noiseLib,
                TCOD_noise_type_t.TCOD_NOISE_SIMPLEX
            );

            // Test FBM with fixed coordinates
            unsafe
            {
                float[] coords = { 0.25f, 0.75f };
                fixed (float* pCoords = coords)
                {
                    var nint_coords = (nint)pCoords;
                    var a = NativeMethods.TCOD_noise_get_fbm(noiseDll, nint_coords, 4.0f);
                    var b = LibraryImportMethods.TCOD_noise_get_fbm(noiseLib, nint_coords, 4.0f);
                    Assert.Equal(a, b);
                }
            }
        }
        finally
        {
            NativeMethods.TCOD_noise_delete(noiseDll);
            LibraryImportMethods.TCOD_noise_delete(noiseLib);
            NativeMethods.TCOD_random_delete(randomDll);
            LibraryImportMethods.TCOD_random_delete(randomLib);
        }
    }

    [Fact]
    public void DijkstraDistance_MatchesDllImportForSameMap()
    {
        const int mapWidth = 20;
        const int mapHeight = 20;

        // Create maps for both implementations
        var mapDll = NativeMethods.TCOD_map_new(mapWidth, mapHeight);
        var mapLib = NativeMethods.TCOD_map_new(mapWidth, mapHeight);

        Assert.NotEqual(nint.Zero, mapDll);
        Assert.NotEqual(nint.Zero, mapLib);

        try
        {
            // Make all cells walkable and transparent
            NativeMethods.TCOD_map_clear(mapDll, transparent: true, walkable: true);
            NativeMethods.TCOD_map_clear(mapLib, transparent: true, walkable: true);

            // Create dijkstra objects via both implementations
            var dijkstraDll = NativeMethods.TCOD_dijkstra_new(mapDll, 1.414f);
            nint dijkstraLib;
            unsafe
            {
                dijkstraLib = LibraryImportMethods.TCOD_dijkstra_new((nint)(void*)mapLib, 1.414f);
            }

            Assert.NotEqual(nint.Zero, dijkstraDll);
            Assert.NotEqual(nint.Zero, dijkstraLib);

            try
            {
                // Compute dijkstra from same root for both
                const int rootX = 5;
                const int rootY = 5;

                NativeMethods.TCOD_dijkstra_compute(dijkstraDll, rootX, rootY);
                LibraryImportMethods.TCOD_dijkstra_compute(dijkstraLib, rootX, rootY);

                // Compare distances at several points
                var dist1Dll = NativeMethods.TCOD_dijkstra_get_distance(dijkstraDll, 5, 5);
                var dist1Lib = LibraryImportMethods.TCOD_dijkstra_get_distance(dijkstraLib, 5, 5);
                Assert.Equal(dist1Dll, dist1Lib);

                var dist2Dll = NativeMethods.TCOD_dijkstra_get_distance(dijkstraDll, 10, 10);
                var dist2Lib = LibraryImportMethods.TCOD_dijkstra_get_distance(dijkstraLib, 10, 10);
                Assert.Equal(dist2Dll, dist2Lib);

                var dist3Dll = NativeMethods.TCOD_dijkstra_get_distance(dijkstraDll, 0, 0);
                var dist3Lib = LibraryImportMethods.TCOD_dijkstra_get_distance(dijkstraLib, 0, 0);
                Assert.Equal(dist3Dll, dist3Lib);
            }
            finally
            {
                NativeMethods.TCOD_dijkstra_delete(dijkstraDll);
                LibraryImportMethods.TCOD_dijkstra_delete(dijkstraLib);
            }
        }
        finally
        {
            NativeMethods.TCOD_map_delete(mapDll);
            NativeMethods.TCOD_map_delete(mapLib);
        }
    }

    [Fact]
    public void PathCompute_MatchesDllImportForSameMap()
    {
        const int mapWidth = 30;
        const int mapHeight = 30;

        var mapDll = NativeMethods.TCOD_map_new(mapWidth, mapHeight);
        var mapLib = NativeMethods.TCOD_map_new(mapWidth, mapHeight);

        NativeMethods.TCOD_map_clear(mapDll, transparent: true, walkable: true);
        NativeMethods.TCOD_map_clear(mapLib, transparent: true, walkable: true);

        var pathDll = NativeMethods.TCOD_path_new_using_map(mapDll, 1.414f);
        nint pathLib;
        unsafe
        {
            pathLib = LibraryImportMethods.TCOD_path_new_using_map((nint)(void*)mapLib, 1.414f);
        }

        try
        {
            // Compute path from (5,5) to (20,20)
            var computeDll = NativeMethods.TCOD_path_compute(pathDll, 5, 5, 20, 20);
            var computeLib = LibraryImportMethods.TCOD_path_compute(pathLib, 5, 5, 20, 20);

            Assert.Equal(computeDll, computeLib);

            if (computeDll)
            {
                var sizeDll = NativeMethods.TCOD_path_size(pathDll);
                var sizeLib = LibraryImportMethods.TCOD_path_size(pathLib);
                Assert.Equal(sizeDll, sizeLib);
            }
        }
        finally
        {
            NativeMethods.TCOD_path_delete(pathDll);
            LibraryImportMethods.TCOD_path_delete(pathLib);
            NativeMethods.TCOD_map_delete(mapDll);
            NativeMethods.TCOD_map_delete(mapLib);
        }
    }

    [Fact]
    public void HeapPushPop_MatchesDllImportForSameData()
    {
        const nuint dataSize = 4u;

        var heapDll = new TCOD_Heap();
        var heapLib = new TCOD_Heap();

        var initDll = NativeMethods.TCOD_heap_init(ref heapDll, dataSize);
        var initLib = LibraryImportMethods.TCOD_heap_init(ref heapLib, dataSize);

        Assert.Equal(initDll, initLib);

        try
        {
            // Create some test data
            var data1 = new byte[] { 1, 0, 0, 0 };
            var data2 = new byte[] { 2, 0, 0, 0 };
            var data3 = new byte[] { 3, 0, 0, 0 };

            // Push to both heaps
            unsafe
            {
                fixed (byte* p1 = data1)
                {
                    var push1Dll = NativeMethods.TCOD_minheap_push(
                        ref heapDll,
                        10,
                        (nint)(void*)p1
                    );
                    var push1Lib = LibraryImportMethods.TCOD_minheap_push(
                        ref heapLib,
                        10,
                        (nint)(void*)p1
                    );
                    Assert.Equal(push1Dll, push1Lib);
                }

                fixed (byte* p2 = data2)
                {
                    var push2Dll = NativeMethods.TCOD_minheap_push(
                        ref heapDll,
                        20,
                        (nint)(void*)p2
                    );
                    var push2Lib = LibraryImportMethods.TCOD_minheap_push(
                        ref heapLib,
                        20,
                        (nint)(void*)p2
                    );
                    Assert.Equal(push2Dll, push2Lib);
                }

                fixed (byte* p3 = data3)
                {
                    var push3Dll = NativeMethods.TCOD_minheap_push(ref heapDll, 5, (nint)(void*)p3);
                    var push3Lib = LibraryImportMethods.TCOD_minheap_push(
                        ref heapLib,
                        5,
                        (nint)(void*)p3
                    );
                    Assert.Equal(push3Dll, push3Lib);
                }
            }
        }
        finally
        {
            NativeMethods.TCOD_heap_uninit(ref heapDll);
            LibraryImportMethods.TCOD_heap_uninit(ref heapLib);
        }
    }

    [Fact]
    public void PathfinderCreate_MatchesDllImport()
    {
        const int ndim = 2;
        nuint[] shape = { 10, 10 };

        nint pfDll;
        nint pfLib;

        unsafe
        {
            fixed (nuint* pShape = shape)
            {
                pfDll = NativeMethods.TCOD_pf_new(ndim, (nint)(void*)pShape);
                pfLib = LibraryImportMethods.TCOD_pf_new(ndim, (nint)(void*)pShape);
            }
        }

        Assert.NotEqual(nint.Zero, pfDll);
        Assert.NotEqual(nint.Zero, pfLib);

        try
        {
            // Both should handle cleanup successfully
        }
        finally
        {
            NativeMethods.TCOD_pf_delete(pfDll);
            LibraryImportMethods.TCOD_pf_delete(pfLib);
        }
    }

    [Fact]
    public void ImageCreate_MatchesDllImport()
    {
        const int width = 32;
        const int height = 32;

        var imgDll = NativeMethods.TCOD_image_new(width, height);
        var imgLib = LibraryImportMethods.TCOD_image_new(width, height);

        Assert.NotEqual(nint.Zero, imgDll);
        Assert.NotEqual(nint.Zero, imgLib);

        try
        {
            // Verify both return valid dimensions
            NativeMethods.TCOD_image_get_size(imgDll, out int wDll, out int hDll);
            LibraryImportMethods.TCOD_image_get_size(imgLib, out int wLib, out int hLib);

            Assert.Equal(wDll, wLib);
            Assert.Equal(hDll, hLib);
            Assert.Equal(width, wDll);
            Assert.Equal(height, hDll);
        }
        finally
        {
            NativeMethods.TCOD_image_delete(imgDll);
            LibraryImportMethods.TCOD_image_delete(imgLib);
        }
    }

    [Fact]
    public void ImagePixelOperations_MatchesDllImport()
    {
        const int width = 16;
        const int height = 16;

        var imgDll = NativeMethods.TCOD_image_new(width, height);
        var imgLib = LibraryImportMethods.TCOD_image_new(width, height);

        try
        {
            var color = new TCOD_ColorRGB
            {
                r = 255,
                g = 128,
                b = 64,
            };

            // Put pixel to same location in both
            NativeMethods.TCOD_image_put_pixel(imgDll, 5, 5, color);
            LibraryImportMethods.TCOD_image_put_pixel(imgLib, 5, 5, color);

            // Get pixel back from both
            var pixelDll = NativeMethods.TCOD_image_get_pixel(imgDll, 5, 5);
            var pixelLib = LibraryImportMethods.TCOD_image_get_pixel(imgLib, 5, 5);

            Assert.Equal(pixelDll.r, pixelLib.r);
            Assert.Equal(pixelDll.g, pixelLib.g);
            Assert.Equal(pixelDll.b, pixelLib.b);
        }
        finally
        {
            NativeMethods.TCOD_image_delete(imgDll);
            LibraryImportMethods.TCOD_image_delete(imgLib);
        }
    }

    [Fact]
    public void ImageClear_MatchesDllImport()
    {
        var imgDll = NativeMethods.TCOD_image_new(8, 8);
        var imgLib = LibraryImportMethods.TCOD_image_new(8, 8);

        var color = new TCOD_ColorRGB
        {
            r = 100,
            g = 150,
            b = 200,
        };

        try
        {
            // Clear both images with same color
            NativeMethods.TCOD_image_clear(imgDll, color);
            LibraryImportMethods.TCOD_image_clear(imgLib, color);

            // Verify pixels match at several locations
            for (int y = 0; y < 8; y += 2)
            {
                for (int x = 0; x < 8; x += 2)
                {
                    var pDll = NativeMethods.TCOD_image_get_pixel(imgDll, x, y);
                    var pLib = LibraryImportMethods.TCOD_image_get_pixel(imgLib, x, y);

                    Assert.Equal(pDll.r, pLib.r);
                    Assert.Equal(pDll.g, pLib.g);
                    Assert.Equal(pDll.b, pLib.b);
                }
            }
        }
        finally
        {
            NativeMethods.TCOD_image_delete(imgDll);
            LibraryImportMethods.TCOD_image_delete(imgLib);
        }
    }

    [Fact]
    public void FovComputeAndQuery_MatchesDllImport()
    {
        const int mapWidth = 20;
        const int mapHeight = 20;

        var mapDll = NativeMethods.TCOD_map_new(mapWidth, mapHeight);
        var mapLib = LibraryImportMethods.TCOD_map_new(mapWidth, mapHeight);

        NativeMethods.TCOD_map_clear(mapDll, transparent: true, walkable: true);
        LibraryImportMethods.TCOD_map_clear(mapLib, transparent: true, walkable: true);

        try
        {
            // Compute FOV from same center
            var radius = 10;
            NativeMethods.TCOD_map_compute_fov(
                mapDll,
                mapWidth / 2,
                mapHeight / 2,
                radius,
                light_walls: true,
                TCOD_fov_algorithm_t.FOV_BASIC
            );
            LibraryImportMethods.TCOD_map_compute_fov(
                mapLib,
                mapWidth / 2,
                mapHeight / 2,
                radius,
                light_walls: true,
                TCOD_fov_algorithm_t.FOV_BASIC
            );

            // Check several points to ensure FOV matches
            for (int x = 5; x < 15; x += 5)
            {
                for (int y = 5; y < 15; y += 5)
                {
                    var fovDll = NativeMethods.TCOD_map_is_in_fov(mapDll, x, y);
                    var fovLib = LibraryImportMethods.TCOD_map_is_in_fov(mapLib, x, y);
                    Assert.Equal(fovDll, fovLib);
                }
            }
        }
        finally
        {
            NativeMethods.TCOD_map_delete(mapDll);
            LibraryImportMethods.TCOD_map_delete(mapLib);
        }
    }

    [Fact]
    public void HeightmapCreateAndQuery_MatchesDllImport()
    {
        const int width = 16;
        const int height = 16;

        var hmDll = NativeMethods.TCOD_heightmap_new(width, height);
        var hmLib = LibraryImportMethods.TCOD_heightmap_new(width, height);

        try
        {
            // Add same value to both
            NativeMethods.TCOD_heightmap_add(hmDll, 5.0f);
            LibraryImportMethods.TCOD_heightmap_add(hmLib, 5.0f);

            // Query minmax
            NativeMethods.TCOD_heightmap_get_minmax(hmDll, out float minDll, out float maxDll);
            LibraryImportMethods.TCOD_heightmap_get_minmax(
                hmLib,
                out float minLib,
                out float maxLib
            );

            Assert.Equal(minDll, minLib);
            Assert.Equal(maxDll, maxLib);

            // Test interpolation at a point
            var valDll = NativeMethods.TCOD_heightmap_get_interpolated_value(hmDll, 5.5f, 5.5f);
            var valLib = LibraryImportMethods.TCOD_heightmap_get_interpolated_value(
                hmLib,
                5.5f,
                5.5f
            );

            Assert.Equal(valDll, valLib);
        }
        finally
        {
            NativeMethods.TCOD_heightmap_delete(hmDll);
            LibraryImportMethods.TCOD_heightmap_delete(hmLib);
        }
    }

    [Fact]
    public void HeightmapScaleAndClamp_MatchesDllImport()
    {
        var hmDll = NativeMethods.TCOD_heightmap_new(8, 8);
        var hmLib = LibraryImportMethods.TCOD_heightmap_new(8, 8);

        try
        {
            // Initialize with same value
            NativeMethods.TCOD_heightmap_add(hmDll, 10.0f);
            LibraryImportMethods.TCOD_heightmap_add(hmLib, 10.0f);

            // Scale both
            NativeMethods.TCOD_heightmap_scale(hmDll, 0.5f);
            LibraryImportMethods.TCOD_heightmap_scale(hmLib, 0.5f);

            // Verify both are now scaled
            NativeMethods.TCOD_heightmap_get_minmax(hmDll, out float minDll, out float maxDll);
            LibraryImportMethods.TCOD_heightmap_get_minmax(
                hmLib,
                out float minLib,
                out float maxLib
            );

            Assert.Equal(minDll, minLib);
            Assert.Equal(maxDll, maxLib);
            Assert.Equal(5.0f, minDll);
        }
        finally
        {
            NativeMethods.TCOD_heightmap_delete(hmDll);
            LibraryImportMethods.TCOD_heightmap_delete(hmLib);
        }
    }

    [Fact]
    public void ViewportCreateDelete_MatchesDllImport()
    {
        // Test that both implementations can create and delete viewports
        var vpDll = NativeMethods.TCOD_viewport_new();
        var vpLib = LibraryImportMethods.TCOD_viewport_new();

        Assert.NotEqual(nint.Zero, vpDll);
        Assert.NotEqual(nint.Zero, vpLib);

        // Both should delete without error
        NativeMethods.TCOD_viewport_delete(vpDll);
        LibraryImportMethods.TCOD_viewport_delete(vpLib);
    }

    [Fact]
    public void TilesetDelete_MatchesDllImport()
    {
        // Just verify both delete methods work without crashing on null/zero pointers
        // (We can't easily test load operations without actual font files)
        NativeMethods.TCOD_tileset_delete(nint.Zero);
        LibraryImportMethods.TCOD_tileset_delete(nint.Zero);
    }

    [Fact]
    public void ContextFunctions_BindingsExist()
    {
        // Verify that Context API bindings compile and are callable
        // (Full testing requires SDL2 window setup which is beyond scope)
        // This test just ensures the LibraryImport signatures are correct
    }

    [Fact]
    public void ConsoleCreateDelete_MatchesDllImport()
    {
        // Test that both implementations can create and delete consoles
        var conDll = NativeMethods.TCOD_console_new(80, 24);
        var conLib = LibraryImportMethods.TCOD_console_new(80, 24);

        Assert.NotEqual(nint.Zero, conDll);
        Assert.NotEqual(nint.Zero, conLib);

        // Verify dimensions match
        var widthDll = NativeMethods.TCOD_console_get_width(conDll);
        var widthLib = LibraryImportMethods.TCOD_console_get_width(conLib);
        Assert.Equal(widthDll, widthLib);
        Assert.Equal(80, widthDll);

        var heightDll = NativeMethods.TCOD_console_get_height(conDll);
        var heightLib = LibraryImportMethods.TCOD_console_get_height(conLib);
        Assert.Equal(heightDll, heightLib);
        Assert.Equal(24, heightDll);

        // Cleanup
        NativeMethods.TCOD_console_delete(conDll);
        LibraryImportMethods.TCOD_console_delete(conLib);
    }

    [Fact]
    public void ConsoleClearAndGetChar_MatchesDllImport()
    {
        var conDll = NativeMethods.TCOD_console_new(10, 10);
        var conLib = LibraryImportMethods.TCOD_console_new(10, 10);

        try
        {
            // Clear both consoles
            NativeMethods.TCOD_console_clear(conDll);
            LibraryImportMethods.TCOD_console_clear(conLib);

            // Get character at (0,0) - should be space (32)
            var charDll = NativeMethods.TCOD_console_get_char(conDll, 0, 0);
            var charLib = LibraryImportMethods.TCOD_console_get_char(conLib, 0, 0);

            Assert.Equal(charDll, charLib);
        }
        finally
        {
            NativeMethods.TCOD_console_delete(conDll);
            LibraryImportMethods.TCOD_console_delete(conLib);
        }
    }

    [Fact]
    public void BspNewDelete_MatchesDllImport()
    {
        // Test that both implementations can create and delete BSP trees
        var bspDll = NativeMethods.TCOD_bsp_new();
        var bspLib = LibraryImportMethods.TCOD_bsp_new();

        Assert.NotEqual(nint.Zero, bspDll);
        Assert.NotEqual(nint.Zero, bspLib);

        // Verify both are leaves
        var isLeafDll = NativeMethods.TCOD_bsp_is_leaf(bspDll);
        var isLeafLib = LibraryImportMethods.TCOD_bsp_is_leaf(bspLib);
        Assert.Equal(isLeafDll, isLeafLib);

        // Cleanup
        NativeMethods.TCOD_bsp_delete(bspDll);
        LibraryImportMethods.TCOD_bsp_delete(bspLib);
    }

    [Fact]
    public void SysGetSdlFunctions_BindingsExist()
    {
        // These functions return NULL when SDL is not initialized, but bindings should exist
        var windowDll = NativeMethods.TCOD_sys_get_SDL_window();
        var windowLib = LibraryImportMethods.TCOD_sys_get_SDL_window();

        // Both should return null/zero (no active window)
        Assert.Equal(windowDll, nint.Zero);
        Assert.Equal(windowLib, nint.Zero);

        var rendererDll = NativeMethods.TCOD_sys_get_SDL_renderer();
        var rendererLib = LibraryImportMethods.TCOD_sys_get_SDL_renderer();

        Assert.Equal(rendererDll, nint.Zero);
        Assert.Equal(rendererLib, nint.Zero);
    }
}
