using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Pseudorandom number generator
/// </summary>
public sealed unsafe class Random : TCODResource<TCOD_Random>
{
    private Random(TCOD_Random* pointer, bool ownsNativeResource = true)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Random with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
        OwnsNativeResource = ownsNativeResource;
    }

    /// <summary>
    /// Creates a new pseudorandom number generator instance using the specified algorithm.
    /// </summary>
    /// <param name="algorithm">The algorithm to use for the pseudorandom number generator.</param>
    /// <returns>A new Random instance.</returns>
    public static Random Create(TCOD_random_algo_t algorithm = TCOD_random_algo_t.TCOD_RNG_CMWC)
    {
        var p = TCOD_random_new(algorithm);
        ErrorHelper.CheckAndThrow(p);
        return new Random(p);
    }

    /// <summary>
    /// Creates a new pseudorandom number generator instance using the specified algorithm and seed.
    /// </summary>
    /// <param name="seed">The seed to initialize the pseudorandom number generator.</param>
    /// <param name="algorithm">The algorithm to use for the pseudorandom number generator.</param>
    /// <returns>A new Random instance.</returns>
    public static Random Create(
        uint seed,
        TCOD_random_algo_t algorithm = TCOD_random_algo_t.TCOD_RNG_CMWC
    )
    {
        var p = TCOD_random_new_from_seed(algorithm, seed);
        ErrorHelper.CheckAndThrow(p);
        return new Random(p);
    }

    /// <summary>
    /// Gets the global instance of the pseudorandom number generator. This instance is created on demand.
    /// </summary>
    /// <returns>The global Random instance.</returns>
    public static Random Instance()
    {
        var ret = TCOD_random_get_instance();
        ErrorHelper.CheckAndThrow(ret);
        return new Random(ret, false);
    }

    /// <summary>
    /// Saves the current state of the pseudorandom number generator.
    /// </summary>
    /// <returns>A new Random instance representing the saved state.</returns>
    public Random Save()
    {
        var ret = TCOD_random_save(Pointer);
        ErrorHelper.CheckAndThrow(ret);
        return new Random(ret);
    }

    /// <summary>
    /// Restores the state of the pseudorandom number generator from a backup.
    /// </summary>
    /// <param name="backup">The backup Random instance to restore from.</param>
    /// <exception cref="ArgumentNullException">Thrown if the backup is null.</exception>
    public void Restore(Random backup)
    {
        ArgumentNullException.ThrowIfNull(backup);
        TCOD_random_restore(Pointer, backup.Pointer);
    }

    /// <summary>
    /// Sets the distribution type for the pseudorandom number generator. This affects how the random numbers are distributed when generated.
    /// </summary>
    /// <param name="distribution">The distribution type to set.</param>
    public void SetDistribution(TCOD_distribution_t distribution)
    {
        TCOD_random_set_distribution(Pointer, distribution);
    }

    /// <summary>
    /// Generates a random integer within the specified range [min, max].
    /// </summary>
    /// <param name="min">The minimum value (inclusive).</param>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <param name="mean">The mean value (optional, default is 0).</param>
    /// <returns>A random integer within the specified range.</returns>
    public int Next(int min, int max, int mean = 0)
    {
        return mean <= 0
            ? TCOD_random_get_int(Pointer, min, max)
            : TCOD_random_get_int_mean(Pointer, min, max, mean);
    }

    /// <summary>
    /// Generates a random integer within the range [0, max].
    /// </summary>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <returns>A random integer within the specified range.</returns>
    public int Next(int max = int.MaxValue)
    {
        return Next(0, max);
    }

    /// <summary>
    /// Generates a random floating-point number within the specified range [min, max].
    /// </summary>
    /// <param name="min">The minimum value (inclusive).</param>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <param name="mean">The mean value (optional, default is 0).</param>
    /// <returns>A random floating-point number within the specified range.</returns>
    public float NextSingle(float min, float max, float mean = 0)
    {
        return mean <= 0
            ? TCOD_random_get_float(Pointer, min, max)
            : TCOD_random_get_float_mean(Pointer, min, max, mean);
    }

    /// <summary>
    /// Generates a random floating-point number within the range [0, max].
    /// </summary>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <param name="mean">The mean value (optional, default is 0).</param>
    /// <returns>A random floating-point number within the specified range.</returns>
    public float NextSingle(float max = 1)
    {
        return NextSingle(0, max);
    }

    /// <summary>
    /// Generates a random double-precision floating-point number within the specified range [min, max].
    /// </summary>
    /// <param name="min">The minimum value (inclusive).</param>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <param name="mean">The mean value (optional, default is 0).</param>
    /// <returns>A random double-precision floating-point number within the specified range.</returns>
    public double NextDouble(double min, double max, double mean = 0)
    {
        return mean <= 0
            ? TCOD_random_get_double(Pointer, min, max)
            : TCOD_random_get_double_mean(Pointer, min, max, mean);
    }

    /// <summary>
    /// Generates a random double-precision floating-point number within the range [0, max].
    /// </summary>
    /// <param name="max">The maximum value (inclusive).</param>
    /// <returns>A random double-precision floating-point number within the specified range.</returns>
    public double NextDouble(double max = 1)
    {
        return NextDouble(0, max);
    }

    /// <summary>
    /// Rolls the specified dice.
    /// </summary>
    /// <param name="dice">The dice to roll.</param>
    /// <returns>The result of the dice roll.</returns>
    public int Roll(TCOD_dice_t dice)
    {
        return TCOD_random_dice_roll(Pointer, dice);
    }

    /// <summary>
    /// Rolls the specified dice using a string representation.
    /// </summary>
    /// <param name="dice">The string representation of the dice to roll.</param>
    /// <returns>The result of the dice roll.</returns>
    /// <exception cref="ArgumentException"></exception>
    public int Roll(string dice)
    {
        ArgumentException.ThrowIfNullOrEmpty(dice);
        using var dicePtr = new StringMarshal(dice);
        return TCOD_random_dice_roll_s(Pointer, dicePtr.CStr);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_random_delete(Pointer);
    }
}
