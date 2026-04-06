using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_path_new_using_map(nint map, float diagonalCost);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_path_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_compute(nint path, int ox, int oy, int dx, int dy);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_walk(
        nint path,
        ref int x,
        ref int y,
        [MarshalAs(UnmanagedType.I1)] bool recalculate_when_needed
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_is_empty(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_path_size(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_path_reverse(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_path_get(nint path, int index, out int x, out int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_path_get_origin(nint path, out int x, out int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_path_get_destination(nint path, out int x, out int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_path_delete(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_dijkstra_new(nint map, float diagonalCost);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_dijkstra_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_dijkstra_compute(nint dijkstra, int root_x, int root_y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float TCOD_dijkstra_get_distance(nint dijkstra, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_path_set(nint dijkstra, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_is_empty(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_dijkstra_size(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_dijkstra_reverse(nint path);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_dijkstra_get(nint path, int index, out int x, out int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_path_walk(nint dijkstra, ref int x, ref int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_dijkstra_delete(nint dijkstra);
}
