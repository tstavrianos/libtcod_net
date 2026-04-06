using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public class PrintingGeneratedTests
{
    [Fact]
    public void ConsolePrintnRect_ZeroRectAlignmentsMatchNativeExpectation()
    {
        var console = TCOD_console_new(12, 1);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            FillConsole(console, 12, 1, '.');

            var len = (nuint)3;
            TCOD_console_printn_rect(
                console,
                0,
                0,
                0,
                0,
                len,
                "123",
                nint.Zero,
                nint.Zero,
                TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
                TCOD_alignment_t.TCOD_LEFT
            );
            TCOD_console_printn_rect(
                console,
                0,
                0,
                0,
                0,
                len,
                "123",
                nint.Zero,
                nint.Zero,
                TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
                TCOD_alignment_t.TCOD_CENTER
            );
            TCOD_console_printn_rect(
                console,
                0,
                0,
                0,
                0,
                len,
                "123",
                nint.Zero,
                nint.Zero,
                TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
                TCOD_alignment_t.TCOD_RIGHT
            );

            Assert.Equal("123.123..123", ConsoleRowToString(console, 12, 0));
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }

    [Fact]
    public void PrintParamsRgb_PositionsCharactersAsInNativeTest()
    {
        var console = TCOD_console_new(4, 1);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            var @params = default(TCOD_PrintParamsRGB);
            @params.x = 1;
            @params.y = 0;
            @params.flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE;
            @params.alignment = TCOD_alignment_t.TCOD_LEFT;

            TCOD_printn_rgb(console, @params, 1, "A");
            Assert.Equal(" A  ", ConsoleRowToString(console, 4, 0));

            @params.x = 2;
            TCOD_printn_rgb(console, @params, 1, "B");
            Assert.Equal(" AB ", ConsoleRowToString(console, 4, 0));
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }

    private static void FillConsole(nint console, int width, int height, int ch)
    {
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                TCOD_console_put_rgb(
                    console,
                    x,
                    y,
                    ch,
                    TCOD_ColorRGB.TCOD_white,
                    TCOD_ColorRGB.TCOD_black,
                    TCOD_bkgnd_flag_t.TCOD_BKGND_SET
                );
            }
        }
    }

    private static string ConsoleRowToString(nint console, int width, int row)
    {
        var chars = new char[width];
        for (int x = 0; x < width; ++x)
        {
            chars[x] = (char)TCOD_console_get_char(console, x, row);
        }

        return new string(chars);
    }
}
