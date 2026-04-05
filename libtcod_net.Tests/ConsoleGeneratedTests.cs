using System.Text;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public class ConsoleGeneratedTests
{
    [Fact]
    public void ConsoleBasics_MatchNativeExpectations()
    {
        var console = TCOD_console_new(3, 2);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            Assert.Equal(3, TCOD_console_get_width(console));
            Assert.Equal(2, TCOD_console_get_height(console));

            for (int y = 0; y < 2; ++y)
            {
                for (int x = 0; x < 3; ++x)
                {
                    Assert.Equal(0x20, TCOD_console_get_char(console, x, y));
                    Assert.Equal(
                        TCOD_ColorRGB.TCOD_white,
                        TCOD_console_get_char_foreground(console, x, y)
                    );
                    Assert.Equal(
                        TCOD_ColorRGB.TCOD_black,
                        TCOD_console_get_char_background(console, x, y)
                    );
                }
            }
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }

    [Fact]
    public void ConsolePutRgbAndClear_WorkAsExpected()
    {
        var console = TCOD_console_new(2, 1);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            var fg = new TCOD_ColorRGB
            {
                r = 1,
                g = 2,
                b = 3,
            };
            var bg = new TCOD_ColorRGB
            {
                r = 4,
                g = 5,
                b = 6,
            };
            TCOD_console_put_rgb(console, 0, 0, 'A', fg, bg, TCOD_bkgnd_flag_t.TCOD_BKGND_SET);

            Assert.Equal('A', TCOD_console_get_char(console, 0, 0));
            Assert.Equal(fg, TCOD_console_get_char_foreground(console, 0, 0));
            Assert.Equal(bg, TCOD_console_get_char_background(console, 0, 0));

            TCOD_console_clear(console);

            Assert.Equal(0x20, TCOD_console_get_char(console, 0, 0));
            Assert.Equal(TCOD_ColorRGB.TCOD_white, TCOD_console_get_char_foreground(console, 0, 0));
            Assert.Equal(TCOD_ColorRGB.TCOD_black, TCOD_console_get_char_background(console, 0, 0));
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }

    [Fact]
    public void ConsoleDrawRectAndFrameRgb_ModifyExpectedCells()
    {
        var console = TCOD_console_new(8, 8);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            var rectBg = new TCOD_ColorRGB
            {
                r = 255,
                g = 0,
                b = 0,
            };
            var frameFg = new TCOD_ColorRGB
            {
                r = 255,
                g = 255,
                b = 255,
            };
            var frameBg = new TCOD_ColorRGB
            {
                r = 0,
                g = 0,
                b = 64,
            };

            TCOD_console_draw_rect_rgb(
                console,
                2,
                2,
                4,
                3,
                '#',
                TCOD_ColorRGB.TCOD_white,
                rectBg,
                TCOD_bkgnd_flag_t.TCOD_BKGND_SET
            );
            TCOD_console_draw_frame_rgb(
                console,
                1,
                1,
                6,
                5,
                nint.Zero,
                frameFg,
                frameBg,
                TCOD_bkgnd_flag_t.TCOD_BKGND_SET,
                false
            );

            Assert.Equal('#', TCOD_console_get_char(console, 3, 3));
            Assert.Equal(rectBg, TCOD_console_get_char_background(console, 3, 3));
            Assert.NotEqual(0x20, TCOD_console_get_char(console, 1, 1));
            Assert.Equal(frameFg, TCOD_console_get_char_foreground(console, 1, 1));
            Assert.Equal(frameBg, TCOD_console_get_char_background(console, 1, 1));
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }

    [Theory]
    [InlineData("Test", 0x0054, 0x0065, 0x0073, 0x0074)]
    [InlineData("\u2603", 0x2603, 0x0020, 0x0020, 0x0020)]
    [InlineData("\U0001F30D", 0x1F30D, 0x0020, 0x0020, 0x0020)]
    [InlineData("\u00FF", 0x00FF, 0x0020, 0x0020, 0x0020)]
    public void ConsolePrintn_HandlesAsciiAndUnicode(
        string text,
        int ch0,
        int ch1,
        int ch2,
        int ch3
    )
    {
        var console = TCOD_console_new(4, 1);
        Assert.NotEqual(nint.Zero, console);

        try
        {
            var byteCount = (nuint)Encoding.UTF8.GetByteCount(text);
            var written = TCOD_console_printn(
                console,
                0,
                0,
                byteCount,
                text,
                nint.Zero,
                nint.Zero,
                TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
                TCOD_alignment_t.TCOD_LEFT
            );

            Assert.True(written >= 0);
            Assert.Equal(ch0, TCOD_console_get_char(console, 0, 0));
            Assert.Equal(ch1, TCOD_console_get_char(console, 1, 0));
            Assert.Equal(ch2, TCOD_console_get_char(console, 2, 0));
            Assert.Equal(ch3, TCOD_console_get_char(console, 3, 0));
        }
        finally
        {
            TCOD_console_delete(console);
        }
    }
}
