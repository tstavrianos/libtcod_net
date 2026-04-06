using System;
using System.Runtime.InteropServices;
using libtcod_net.TCOD;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_heightmap_new(int w, int h);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_delete(nint hm);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_heightmap_get_interpolated_value(nint hm, float x, float y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_heightmap_get_slope(nint hm, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_get_normal(
        nint hm,
        float x,
        float y,
        [Out] float[] n,
        float waterLevel
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_heightmap_count_cells(nint hm, float min, float max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_heightmap_has_land_on_border(nint hm, float waterLevel);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_get_minmax(
        nint heightmap,
        out float min_out,
        out float max_out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_copy(nint hm_source, nint hm_dest);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_add(nint hm, float value);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_scale(nint hm, float value);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_clamp(nint hm, float min, float max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_normalize(nint hm, float min, float max);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_clear(nint hm);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_lerp_hm(nint hm1, nint hm2, nint @out, float coef);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_add_hm(nint hm1, nint hm2, nint @out);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_multiply_hm(nint hm1, nint hm2, nint @out);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_add_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_dig_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_dig_bezier(
        nint hm,
        nint px,
        nint py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_rain_erosion(
        nint hm,
        int nbDrops,
        float erosionCoef,
        float sedimentationCoef,
        nint rnd
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        nint dx,
        nint dy,
        nint weight,
        float minLevel,
        float maxLevel
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_threshold_mask(
        nint hm,
        [Out] byte[] mask,
        float minLevel,
        float maxLevel
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_kernel_transform_out(
        nint hm_src,
        nint hm_dst,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        [In] byte[] mask
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_kernel_transform_out(
        nint hm_src,
        nint hm_dst,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        nint mask
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_add_voronoi(
        nint hm,
        int nbPoints,
        int nbCoef,
        [In] float[] coef,
        nint rnd
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_mid_point_displacement(
        nint hm,
        nint rnd,
        float roughness
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_add_fbm(
        nint hm,
        nint noise,
        float mul_x,
        float mul_y,
        float add_x,
        float add_y,
        float octaves,
        float delta,
        float scale
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heightmap_scale_fbm(
        nint hm,
        nint noise,
        float mul_x,
        float mul_y,
        float add_x,
        float add_y,
        float octaves,
        float delta,
        float scale
    );

    public static unsafe void TCOD_heightmap_dig_bezier(
        nint hm,
        ReadOnlySpan<int> px,
        ReadOnlySpan<int> py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    )
    {
        if (px.Length < 4 || py.Length < 4)
            throw new TCODException(
                "px and py should contain at least 4 elements each",
                TCOD_Error.TCOD_E_ERROR
            );
        fixed (int* x = px)
        fixed (int* y = py)
            TCOD_heightmap_dig_bezier(
                hm,
                (nint)x,
                (nint)y,
                startRadius,
                startDepth,
                endRadius,
                endDepth
            );
    }

    public static void TCOD_heightmap_dig_bezier(
        nint hm,
        int[] px,
        int[] py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    )
    {
        TCOD_heightmap_dig_bezier(
            hm,
            px.AsSpan(),
            py.AsSpan(),
            startRadius,
            startDepth,
            endRadius,
            endDepth
        );
    }

    public static unsafe void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        ReadOnlySpan<int> dx,
        ReadOnlySpan<int> dy,
        ReadOnlySpan<float> weight,
        float minLevel,
        float maxLevel
    )
    {
        if (dx.Length < kernel_size)
            throw new TCODException(
                $"dx should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        if (dy.Length < kernel_size)
            throw new TCODException(
                $"dy should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        if (weight.Length < kernel_size)
            throw new TCODException(
                $"weight should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        fixed (int* x = dx)
        fixed (int* y = dy)
        fixed (float* w = weight)
            TCOD_heightmap_kernel_transform(
                hm,
                kernel_size,
                (nint)x,
                (nint)y,
                (nint)w,
                minLevel,
                maxLevel
            );
    }

    public static void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        int[] dx,
        int[] dy,
        float[] weight,
        float minLevel,
        float maxLevel
    )
    {
        TCOD_heightmap_kernel_transform(
            hm,
            kernel_size,
            dx.AsSpan(),
            dy.AsSpan(),
            weight.AsSpan(),
            minLevel,
            maxLevel
        );
    }
}
