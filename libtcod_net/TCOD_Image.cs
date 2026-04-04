using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_Image
{
    public int nb_mipmaps;
    public nint mipmaps;
    public TCOD_ColorRGB key_color;

    [MarshalAs(UnmanagedType.I1)]
    public bool has_key_color;
}
