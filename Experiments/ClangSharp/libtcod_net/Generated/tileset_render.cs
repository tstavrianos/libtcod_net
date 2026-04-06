using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
public static unsafe partial class libtcod
    {
        /// <summary>
        /// Render a console to a SDL_Surface with a software renderer.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_tileset_render_to_surface([NativeTypeName("const TCOD_Tileset *restrict")] TCOD_Tileset* tileset, [NativeTypeName("const TCOD_Console *restrict")] TCOD_Console* console, [NativeTypeName("TCOD_Console *restrict *")] TCOD_Console** cache, [NativeTypeName("struct SDL_Surface *restrict *")] void** surface_out);
    }
}

