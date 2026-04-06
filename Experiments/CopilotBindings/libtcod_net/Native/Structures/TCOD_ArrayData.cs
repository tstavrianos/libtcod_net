using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_ArrayData
    {
        public sbyte ndim;
        public int int_type;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public nuint[] shape;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public nuint[] strides;

        public nint data;
    }
}
