using System.Runtime.InteropServices;

namespace libtcod.Interop;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_PrintParamsRGB
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public nint fg;
        public nint bg;
        public TCOD_bkgnd_flag_t flag;
        public TCOD_alignment_t alignment;
    }
}
