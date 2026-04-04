using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_mipmap_
{
    public int width;
    public int height;
    public float fwidth;
    public float fheight;
    public nint buf;

    [MarshalAs(UnmanagedType.I1)]
    public bool dirty;
}
