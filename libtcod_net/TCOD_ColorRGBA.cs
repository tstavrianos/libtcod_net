using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_ColorRGBA
{
    public byte r;
    public byte g;
    public byte b;
    public byte a;
}
