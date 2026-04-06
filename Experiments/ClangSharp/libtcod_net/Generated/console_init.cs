using System;
using System.Runtime.InteropServices;

namespace libtcod_net
{
public static unsafe partial class libtcod
    {












        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Context* TCOD_sys_get_internal_context();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Console* TCOD_sys_get_internal_console();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_quit();
    }
}
