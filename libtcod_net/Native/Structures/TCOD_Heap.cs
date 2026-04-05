using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_Heap
    {
        public nint heap;
        public int size;
        public int capacity;
        public nuint node_size;
        public nuint data_size;
        public nuint data_offset;
        public int priority_type;
    }
}
