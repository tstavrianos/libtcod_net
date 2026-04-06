using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Random* TCOD_random_get_instance();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Random* TCOD_random_new(TCOD_random_algo_t algo);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Random* TCOD_random_save(TCOD_Random* mersenne);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_random_restore(TCOD_Random* mersenne, TCOD_Random* backup);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Random* TCOD_random_new_from_seed(TCOD_random_algo_t algo, [NativeTypeName("uint32_t")] uint seed);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_random_delete(TCOD_Random* mersenne);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_random_set_distribution(TCOD_Random* mersenne, TCOD_distribution_t distribution);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_random_get_int(TCOD_Random* mersenne, int min, int max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_random_get_float(TCOD_Random* mersenne, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double TCOD_random_get_double(TCOD_Random* mersenne, double min, double max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_random_get_int_mean(TCOD_Random* mersenne, int min, int max, int mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_random_get_float_mean(TCOD_Random* mersenne, float min, float max, float mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double TCOD_random_get_double_mean(TCOD_Random* mersenne, double min, double max, double mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_dice_t TCOD_random_dice_new([NativeTypeName("const char *")] sbyte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_random_dice_roll(TCOD_Random* mersenne, TCOD_dice_t dice);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_random_dice_roll_s(TCOD_Random* mersenne, [NativeTypeName("const char *")] sbyte* s);
    }
}

