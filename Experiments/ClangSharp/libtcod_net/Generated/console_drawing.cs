using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {



        /// <summary>
        /// Place a single tile on a console at x,y.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_put_rgb(TCOD_Console* console, int x, int y, int ch, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* fg, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag);

        /// <summary>
        /// Draw a rectangle on a console with a shape of x,y,width,height.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_console_draw_rect_rgb(TCOD_Console* console, int x, int y, int width, int height, int ch, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* fg, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag);

        /// <summary>
        /// Draw a decorated frame onto console with the shape of x, y, width, height.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_console_draw_frame_rgb([NativeTypeName("struct TCOD_Console *restrict")] TCOD_Console* con, int x, int y, int width, int height, [NativeTypeName("const int *restrict")] int* decoration, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* fg, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, [NativeTypeName("_Bool")] byte clear);
    }
}

