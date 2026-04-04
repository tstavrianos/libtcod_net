using System.Runtime.InteropServices;

namespace libtcod_net.Tests;

public class TilesetGeneratedTests
{
    [Fact]
    public void TilesetLoad_LoadsNativePngFixtures()
    {
        var charmapHandle = GCHandle.Alloc(TCOD_CharMaps.CP437, GCHandleType.Pinned);
        nint first = nint.Zero;
        nint second = nint.Zero;

        try
        {
            first = LibraryImportMethods.TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "terminal8x8_gs_ro.png"),
                16,
                16,
                TCOD_CharMaps.CP437.Length,
                charmapHandle.AddrOfPinnedObject()
            );
            Assert.NotEqual(nint.Zero, first);

            second = LibraryImportMethods.TCOD_tileset_load(
                NativeTestAssetPaths.NativeData("fonts", "dejavu8x8_gs_tc.png"),
                32,
                8,
                TCOD_CharMaps.CP437.Length,
                charmapHandle.AddrOfPinnedObject()
            );
            Assert.NotEqual(nint.Zero, second);
        }
        finally
        {
            if (second != nint.Zero)
            {
                LibraryImportMethods.TCOD_tileset_delete(second);
            }

            if (first != nint.Zero)
            {
                LibraryImportMethods.TCOD_tileset_delete(first);
            }

            charmapHandle.Free();
        }
    }

    [Fact]
    public void LoadBdf_LoadsNativeBdfFixtures()
    {
        var first = LibraryImportMethods.TCOD_load_bdf(
            NativeTestAssetPaths.NativeData("fonts", "ucs-fonts", "4x6.bdf")
        );
        Assert.NotEqual(nint.Zero, first);

        var second = LibraryImportMethods.TCOD_load_bdf(
            NativeTestAssetPaths.NativeData("fonts", "Tamzen5x9r.bdf")
        );
        Assert.NotEqual(nint.Zero, second);

        LibraryImportMethods.TCOD_tileset_delete(first);
        LibraryImportMethods.TCOD_tileset_delete(second);
    }
}
