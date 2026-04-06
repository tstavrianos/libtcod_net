using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_dice_t
    {
        public int nb_rolls;

        public int nb_faces;

        public float multiplier;

        public float addsub;
    }

    public enum TCOD_random_algo_t
    {
        TCOD_RNG_MT,
        TCOD_RNG_CMWC,
    }

    public enum TCOD_distribution_t
    {
        TCOD_DISTRIBUTION_LINEAR,
        TCOD_DISTRIBUTION_GAUSSIAN,
        TCOD_DISTRIBUTION_GAUSSIAN_RANGE,
        TCOD_DISTRIBUTION_GAUSSIAN_INVERSE,
        TCOD_DISTRIBUTION_GAUSSIAN_RANGE_INVERSE,
    }

    public partial struct TCOD_Random_MT_CMWC
    {
        public TCOD_random_algo_t algorithm;

        public TCOD_distribution_t distribution;

        [NativeTypeName("uint32_t[624]")]
        public _mt_e__FixedBuffer mt;

        public int cur_mt;

        [NativeTypeName("uint32_t[4096]")]
        public _Q_e__FixedBuffer Q;

        [NativeTypeName("uint32_t")]
        public uint c;

        public int cur;

        [InlineArray(624)]
        public partial struct _mt_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(4096)]
        public partial struct _Q_e__FixedBuffer
        {
            public uint e0;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct TCOD_Random
    {
        [FieldOffset(0)]
        public TCOD_random_algo_t algorithm;

        [FieldOffset(0)]
        [NativeTypeName("struct TCOD_Random_MT_CMWC")]
        public TCOD_Random_MT_CMWC mt_cmwc;
    }
}

