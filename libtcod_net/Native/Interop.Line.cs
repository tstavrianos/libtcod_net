using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_line(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        TCOD_line_listener_t listener
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_line_init_mt(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        ref TCOD_bresenham_data_t data
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_line_step_mt(
        ref int xCur,
        ref int yCur,
        ref TCOD_bresenham_data_t data
    );
}
