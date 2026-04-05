using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_tree_t
    {
        public nint next;
        public nint father;
        public nint sons;
    }
}
