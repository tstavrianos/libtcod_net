using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_Pathfinder
    {
        public sbyte ndim;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public nuint[] shape;

        [MarshalAs(UnmanagedType.I1)]
        public bool owns_distance;

        [MarshalAs(UnmanagedType.I1)]
        public bool owns_graph;

        [MarshalAs(UnmanagedType.I1)]
        public bool owns_traversal;

        public TCOD_ArrayData distance;
        public TCOD_BasicGraph2D graph;
        public TCOD_ArrayData traversal;
        public TCOD_Heap heap;
    }
}
