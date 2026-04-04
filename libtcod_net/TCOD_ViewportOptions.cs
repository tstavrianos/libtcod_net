using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_ViewportOptions
{
    public int tcod_version;

    [MarshalAs(UnmanagedType.I1)]
    public bool keep_aspect;

    [MarshalAs(UnmanagedType.I1)]
    public bool integer_scaling;
    public TCOD_ColorRGBA clear_color;
    public float align_x;
    public float align_y;
}
