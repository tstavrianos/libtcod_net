using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_random_get_instance();

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_random_new(TCOD_random_algo_t algo);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_random_save(nint mersenne);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_random_restore(nint mersenne, nint backup);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_random_new_from_seed(TCOD_random_algo_t algo, uint seed);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_random_delete(nint mersenne);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_random_set_distribution(
        nint mersenne,
        TCOD_distribution_t distribution
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_random_get_int(nint mersenne, int min, int max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_random_get_float(nint mersenne, float min, float max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double TCOD_random_get_double(nint mersenne, double min, double max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_random_get_int_mean(nint mersenne, int min, int max, int mean);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_random_get_float_mean(
        nint mersenne,
        float min,
        float max,
        float mean
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern double TCOD_random_get_double_mean(
        nint mersenne,
        double min,
        double max,
        double mean
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_dice_t TCOD_random_dice_new(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string s
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_random_dice_roll(nint mersenne, [In] TCOD_dice_t dice);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_random_dice_roll_s(
        nint mersenne,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string s
    );
}
