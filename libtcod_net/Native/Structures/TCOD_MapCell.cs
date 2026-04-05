using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_MapCell
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool transparent;

        [MarshalAs(UnmanagedType.I1)]
        public bool walkable;

        [MarshalAs(UnmanagedType.I1)]
        public bool fov;
    }
}
