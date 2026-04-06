using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_colctrl_t
    {
        TCOD_COLCTRL_1 = 1,
        TCOD_COLCTRL_2,
        TCOD_COLCTRL_3,
        TCOD_COLCTRL_4,
        TCOD_COLCTRL_5,
        TCOD_COLCTRL_NUMBER = 5,
        TCOD_COLCTRL_FORE_RGB,
        TCOD_COLCTRL_BACK_RGB,
        TCOD_COLCTRL_STOP,
    }

    public unsafe partial struct TCOD_PrintParamsRGB
    {
        public int x;

        public int y;

        public int width;

        public int height;

        [NativeTypeName("const TCOD_ColorRGB *restrict")]
        public TCOD_ColorRGB* fg;

        [NativeTypeName("const TCOD_ColorRGB *restrict")]
        public TCOD_ColorRGB* bg;

        public TCOD_bkgnd_flag_t flag;

        public TCOD_alignment_t alignment;
    }

    public static unsafe partial class libtcod
    {











        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_color_control(TCOD_colctrl_t con, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB fore, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB back);






        /// <summary>
        /// Return the number of lines that would be printed by this formatted string.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_height_rect_fmt(TCOD_Console* con, int x, int y, int w, int h, [NativeTypeName("const char *restrict")] sbyte* fmt, __arglist);

        /// <summary>
        /// Print a string of a specified length to a console.
        /// </summary>
        /// <param name="console">A pointer to a TCOD_Console.</param>
        /// <param name="x">The starting X position, starting from the left-most tile as zero.</param>
        /// <param name="y">The starting Y position, starting from the upper-most tile as zero.</param>
        /// <param name="n">The length of the string buffer str[n] in bytes.</param>
        /// <param name="str">The text to print. This string can contain libtcod color codes.</param>
        /// <param name="fg">The foreground color. The printed text is set to this color. If NULL then the foreground will be left unchanged, inheriting the previous value of the tile.</param>
        /// <param name="bg">The background color. The background tile under the printed text is set to this color. If NULL then the background will be left unchanged.</param>
        /// <param name="flag">The background blending flag. If unsure then use TCOD_BKGND_SET.</param>
        /// <param name="alignment">The text justification. This is one of TCOD_alignment_t and is normally TCOD_LEFT.</param>
        /// <returns>TCOD_Error Any problems such as malformed UTF-8 will return a negative error code.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_console_printn(TCOD_Console* console, int x, int y, [NativeTypeName("size_t")] nuint n, [NativeTypeName("const char *restrict")] sbyte* str, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* fg, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);
        // Managed wrapper for TCOD_console_printn
        public static TCOD_Error TCOD_console_printn(
            TCOD_Console* console,
            int x,
            int y,
            [NativeTypeName("size_t")] nuint n,
            string str,
            [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* fg,
            [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* bg,
            TCOD_bkgnd_flag_t flag,
            TCOD_alignment_t alignment
        )
        {
            var strPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(str);
            try
            {
                return TCOD_console_printn(console, x, y, n, (sbyte*)strPtr.ToPointer(), fg, bg, flag, alignment);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(strPtr);
            }
        }


        /// <summary>
        /// Print a string of a specified length in a bounding box to a console.
        /// </summary>
        /// <param name="console">A pointer to a TCOD_Console.</param>
        /// <param name="x">The starting X position, starting from the left-most tile as zero.</param>
        /// <param name="y">The starting Y position, starting from the upper-most tile as zero.</param>
        /// <param name="width">The maximum width of the bounding region in tiles.</param>
        /// <param name="height">The maximum height of the bounding region in tiles.</param>
        /// <param name="n">The length of the string buffer str[n] in bytes.</param>
        /// <param name="str">The text to print. This string can contain libtcod color codes.</param>
        /// <param name="fg">The foreground color. The printed text is set to this color. If NULL then the foreground will be left unchanged, inheriting the previous value of the tile.</param>
        /// <param name="bg">The background color. The background tile under the printed text is set to this color. If NULL then the background will be left unchanged.</param>
        /// <param name="flag">The background blending flag. If unsure then use TCOD_BKGND_SET.</param>
        /// <param name="alignment">The text justification. This is one of TCOD_alignment_t and is normally TCOD_LEFT.</param>
        /// <returns>int The height of the printed text, or a negative error code on failure.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_printn_rect(TCOD_Console* console, int x, int y, int width, int height, [NativeTypeName("size_t")] nuint n, [NativeTypeName("const char *restrict")] sbyte* str, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* fg, [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);
        // Managed wrapper for TCOD_console_printn_rect
        public static int TCOD_console_printn_rect(
            TCOD_Console* console,
            int x,
            int y,
            int width,
            int height,
            [NativeTypeName("size_t")] nuint n,
            string str,
            [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* fg,
            [NativeTypeName("const TCOD_ColorRGB *restrict")] TCOD_ColorRGB* bg,
            TCOD_bkgnd_flag_t flag,
            TCOD_alignment_t alignment
        )
        {
            var strPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(str);
            try
            {
                return TCOD_console_printn_rect(console, x, y, width, height, n, (sbyte*)strPtr.ToPointer(), fg, bg, flag, alignment);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(strPtr);
            }
        }


        /// <summary>
        /// Return the height of the word-wrapped text with the given parameters.
        /// </summary>
        /// <param name="console">A pointer to a TCOD_Console.</param>
        /// <param name="x">The starting X position, starting from the left-most tile as zero.</param>
        /// <param name="y">The starting Y position, starting from the upper-most tile as zero.</param>
        /// <param name="width">The maximum width of the bounding region in tiles.</param>
        /// <param name="height">The maximum height of the bounding region in tiles.</param>
        /// <param name="n">The length of the string buffer str[n] in bytes.</param>
        /// <param name="str">The text to print. This string can contain libtcod color codes.</param>
        /// <returns>int The height of the word-wrapped text as if it were printed, or a negative error code on failure.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_height_rect_n(TCOD_Console* console, int x, int y, int width, int height, [NativeTypeName("size_t")] nuint n, [NativeTypeName("const char *restrict")] sbyte* str);

        /// <summary>
        /// Return the height of the word-wrapped text with the given width.
        /// </summary>
        /// <param name="width">The maximum width of the bounding region in tiles.</param>
        /// <param name="n">The length of the string buffer str[n] in bytes.</param>
        /// <param name="str">The text to print. This string can contain libtcod color codes.</param>
        /// <returns>int The height of the word-wrapped text as if it were printed, or a negative error code on failure.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_get_height_rect_wn(int width, [NativeTypeName("size_t")] nuint n, [NativeTypeName("const char *restrict")] sbyte* str);




        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_printf_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, [NativeTypeName("const char *restrict")] sbyte* fmt, __arglist);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_printn_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, int n, [NativeTypeName("const char *restrict")] sbyte* str);
        // Managed wrapper for TCOD_printn_rgb
        public static int TCOD_printn_rgb(
            TCOD_Console* console,
            TCOD_PrintParamsRGB @params,
            int n,
            string str
        )
        {
            var strPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(str);
            try
            {
                return TCOD_printn_rgb(console, @params, n, (sbyte*)strPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(strPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_vprintf_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, [NativeTypeName("const char *restrict")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* args);
        // Managed wrapper for TCOD_vprintf_rgb
        public static int TCOD_vprintf_rgb(
            TCOD_Console* console,
            TCOD_PrintParamsRGB @params,
            string fmt,
            string args
        )
        {
            var fmtPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(fmt);
            var argsPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(args);
            try
            {
                return TCOD_vprintf_rgb(console, @params, (sbyte*)fmtPtr.ToPointer(), (sbyte*)argsPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fmtPtr);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(argsPtr);
            }
        }

    }
}

