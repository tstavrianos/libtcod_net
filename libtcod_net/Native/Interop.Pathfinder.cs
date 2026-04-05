using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_pf_new(int ndim, [In] nuint[] shape);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_pf_new(int ndim, nint shape);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_delete(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_distance_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_distance_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_graph2d_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides,
        int cardinal,
        int diagonal
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_graph2d_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides,
        int cardinal,
        int diagonal
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_traversal_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_pf_set_traversal_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_pf_recompile(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_pf_compute(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_pf_compute_step(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_frontier_new(int ndim);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_frontier_delete(nint frontier);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_frontier_pop(nint frontier);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_frontier_push(
        nint frontier,
        nint index,
        int dist,
        int heuristic
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_frontier_push(
        nint frontier,
        [In] int[] index,
        int dist,
        int heuristic
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_frontier_size(nint frontier);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_frontier_clear(nint frontier);
}
