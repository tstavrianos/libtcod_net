using System.Runtime.InteropServices;

namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Try to return a fall-back Tileset, may return NULL.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Tileset* TCOD_tileset_load_fallback_font_(int tile_width, int tile_height);
    }
}

