using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_bresenham_data_t
    {
        public int stepx;
        public int stepy;
        public int e;
        public int deltax;
        public int deltay;
        public int origx;
        public int origy;
        public int destx;
        public int desty;
    }
}
