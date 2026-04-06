using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_noise_new(
        int dimensions,
        float hurst,
        float lacunarity,
        nint random
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_set_type(nint noise, TCOD_noise_type_t type);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_ex(nint noise, nint f, TCOD_noise_type_t type);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_ex(
        nint noise,
        [In] float[] f,
        TCOD_noise_type_t type
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_fbm_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_fbm_ex(
        nint noise,
        [In] float[] f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_turbulence_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_turbulence_ex(
        nint noise,
        [In] float[] f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get(nint noise, nint f);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get(nint noise, [In] float[] f);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_fbm(nint noise, nint f, float octaves);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_fbm(nint noise, [In] float[] f, float octaves);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_turbulence(nint noise, nint f, float octaves);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_noise_get_turbulence(nint noise, [In] float[] f, float octaves);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_delete(nint noise);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_fbm_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_fbm_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_turbulence_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_noise_get_turbulence_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );
}
