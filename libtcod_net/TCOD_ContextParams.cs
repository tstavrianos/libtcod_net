using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_ContextParams
{
    public int tcod_version;
    public int window_x;
    public int window_y;
    public int pixel_width;
    public int pixel_height;
    public int columns;
    public int rows;
    public TCOD_renderer_t renderer_type;
    public nint tileset;
    public int vsync;
    public int sdl_window_flags;
    public nint window_title;
    public int argc;
    public nint argv;
    public nint cli_output;
    public nint cli_userdata;

    [MarshalAs(UnmanagedType.I1)]
    public bool window_xy_defined;
    public nint console;
}
