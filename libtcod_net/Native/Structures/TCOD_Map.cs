using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_Map
    {
        public int width;
        public int height;
        public int nbcells;
        public nint cells;
    }
}
