using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_map_new(int width, int height);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_map_clear(
        nint map,
        [MarshalAs(UnmanagedType.I1)] bool transparent,
        [MarshalAs(UnmanagedType.I1)] bool walkable
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_map_copy(nint source, nint dest);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_map_set_properties(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool is_transparent,
        [MarshalAs(UnmanagedType.I1)] bool is_walkable
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_map_delete(nint map);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_map_compute_fov(
        nint map,
        int pov_x,
        int pov_y,
        int max_radius,
        [MarshalAs(UnmanagedType.I1)] bool light_walls,
        TCOD_fov_algorithm_t algo
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_in_fov(nint map, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_map_set_in_fov(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool fov
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_transparent(nint map, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_walkable(nint map, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_map_get_width(nint map);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_map_get_height(nint map);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_map_get_nb_cells(nint map);
}
