using System.Runtime.InteropServices;

namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Return the default tileset, may be NULL.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Tileset* TCOD_get_default_tileset();

        /// <summary>
        /// Set the default tileset and update the default display to use it.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_set_default_tileset(TCOD_Tileset* tileset);
    }
}

