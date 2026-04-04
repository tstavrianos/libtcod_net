using System.Runtime.InteropServices;

namespace libtcod_net;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate bool TCOD_line_listener_t(int x, int y);
