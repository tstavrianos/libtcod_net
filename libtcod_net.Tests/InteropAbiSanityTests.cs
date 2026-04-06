using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public class InteropAbiSanityTests
{
    [Fact]
    public void ColorStructSizes_AreExpected()
    {
        Assert.Equal(3, Marshal.SizeOf<TCOD_ColorRGB>());
        Assert.Equal(4, Marshal.SizeOf<TCOD_ColorRGBA>());
    }

    [Fact]
    public void DiceStructSize_IsExpected()
    {
        Assert.Equal(16, Marshal.SizeOf<TCOD_dice_t>());
    }

    [Fact]
    public void RandomAndNoiseEnums_HaveExpectedValues()
    {
        Assert.Equal(0, (int)TCOD_random_algo_t.TCOD_RNG_MT);
        Assert.Equal(1, (int)TCOD_random_algo_t.TCOD_RNG_CMWC);

        Assert.Equal(0, (int)TCOD_distribution_t.TCOD_DISTRIBUTION_LINEAR);
        Assert.Equal(1, (int)TCOD_distribution_t.TCOD_DISTRIBUTION_GAUSSIAN);
        Assert.Equal(2, (int)TCOD_distribution_t.TCOD_DISTRIBUTION_GAUSSIAN_RANGE);
        Assert.Equal(3, (int)TCOD_distribution_t.TCOD_DISTRIBUTION_GAUSSIAN_INVERSE);
        Assert.Equal(4, (int)TCOD_distribution_t.TCOD_DISTRIBUTION_GAUSSIAN_RANGE_INVERSE);

        Assert.Equal(0, (int)TCOD_noise_type_t.TCOD_NOISE_DEFAULT);
        Assert.Equal(1, (int)TCOD_noise_type_t.TCOD_NOISE_PERLIN);
        Assert.Equal(2, (int)TCOD_noise_type_t.TCOD_NOISE_SIMPLEX);
        Assert.Equal(4, (int)TCOD_noise_type_t.TCOD_NOISE_WAVELET);
    }
}
