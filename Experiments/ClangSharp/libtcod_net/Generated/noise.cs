using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_noise_type_t
    {
        TCOD_NOISE_PERLIN = 1,
        TCOD_NOISE_SIMPLEX = 2,
        TCOD_NOISE_WAVELET = 4,
        TCOD_NOISE_DEFAULT = 0,
    }

    public unsafe partial struct TCOD_Noise
    {
        public int ndim;

        /// Randomized map of indexes into buffer.
        [NativeTypeName("unsigned char[256]")]
        public _map_e__FixedBuffer map;

        /// Random 256 x ndim buffer.
        [NativeTypeName("float[256][4]")]
        public _buffer_e__FixedBuffer buffer;

        public float H;

        public float lacunarity;

        [NativeTypeName("float[128]")]
        public _exponent_e__FixedBuffer exponent;

        [NativeTypeName("float *restrict")]
        public float* waveletTileData;

        public TCOD_Random* rand;

        public TCOD_noise_type_t noise_type;

        [InlineArray(256)]
        public partial struct _map_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(256 * 4)]
        public partial struct _buffer_e__FixedBuffer
        {
            public float e0_0;
        }

        [InlineArray(128)]
        public partial struct _exponent_e__FixedBuffer
        {
            public float e0;
        }
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Noise* TCOD_noise_new(int dimensions, float hurst, float lacunarity, TCOD_Random* random);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_noise_set_type(TCOD_Noise* noise, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get_ex(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get_fbm_ex(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f, float octaves, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get_turbulence_ex(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f, float octaves, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get_fbm(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f, float octaves);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_noise_get_turbulence(TCOD_Noise* noise, [NativeTypeName("const float *restrict")] float* f, float octaves);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_noise_delete(TCOD_Noise* noise);

        /// <summary>
        /// Generate noise as a vectorized operation.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_noise_get_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, int n, [NativeTypeName("float *restrict")] float* x, [NativeTypeName("float *restrict")] float* y, [NativeTypeName("float *restrict")] float* z, [NativeTypeName("float *restrict")] float* w, [NativeTypeName("float *restrict")] float* @out);

        /// <summary>
        /// Generate noise as a vectorized operation with fractional Brownian motion.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_noise_get_fbm_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, float octaves, int n, [NativeTypeName("float *restrict")] float* x, [NativeTypeName("float *restrict")] float* y, [NativeTypeName("float *restrict")] float* z, [NativeTypeName("float *restrict")] float* w, [NativeTypeName("float *restrict")] float* @out);

        /// <summary>
        /// Generate noise as a vectorized operation with turbulence.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_noise_get_turbulence_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, float octaves, int n, [NativeTypeName("float *restrict")] float* x, [NativeTypeName("float *restrict")] float* y, [NativeTypeName("float *restrict")] float* z, [NativeTypeName("float *restrict")] float* w, [NativeTypeName("float *restrict")] float* @out);
    }
}

