using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    /// <summary>
    /// A contigious 2D array of float values.
    /// </summary>
    public unsafe partial struct TCOD_heightmap_t
    {
        /// Width of this heightmap.
        public int w;

        /// Height of this heightmap.
        public int h;

        /// Contigious 2D array of float values.
        [NativeTypeName("float *restrict")]
        public float* values;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_heightmap_t* TCOD_heightmap_new(int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_delete(TCOD_heightmap_t* hm);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_heightmap_get_interpolated_value([NativeTypeName("const TCOD_heightmap_t *")] TCOD_heightmap_t* hm, float x, float y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_heightmap_get_slope([NativeTypeName("const TCOD_heightmap_t *")] TCOD_heightmap_t* hm, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_get_normal([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm, float x, float y, [NativeTypeName("float[3]")] float* n, float waterLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_heightmap_count_cells([NativeTypeName("const TCOD_heightmap_t *")] TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_heightmap_has_land_on_border([NativeTypeName("const TCOD_heightmap_t *")] TCOD_heightmap_t* hm, float waterLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_get_minmax([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* heightmap, [NativeTypeName("float *restrict")] float* min_out, [NativeTypeName("float *restrict")] float* max_out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_copy([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm_source, TCOD_heightmap_t* hm_dest);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_add(TCOD_heightmap_t* hm, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_scale(TCOD_heightmap_t* hm, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_clamp(TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_normalize(TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_clear(TCOD_heightmap_t* hm);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_lerp_hm([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm1, [NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out, float coef);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_add_hm([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm1, [NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_multiply_hm([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm1, [NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_add_hill(TCOD_heightmap_t* hm, float hx, float hy, float h_radius, float h_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_dig_hill(TCOD_heightmap_t* hm, float hx, float hy, float h_radius, float h_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_dig_bezier(TCOD_heightmap_t* hm, [NativeTypeName("int[4]")] int* px, [NativeTypeName("int[4]")] int* py, float startRadius, float startDepth, float endRadius, float endDepth);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_rain_erosion(TCOD_heightmap_t* hm, int nbDrops, float erosionCoef, float sedimentationCoef, TCOD_Random* rnd);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_kernel_transform(TCOD_heightmap_t* hm, int kernel_size, [NativeTypeName("const int *restrict")] int* dx, [NativeTypeName("const int *restrict")] int* dy, [NativeTypeName("const float *restrict")] float* weight, float minLevel, float maxLevel);

        /// <summary>
        /// Generate a mask from heightmap values within a threshold range.
        /// </summary>
        /// <param name="hm">Source heightmap to threshold.</param>
        /// <param name="mask">Destination mask array (must be hm-&gt;w * hm-&gt;h bytes, row-major).</param>
        /// <param name="minLevel">Minimum value (inclusive) for cells to be marked.</param>
        /// <param name="maxLevel">Maximum value (inclusive) for cells to be marked.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_threshold_mask([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm, [NativeTypeName("uint8_t *")] byte* mask, float minLevel, float maxLevel);

        /// <summary>
        /// Apply a sparse kernel convolution from source to destination heightmap.
        /// </summary>
        /// <param name="hm_src">Source heightmap (read-only). Must not alias hm_dst.</param>
        /// <param name="hm_dst">Destination heightmap (must be same size as source). Must not alias hm_src.</param>
        /// <param name="kernel_size">Number of elements in the kernel arrays.</param>
        /// <param name="dx">Array of x-offsets for kernel positions.</param>
        /// <param name="dy">Array of y-offsets for kernel positions.</param>
        /// <param name="weight">Array of weights for each kernel position.</param>
        /// <param name="mask">Optional mask array (hm-&gt;w * hm-&gt;h bytes, row-major). NULL transforms all cells.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_kernel_transform_out([NativeTypeName("const TCOD_heightmap_t *restrict")] TCOD_heightmap_t* hm_src, TCOD_heightmap_t* hm_dst, int kernel_size, [NativeTypeName("const int *restrict")] int* dx, [NativeTypeName("const int *restrict")] int* dy, [NativeTypeName("const float *restrict")] float* weight, [NativeTypeName("const uint8_t *restrict")] byte* mask);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_add_voronoi(TCOD_heightmap_t* hm, int nbPoints, int nbCoef, [NativeTypeName("const float *restrict")] float* coef, TCOD_Random* rnd);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_mid_point_displacement(TCOD_heightmap_t* hm, TCOD_Random* rnd, float roughness);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_add_fbm(TCOD_heightmap_t* hm, TCOD_Noise* noise, float mul_x, float mul_y, float add_x, float add_y, float octaves, float delta, float scale);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heightmap_scale_fbm(TCOD_heightmap_t* hm, TCOD_Noise* noise, float mul_x, float mul_y, float add_x, float add_y, float octaves, float delta, float scale);

    }
}

