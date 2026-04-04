using System.Reflection;
using static libtcod.Interop.libtcod;

namespace libtcod_net.Tests;

public class ColorPaletteTests
{
    private static readonly string[] BaseColorNames =
    {
        "red",
        "flame",
        "orange",
        "amber",
        "yellow",
        "lime",
        "chartreuse",
        "green",
        "sea",
        "turquoise",
        "cyan",
        "sky",
        "azure",
        "blue",
        "han",
        "violet",
        "purple",
        "fuchsia",
        "magenta",
        "pink",
        "crimson",
    };

    [Fact]
    public void TcodColors_HasExpectedShape()
    {
        Assert.Equal(2, TCOD_ColorRGB.TCOD_colors.Rank);
        Assert.Equal(21, TCOD_ColorRGB.TCOD_colors.GetLength(0));
        Assert.Equal(8, TCOD_ColorRGB.TCOD_colors.GetLength(1));
    }

    [Fact]
    public void TcodColors_NormalColumnMatchesBaseColors()
    {
        for (int i = 0; i < BaseColorNames.Length; ++i)
        {
            var expected = GetStaticColor($"TCOD_{BaseColorNames[i]}");
            Assert.Equal(expected, TCOD_ColorRGB.TCOD_colors[i, 4]);
        }
    }

    [Fact]
    public void TcodColors_ColumnsMatchExpectedNamingConvention()
    {
        var prefixes = new[]
        {
            "desaturated",
            "lightest",
            "lighter",
            "light",
            "",
            "dark",
            "darker",
            "darkest",
        };

        for (int row = 0; row < BaseColorNames.Length; ++row)
        {
            for (int col = 0; col < prefixes.Length; ++col)
            {
                var prefix = prefixes[col];
                var fieldName = string.IsNullOrEmpty(prefix)
                    ? $"TCOD_{BaseColorNames[row]}"
                    : $"TCOD_{prefix}_{BaseColorNames[row]}";

                var expected = GetStaticColor(fieldName);
                Assert.Equal(expected, TCOD_ColorRGB.TCOD_colors[row, col]);
            }
        }
    }

    [Fact]
    public void GreyAndGrayAliases_Match()
    {
        Assert.Equal(TCOD_ColorRGB.TCOD_darkest_grey, TCOD_ColorRGB.TCOD_darkest_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_darker_grey, TCOD_ColorRGB.TCOD_darker_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_dark_grey, TCOD_ColorRGB.TCOD_dark_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_grey, TCOD_ColorRGB.TCOD_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_light_grey, TCOD_ColorRGB.TCOD_light_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_lighter_grey, TCOD_ColorRGB.TCOD_lighter_gray);
        Assert.Equal(TCOD_ColorRGB.TCOD_lightest_grey, TCOD_ColorRGB.TCOD_lightest_gray);
    }

    private static TCOD_ColorRGB GetStaticColor(string name)
    {
        var field = typeof(TCOD_ColorRGB).GetField(name, BindingFlags.Public | BindingFlags.Static);
        Assert.NotNull(field);
        Assert.Equal(typeof(TCOD_ColorRGB), field!.FieldType);
        return (TCOD_ColorRGB)field.GetValue(null)!;
    }
}
