using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_heightmap_t
{
    public int w;
    public int h;
    public nint values;
}
