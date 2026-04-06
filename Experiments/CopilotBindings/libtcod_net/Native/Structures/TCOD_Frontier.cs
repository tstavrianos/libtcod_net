using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_Frontier
    {
        public sbyte ndim;
        public int active_dist;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] active_index;
        public TCOD_Heap heap;
    }
}
