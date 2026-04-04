using System.Runtime.InteropServices;

namespace libtcod.Interop;

public static partial class libtcod
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool TCOD_line_listener_t(int x, int y);
}
