using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class TilesetGeneratedTests
{
    [Fact]
    public void TilesetLoad_LoadsNativePngFixtures()
    {
        var charmapHandle = GCHandle.Alloc(TCOD_Charmaps.TCOD_CHARMAP_CP437, GCHandleType.Pinned);
        TCOD_Tileset* first = null;
        TCOD_Tileset* second = null;

        try
        {
            first = TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "terminal8x8_gs_ro.png"),
                16,
                16,
                TCOD_Charmaps.TCOD_CHARMAP_CP437.Length,
                (int*)charmapHandle.AddrOfPinnedObject().ToPointer()
            );
            Assert.False(first == null);

            second = TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "dejavu8x8_gs_tc.png"),
                32,
                8,
                TCOD_Charmaps.TCOD_CHARMAP_CP437.Length,
                (int*)charmapHandle.AddrOfPinnedObject().ToPointer()
            );
            Assert.False(second == null);
        }
        finally
        {
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
        var first = TCOD_load_bdf(NativeTestAssetPaths.NativeData("fonts", "ucs-fonts", "4x6.bdf"));
        Assert.False(first == null);

        var second = TCOD_load_bdf(NativeTestAssetPaths.NativeData("fonts", "Tamzen5x9r.bdf"));
        Assert.False(second == null);

        TCOD_tileset_delete(first);
        TCOD_tileset_delete(second);
    }
}
