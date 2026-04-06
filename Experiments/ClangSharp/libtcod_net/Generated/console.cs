using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_bkgnd_flag_t
    {
        TCOD_BKGND_NONE,
        TCOD_BKGND_SET,
        TCOD_BKGND_MULTIPLY,
        TCOD_BKGND_LIGHTEN,
        TCOD_BKGND_DARKEN,
        TCOD_BKGND_SCREEN,
        TCOD_BKGND_COLOR_DODGE,
        TCOD_BKGND_COLOR_BURN,
        TCOD_BKGND_ADD,
        TCOD_BKGND_ADDA,
        TCOD_BKGND_BURN,
        TCOD_BKGND_OVERLAY,
        TCOD_BKGND_ALPH,
        TCOD_BKGND_DEFAULT,
    }

    public enum TCOD_alignment_t
    {
        TCOD_LEFT,
        TCOD_RIGHT,
        TCOD_CENTER,
    }

    public partial struct TCOD_ConsoleTile
    {
        public int ch;

        public TCOD_ColorRGBA fg;

        public TCOD_ColorRGBA bg;
    }

    public unsafe partial struct TCOD_Console
    {
        /// Console width and height in tiles.
        public int w;

        public int h;

        /// A contiguous array of console tiles.
        public TCOD_ConsoleTile* tiles;

        /// Default background operator for print &amp; print_rect functions.
        public TCOD_bkgnd_flag_t bkgnd_flag;

        /// Default alignment for print &amp; print_rect functions.
        public TCOD_alignment_t alignment;

        /// Foreground (text) and background colors.
        [NativeTypeName("TCOD_color_t")]
        public TCOD_ColorRGB fore;

        [NativeTypeName("TCOD_color_t")]
        public TCOD_ColorRGB back;

        /// True if a key color is being used.
        [NativeTypeName("_Bool")]
        public byte has_key_color;

        /// The current key color for this console.
        [NativeTypeName("TCOD_color_t")]
        public TCOD_ColorRGB key_color;

        /// The total length of the tiles array.
        public int elements;

        /// A userdata attribute which can be repurposed.
        public void* userdata;

        /// Internal use.
        [NativeTypeName("void (*)(struct TCOD_Console *)")]
        public delegate* unmanaged[Cdecl]<TCOD_Console*, void> on_delete;
    }

    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Return a new console with a specific number of columns and rows.
        /// </summary>
        /// <param name="w">Number of columns.</param>
        /// <param name="h">Number of columns.</param>
        /// <returns>A pointer to the new console, or NULL on error.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Console* TCOD_console_new(int w, int h);

        /// <summary>
        /// Return the width of a console.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_width([NativeTypeName("const TCOD_Console *")] TCOD_Console* con);

        /// <summary>
        /// Return the height of a console.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_height([NativeTypeName("const TCOD_Console *")] TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_key_color(TCOD_Console* con, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB col);

        /// <summary>
        /// Blit from one console to another.
        /// </summary>
        /// <param name="src">Pointer to the source console.</param>
        /// <param name="xSrc">The left region of the source console to blit from.</param>
        /// <param name="ySrc">The top region of the source console to blit from.</param>
        /// <param name="wSrc">The width of the region to blit from. If 0 then it will fill to the maximum width.</param>
        /// <param name="hSrc">The height of the region to blit from. If 0 then it will fill to the maximum height.</param>
        /// <param name="dst">Pointer to the destination console.</param>
        /// <param name="xDst">The left corner to blit onto the destination console.</param>
        /// <param name="yDst">The top corner to blit onto the destination console.</param>
        /// <param name="foreground_alpha">Foreground blending alpha.</param>
        /// <param name="background_alpha">Background blending alpha.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_blit([NativeTypeName("const TCOD_Console *restrict")] TCOD_Console* src, int xSrc, int ySrc, int wSrc, int hSrc, TCOD_Console* dst, int xDst, int yDst, float foreground_alpha, float background_alpha);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_blit_key_color([NativeTypeName("const TCOD_Console *restrict")] TCOD_Console* src, int xSrc, int ySrc, int wSrc, int hSrc, TCOD_Console* dst, int xDst, int yDst, float foreground_alpha, float background_alpha, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* key_color);

        /// <summary>
        /// Delete a console.
        /// </summary>
        /// <param name="console">A console pointer.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_delete(TCOD_Console* console);



        /// <summary>
        /// Clear a console to its default colors and the space character code.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_clear(TCOD_Console* con);












        /// <summary>
        /// Return the background color of a console at x,y.
        /// </summary>
        /// <param name="con">A console pointer.</param>
        /// <param name="x">The X coordinate, the left-most position being 0.</param>
        /// <param name="y">The Y coordinate, the top-most position being 0.</param>
        /// <returns>A TCOD_color_t struct with a copy of the background color.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_console_get_char_background([NativeTypeName("const TCOD_Console *")] TCOD_Console* con, int x, int y);

        /// <summary>
        /// Return the foreground color of a console at x,y.
        /// </summary>
        /// <param name="con">A console pointer.</param>
        /// <param name="x">The X coordinate, the left-most position being 0.</param>
        /// <param name="y">The Y coordinate, the top-most position being 0.</param>
        /// <returns>A TCOD_color_t struct with a copy of the foreground color.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_console_get_char_foreground([NativeTypeName("const TCOD_Console *")] TCOD_Console* con, int x, int y);

        /// <summary>
        /// Return a character code of a console at x,y.
        /// </summary>
        /// <param name="con">A console pointer.</param>
        /// <param name="x">The X coordinate, the left-most position being 0.</param>
        /// <param name="y">The Y coordinate, the top-most position being 0.</param>
        /// <returns>The character code.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_char([NativeTypeName("const TCOD_Console *")] TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_resize_(TCOD_Console* console, int width, int height);
    }
}

