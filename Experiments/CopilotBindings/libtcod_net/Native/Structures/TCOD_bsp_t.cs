using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_bsp_t
    {
        public TCOD_tree_t tree;
        public int x;
        public int y;
        public int w;
        public int h;
        public int position;
        public byte level;

        [MarshalAs(UnmanagedType.I1)]
        public bool horizontal;
    }
}
