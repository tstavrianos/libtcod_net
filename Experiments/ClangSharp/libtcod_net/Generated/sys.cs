using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_event_t
    {
        TCOD_EVENT_NONE = 0,
        TCOD_EVENT_KEY_PRESS = 1,
        TCOD_EVENT_KEY_RELEASE = 2,
        TCOD_EVENT_KEY = TCOD_EVENT_KEY_PRESS | TCOD_EVENT_KEY_RELEASE,
        TCOD_EVENT_MOUSE_MOVE = 4,
        TCOD_EVENT_MOUSE_PRESS = 8,
        TCOD_EVENT_MOUSE_RELEASE = 16,
        TCOD_EVENT_MOUSE = TCOD_EVENT_MOUSE_MOVE | TCOD_EVENT_MOUSE_PRESS | TCOD_EVENT_MOUSE_RELEASE,
        TCOD_EVENT_FINGER_MOVE = 32,
        TCOD_EVENT_FINGER_PRESS = 64,
        TCOD_EVENT_FINGER_RELEASE = 128,
        TCOD_EVENT_FINGER = TCOD_EVENT_FINGER_MOVE | TCOD_EVENT_FINGER_PRESS | TCOD_EVENT_FINGER_RELEASE,
        TCOD_EVENT_ANY = TCOD_EVENT_KEY | TCOD_EVENT_MOUSE | TCOD_EVENT_FINGER,
    }
public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_startup();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_shutdown();










































        /// <summary>
        /// Upload a tile to the active tileset.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_update_char(int asciiCode, int font_x, int font_y, [NativeTypeName("const TCOD_Image *")] TCOD_Image* img, int x, int y);

        /// <summary>
        /// Return an SDL_Window pointer if one is in use, returns NULL otherwise.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SDL_Window *")]
        public static extern void* TCOD_sys_get_SDL_window();

        /// <summary>
        /// Return an SDL_Renderer pointer if one is in use, returns NULL otherwise.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SDL_Renderer *")]
        public static extern void* TCOD_sys_get_SDL_renderer();





    }
}

