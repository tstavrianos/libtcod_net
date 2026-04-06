using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_color_equals_wrapper([NativeTypeName("colornum_t")] uint c1, [NativeTypeName("colornum_t")] uint c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_color_add_wrapper([NativeTypeName("colornum_t")] uint c1, [NativeTypeName("colornum_t")] uint c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_color_subtract_wrapper([NativeTypeName("colornum_t")] uint c1, [NativeTypeName("colornum_t")] uint c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_color_multiply_wrapper([NativeTypeName("colornum_t")] uint c1, [NativeTypeName("colornum_t")] uint c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_color_multiply_scalar_wrapper([NativeTypeName("colornum_t")] uint c1, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_color_lerp_wrapper([NativeTypeName("colornum_t")] uint c1, [NativeTypeName("colornum_t")] uint c2, float coef);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_get_HSV_wrapper([NativeTypeName("colornum_t")] uint c, float* h, float* s, float* v);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_hue_wrapper([NativeTypeName("colornum_t")] uint c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_saturation_wrapper([NativeTypeName("colornum_t")] uint c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_value_wrapper([NativeTypeName("colornum_t")] uint c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_default_background_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("colornum_t")] uint col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_default_foreground_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("colornum_t")] uint col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_console_get_default_background_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_console_get_default_foreground_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_console_get_char_background_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_char_background_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, [NativeTypeName("colornum_t")] uint col, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_console_get_char_foreground_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_char_foreground_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, [NativeTypeName("colornum_t")] uint col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_put_char_ex_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int c, [NativeTypeName("colornum_t")] uint fore, [NativeTypeName("colornum_t")] uint back);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_fade_wrapper([NativeTypeName("uint8_t")] byte val, [NativeTypeName("colornum_t")] uint fade);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_console_get_fading_color_wrapper();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_color_control_wrapper(TCOD_colctrl_t con, [NativeTypeName("colornum_t")] uint fore, [NativeTypeName("colornum_t")] uint back);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_check_for_keypress_wrapper(TCOD_key_t* holder, int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_wait_for_keypress_wrapper(TCOD_key_t* holder, [NativeTypeName("_Bool")] byte flush);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_fill_background([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int* r, int* g, int* b);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_fill_foreground([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int* r, int* g, int* b);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_fill_char([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int* arr);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_double_hline([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int l, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_double_vline([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int l, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_print_double_frame([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int w, int h, [NativeTypeName("_Bool")] byte empty, TCOD_bkgnd_flag_t flag, [NativeTypeName("const char *")] sbyte* fmt, __arglist);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_console_print_return_string([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int rw, int rh, TCOD_bkgnd_flag_t flag, TCOD_alignment_t align, [NativeTypeName("char *")] sbyte* msg, [NativeTypeName("_Bool")] byte can_split, [NativeTypeName("_Bool")] byte count_only);
        // Managed wrapper for TCOD_console_print_return_string
        public static sbyte* TCOD_console_print_return_string(
            [NativeTypeName("TCOD_console_t")] TCOD_Console* con,
            int x,
            int y,
            int rw,
            int rh,
            TCOD_bkgnd_flag_t flag,
            TCOD_alignment_t align,
            string msg,
            [NativeTypeName("_Bool")] byte can_split,
            [NativeTypeName("_Bool")] byte count_only
        )
        {
            var msgPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(msg);
            try
            {
                return TCOD_console_print_return_string(con, x, y, rw, rh, flag, align, (sbyte*)msgPtr.ToPointer(), can_split, count_only);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(msgPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_console_set_key_color_wrapper([NativeTypeName("TCOD_console_t")] TCOD_Console* con, [NativeTypeName("colornum_t")] uint c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_clear_wrapper([NativeTypeName("TCOD_image_t")] TCOD_Image* image, [NativeTypeName("colornum_t")] uint color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_image_get_pixel_wrapper([NativeTypeName("TCOD_image_t")] TCOD_Image* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_image_get_mipmap_pixel_wrapper([NativeTypeName("TCOD_image_t")] TCOD_Image* image, float x0, float y0, float x1, float y1);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_put_pixel_wrapper([NativeTypeName("TCOD_image_t")] TCOD_Image* image, int x, int y, [NativeTypeName("colornum_t")] uint col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_set_key_color_wrapper([NativeTypeName("TCOD_image_t")] TCOD_Image* image, [NativeTypeName("colornum_t")] uint key_color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_mouse_get_status_wrapper(TCOD_mouse_t* holder);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("colornum_t")]
        public static extern uint TCOD_parser_get_color_property_wrapper([NativeTypeName("TCOD_parser_t")] TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_namegen_get_nb_sets_wrapper();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_namegen_get_sets_wrapper([NativeTypeName("char **")] sbyte** sets);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_sys_get_current_resolution_x();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_sys_get_current_resolution_y();
    }
}

