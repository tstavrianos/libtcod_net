using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float TCOD_path_func_t(int xFrom, int yFrom, int xTo, int yTo, nint user_data);
}
