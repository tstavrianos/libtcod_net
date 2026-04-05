using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public class TilesetGeneratedTests
{
    [Fact]
    public void TilesetLoad_LoadsNativePngFixtures()
    {
        var charmapHandle = GCHandle.Alloc(TCOD_Charmaps.TCOD_CHARMAP_CP437, GCHandleType.Pinned);
        nint first = nint.Zero;
        nint second = nint.Zero;

        try
        {
            first = TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "terminal8x8_gs_ro.png"),
                16,
                16,
                TCOD_Charmaps.TCOD_CHARMAP_CP437.Length,
                charmapHandle.AddrOfPinnedObject()
            );
            Assert.NotEqual(nint.Zero, first);

            second = TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "dejavu8x8_gs_tc.png"),
                32,
                8,
                TCOD_Charmaps.TCOD_CHARMAP_CP437.Length,
                charmapHandle.AddrOfPinnedObject()
            );
            Assert.NotEqual(nint.Zero, second);
        }
        finally
        {
            if (second != nint.Zero)
            {
                TCOD_tileset_delete(second);
            }

            if (first != nint.Zero)
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
        Assert.NotEqual(nint.Zero, first);

        var second = TCOD_load_bdf(NativeTestAssetPaths.NativeData("fonts", "Tamzen5x9r.bdf"));
        Assert.NotEqual(nint.Zero, second);

        TCOD_tileset_delete(first);
        TCOD_tileset_delete(second);
    }
}
