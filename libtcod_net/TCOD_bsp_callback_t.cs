using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: MarshalAs(UnmanagedType.I1)]
public delegate bool TCOD_bsp_callback_t(ref TCOD_bsp_t node, nint userData);
