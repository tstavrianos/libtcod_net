using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is not compatible with contexts.  Consider using tcod::load_tilesheet or TCOD_tileset_load instead." +
    "  https://libtcod.readthedocs.io/en/latest/upgrading.html")]
        public static extern TCOD_Error TCOD_console_set_custom_font([NativeTypeName("const char *")] sbyte* fontFile, int flags, int nb_char_horiz, int nb_char_vertic);
        // Managed wrapper for TCOD_console_set_custom_font
        public static TCOD_Error TCOD_console_set_custom_font(
            string fontFile,
            int flags,
            int nb_char_horiz,
            int nb_char_vertic
        )
        {
            var fontFilePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(fontFile);
            try
            {
                return TCOD_console_set_custom_font((sbyte*)fontFilePtr.ToPointer(), flags, nb_char_horiz, nb_char_vertic);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontFilePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is not compatible with contexts.")]
        public static extern void TCOD_console_map_ascii_code_to_font(int asciiCode, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is not compatible with contexts.")]
        public static extern void TCOD_console_map_ascii_codes_to_font(int asciiCode, int nbCodes, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is not compatible with contexts.")]
        public static extern void TCOD_console_map_string_to_font([NativeTypeName("const char *")] sbyte* s, int fontCharX, int fontCharY);
        // Managed wrapper for TCOD_console_map_string_to_font
        public static void TCOD_console_map_string_to_font(
            string s,
            int fontCharX,
            int fontCharY
        )
        {
            var sPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(s);
            try
            {
                TCOD_console_map_string_to_font((sbyte*)sPtr.ToPointer(), fontCharX, fontCharY);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(sPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is not compatible with contexts.")]
        public static extern void TCOD_console_map_string_to_font_utf([NativeTypeName("const wchar_t *")] ushort* s, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function does nothing.")]
        public static extern void TCOD_console_set_dirty(int x, int y, int w, int h);

        /// <summary>
        /// Render and present a console with optional viewport options.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_console_flush_ex(TCOD_Console* console, [NativeTypeName("struct TCOD_ViewportOptions *")] TCOD_ViewportOptions* viewport);

        /// <summary>
        /// Render and present the root console to the active display.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_console_flush();

        /// <summary>
        /// Return True if the libtcod keycode is held.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        [Obsolete("Use SDL to check the keyboard state.")]
        public static extern byte TCOD_console_is_key_pressed(TCOD_keycode_t key);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_console_t")]
        public static extern TCOD_Console* TCOD_console_from_file([NativeTypeName("const char *")] sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_load_asc([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_load_asc
        public static byte TCOD_console_load_asc(
            [NativeTypeName("TCOD_console_t")] TCOD_Console* con,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_load_asc(con, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_load_apf([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_load_apf
        public static byte TCOD_console_load_apf(
            [NativeTypeName("TCOD_console_t")] TCOD_Console* con,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_load_apf(con, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_save_asc([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_save_asc
        public static byte TCOD_console_save_asc(
            [NativeTypeName("TCOD_console_t")] TCOD_Console* con,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_save_asc(con, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_save_apf([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_save_apf
        public static byte TCOD_console_save_apf(
            [NativeTypeName("TCOD_console_t")] TCOD_Console* con,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_save_apf(con, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        /// <summary>
        /// Return immediately with a recently pressed key.
        /// </summary>
        /// <param name="flags">A TCOD_event_t bit-field, for example: TCOD_EVENT_KEY_PRESS</param>
        /// <returns>A TCOD_key_t struct with a recently pressed key. If no event exists then the vk attribute will be TCODK_NONE</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This API is deprecated, use SDL_PollEvent instead.")]
        public static extern TCOD_key_t TCOD_console_check_for_keypress(int flags);

        /// <summary>
        /// Wait for a key press event, then return it.
        /// </summary>
        /// <param name="flush">If 1 then the event queue will be cleared before waiting for the next event. This should always be 0.</param>
        /// <returns>A TCOD_key_t struct with the most recent key data.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This API is deprecated, use SDL_WaitEvent instead.")]
        public static extern TCOD_key_t TCOD_console_wait_for_keypress([NativeTypeName("_Bool")] byte flush);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function does not support contexts.  Consider using `TCOD_console_credits_render_ex`.")]
        public static extern void TCOD_console_credits();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function does not support contexts.")]
        public static extern void TCOD_console_credits_reset();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        [Obsolete("This function does not support contexts.  Consider using `TCOD_console_credits_render_ex`.")]
        public static extern byte TCOD_console_credits_render(int x, int y, [NativeTypeName("_Bool")] byte alpha);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_credits_render_ex(TCOD_Console* console, int x, int y, [NativeTypeName("_Bool")] byte alpha, float delta_time);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is a stub and will do nothing.")]
        public static extern void TCOD_console_set_keyboard_repeat(int initial_delay, int interval);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function is a stub and will do nothing.")]
        public static extern void TCOD_console_disable_keyboard_repeat();

        /// <summary>
        /// Fade the color of the display.
        /// </summary>
        /// <param name="val">Where at 255 colors are normal and at 0 colors are completely faded.</param>
        /// <param name="fade_color">Color to fade towards. \rst .. deprecated:: 1.19 This function will not work with libtcod contexts. \endrst</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete("This function does not support contexts.")]
        public static extern void TCOD_console_set_fade([NativeTypeName("uint8_t")] byte val, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB fade_color);

        /// <summary>
        /// Return the fade value.
        /// </summary>
        /// <returns>At 255 colors are normal and at 0 colors are completely faded.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint8_t")]
        public static extern byte TCOD_console_get_fade();

        /// <summary>
        /// Return the fade color.
        /// </summary>
        /// <returns>The current fading color.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_console_get_fading_color();
    }
}

