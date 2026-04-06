using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_BasicGraph2D
    {
        public TCOD_ArrayData cost;
        public int cardinal;
        public int diagonal;
    }
}
