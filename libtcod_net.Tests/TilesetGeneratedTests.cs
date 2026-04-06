using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class TilesetGeneratedTests
{
    [Fact]
    public void TilesetLoad_LoadsNativePngFixtures()
    {
        var charmapHandle = GCHandle.Alloc(TCOD_CHARMAP_CP437, GCHandleType.Pinned);
        TCOD_Tileset* first = null;
        TCOD_Tileset* second = null;
        using var allocator = new ArenaNativeAllocator(1024);
        var pathPtr1 = CString.FromString(
            allocator,
            NativeTestAssetPaths.NativeData("fonts", "terminal8x8_gs_ro.png")
        );
        var pathPtr2 = CString.FromString(
            allocator,
            NativeTestAssetPaths.NativeData("fonts", "dejavu8x8_gs_tc.png")
        );
        try
        {
            first = TCOD_tileset_load(
                pathPtr1,
                16,
                16,
                TCOD_CHARMAP_CP437.Length,
                (int*)charmapHandle.AddrOfPinnedObject().ToPointer()
            );
            Assert.False(first == null);

            second = TCOD_tileset_load(
                pathPtr2,
                32,
                8,
                TCOD_CHARMAP_CP437.Length,
                (int*)charmapHandle.AddrOfPinnedObject().ToPointer()
            );
            Assert.False(second == null);
        }
        finally
        {
            allocator.Free(pathPtr1);
            allocator.Free(pathPtr2);
            if (second != null)
            {
                TCOD_tileset_delete(second);
            }

            if (first != null)
            {
                TCOD_tileset_delete(first);
            }

            charmapHandle.Free();
        }
    }

    [Fact]
    public void LoadBdf_LoadsNativeBdfFixtures()
    {
        using var allocator = new ArenaNativeAllocator(1024);
        var pathPtr1 = CString.FromString(
            allocator,
            NativeTestAssetPaths.NativeData("fonts", "ucs-fonts", "4x6.bdf")
        );
        var first = TCOD_load_bdf(pathPtr1);
        allocator.Free(pathPtr1);
        Assert.False(first == null);

        var pathPtr2 = CString.FromString(
            allocator,
            NativeTestAssetPaths.NativeData("fonts", "Tamzen5x9r.bdf")
        );
        var second = TCOD_load_bdf(pathPtr2);
        allocator.Free(pathPtr2);
        Assert.False(second == null);

        TCOD_tileset_delete(first);
        TCOD_tileset_delete(second);
    }
}
