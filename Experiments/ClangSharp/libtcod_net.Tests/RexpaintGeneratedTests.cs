using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class RexpaintGeneratedTests
{
    [Fact]
    public void SaveAndLoadXp_RoundTripsGeneratedConsoleFunctions()
    {
        var console1 = TCOD_console_new(3, 2);
        var console2 = TCOD_console_new(3, 2);
        Assert.False(console1 == null);
        Assert.False(console2 == null);

        var tempPath = Path.Combine(Path.GetTempPath(), $"libtcod_net_{Guid.NewGuid():N}.xp");

        try
        {
            FillConsole(console1, '!');
            FillConsole(console2, '@');

            var consoles = new TCOD_Console*[] { console1, console2 };
            TCOD_Error saveResult;
            fixed (TCOD_Console** c = &consoles[0])
                saveResult = TCOD_save_xp(2, c, tempPath, 0);
            Assert.True(saveResult >= 0);
            Assert.True(File.Exists(tempPath));

            var loaded = new TCOD_Console*[2];
            int loadedCount;
            fixed (TCOD_Console** c = &loaded[0])
                loadedCount = TCOD_load_xp(tempPath, loaded.Length, c);
            Assert.Equal(2, loadedCount);
            Assert.False(loaded[0] == null);
            Assert.False(loaded[1] == null);

            try
            {
                AssertConsoleCell(loaded[0], 2, 1, '!', 2, 1, 0);
                AssertConsoleCell(loaded[1], 2, 1, '@', 2, 1, 0);
            }
            finally
            {
                foreach (var console in loaded)
                {
                    if (console != null)
                    {
                        TCOD_console_delete(console);
                    }
                }
            }
        }
        finally
        {
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }

            if (console2 != null)
            {
                TCOD_console_delete(console2);
            }

            if (console1 != null)
            {
                TCOD_console_delete(console1);
            }
        }
    }

    [Fact]
    public void LoadXp_FixtureMatchesNativeAssertions()
    {
        var path = NativeTestAssetPaths.NativeData("rexpaint", "test.xp");
        var loaded = new TCOD_Console*[1];
        int loadedCount;
        fixed (TCOD_Console** c = &loaded[0])
            loadedCount = TCOD_load_xp(path, loaded.Length, c);
        Assert.Equal(1, loadedCount);
        Assert.False(loaded[0] == null);

        try
        {
            Assert.Equal('T', TCOD_console_get_char(loaded[0], 0, 0));
            Assert.Equal('e', TCOD_console_get_char(loaded[0], 1, 0));
            Assert.Equal('s', TCOD_console_get_char(loaded[0], 2, 0));
            Assert.Equal('t', TCOD_console_get_char(loaded[0], 3, 0));

            Assert.Equal(
                new TCOD_ColorRGB
                {
                    r = 255,
                    g = 0,
                    b = 0,
                },
                TCOD_console_get_char_background(loaded[0], 0, 1)
            );
            Assert.Equal(
                new TCOD_ColorRGB
                {
                    r = 0,
                    g = 255,
                    b = 0,
                },
                TCOD_console_get_char_background(loaded[0], 1, 1)
            );
            Assert.Equal(
                new TCOD_ColorRGB
                {
                    r = 0,
                    g = 0,
                    b = 255,
                },
                TCOD_console_get_char_background(loaded[0], 2, 1)
            );
            Assert.Equal(
                TCOD_ColorRGB.TCOD_black,
                TCOD_console_get_char_background(loaded[0], 3, 1)
            );
        }
        finally
        {
            TCOD_console_delete(loaded[0]);
        }
    }

    private static void FillConsole(TCOD_Console* console, int ch)
    {
        var bg = new TCOD_ColorRGB
        {
            r = 10,
            g = 20,
            b = 30,
        };
        for (int y = 0; y < 2; ++y)
        {
            for (int x = 0; x < 3; ++x)
            {
                var c = new TCOD_ColorRGB
                {
                    r = (byte)x,
                    g = (byte)y,
                    b = 0,
                };
                TCOD_console_put_rgb(console, x, y, ch, &c, &bg, TCOD_bkgnd_flag_t.TCOD_BKGND_SET);
            }
        }
    }

    private static void AssertConsoleCell(
        TCOD_Console* console,
        int x,
        int y,
        int ch,
        byte fgR,
        byte fgG,
        byte fgB
    )
    {
        Assert.Equal(ch, TCOD_console_get_char(console, x, y));
        var foreground = TCOD_console_get_char_foreground(console, x, y);
        Assert.Equal(fgR, foreground.r);
        Assert.Equal(fgG, foreground.g);
        Assert.Equal(fgB, foreground.b);

        var background = TCOD_console_get_char_background(console, x, y);
        Assert.Equal((byte)10, background.r);
        Assert.Equal((byte)20, background.g);
        Assert.Equal((byte)30, background.b);
    }
}
