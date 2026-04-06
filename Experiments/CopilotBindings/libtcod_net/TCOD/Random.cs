using System;

namespace libtcod_net.TCOD;

public class Random : TCODResource
{
    private Random(nint pointer, bool ownsNativeResource = true)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Random with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
        OwnsNativeResource = ownsNativeResource;
    }

    public static Random Create(libtcod.TCOD_random_algo_t algorithm)
    {
        var p = libtcod.TCOD_random_new(algorithm);
        ErrorHelper.CheckAndThrow(p);
        return new Random(p);
    }

    public static Random Create(libtcod.TCOD_random_algo_t algorithm, uint seed)
    {
        var p = libtcod.TCOD_random_new_from_seed(algorithm, seed);
        ErrorHelper.CheckAndThrow(p);
        return new Random(p);
    }

    public static Random Instance()
    {
        var ret = libtcod.TCOD_random_get_instance();
        ErrorHelper.CheckAndThrow(ret);
        return new Random(ret, false);
    }

    public Random Save()
    {
        var ret = libtcod.TCOD_random_save(Pointer);
        ErrorHelper.CheckAndThrow(ret);
        return new Random(ret);
    }

    public void Restore(Random backup)
    {
        ArgumentNullException.ThrowIfNull(backup);
        libtcod.TCOD_random_restore(Pointer, backup.Pointer);
    }

    public void SetDistribution(libtcod.TCOD_distribution_t distribution)
    {
        libtcod.TCOD_random_set_distribution(Pointer, distribution);
    }

    public int Next(int min, int max)
    {
        return libtcod.TCOD_random_get_int(Pointer, min, max);
    }

    public int Next(int max = int.MaxValue)
    {
        return Next(0, max);
    }

    public float NextSingle(float min, float max)
    {
        return libtcod.TCOD_random_get_float(Pointer, min, max);
    }

    public float NextSingle(float max = 1)
    {
        return NextSingle(0, max);
    }

    public double NextDouble(double min, double max)
    {
        return libtcod.TCOD_random_get_double(Pointer, min, max);
    }

    public double NextDouble(double max = 1)
    {
        return NextDouble(0, max);
    }

    public int NextMean(int min, int max, int mean)
    {
        return libtcod.TCOD_random_get_int_mean(Pointer, min, max, mean);
    }

    public float NextSingleMean(float min, float max, float mean)
    {
        return libtcod.TCOD_random_get_float_mean(Pointer, min, max, mean);
    }

    public double NextDoubleMean(double min, double max, double mean)
    {
        return libtcod.TCOD_random_get_double_mean(Pointer, min, max, mean);
    }

    public int Roll(libtcod.TCOD_dice_t dice)
    {
        return libtcod.TCOD_random_dice_roll(Pointer, dice);
    }

    public int Roll(string dice)
    {
        ArgumentException.ThrowIfNullOrEmpty(dice);
        return libtcod.TCOD_random_dice_roll_s(Pointer, dice);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_random_delete(Pointer);
    }
}
