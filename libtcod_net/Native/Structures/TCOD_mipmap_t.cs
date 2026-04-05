using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_mipmap_t
    {
        public int width;
        public int height;
        public float fwidth;
        public float fheight;
        public nint buf;

        [MarshalAs(UnmanagedType.I1)]
        public bool dirty;
    }
}
