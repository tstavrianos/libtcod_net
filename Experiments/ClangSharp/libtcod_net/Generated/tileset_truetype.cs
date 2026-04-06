using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Return a tileset from a TrueType font file.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Tileset* TCOD_load_truetype_font_([NativeTypeName("const char *")] sbyte* path, int tile_width, int tile_height);
        // Managed wrapper for TCOD_load_truetype_font_
        public static TCOD_Tileset* TCOD_load_truetype_font_(
            string path,
            int tile_width,
            int tile_height
        )
        {
            var pathPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(path);
            try
            {
                return TCOD_load_truetype_font_((sbyte*)pathPtr.ToPointer(), tile_width, tile_height);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pathPtr);
            }
        }


    }
}

