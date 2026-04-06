using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
public unsafe partial struct TCOD_internal_context_t
    {
        public int fontNbCharHoriz;

        public int fontNbCharVertic;

        [NativeTypeName("_Bool")]
        public byte font_tcod_layout;

        [NativeTypeName("_Bool")]
        public byte font_in_row;

        [NativeTypeName("_Bool")]
        public byte font_greyscale;

        public int font_flags;

        public int font_width;

        public int font_height;

        [NativeTypeName("char[512]")]
        public _font_file_e__FixedBuffer font_file;

        [NativeTypeName("char[512]")]
        public _window_title_e__FixedBuffer window_title;

        public int* ascii_to_tcod;

        [NativeTypeName("_Bool *")]
        public bool* colored;

        [NativeTypeName("struct TCOD_Console *")]
        public TCOD_Console* root;

        public int max_font_chars;

        [NativeTypeName("_Bool")]
        public byte fullscreen;

        public int fullscreen_offset_x;

        public int fullscreen_offset_y;

        public int fullscreen_width;

        public int fullscreen_height;

        public int actual_fullscreen_width;

        public int actual_fullscreen_height;

        [NativeTypeName("SDL_renderer_t")]
        public delegate* unmanaged[Cdecl]<void*, void> sdl_cbk;

        [NativeTypeName("TCOD_color_t")]
        public TCOD_ColorRGB fading_color;

        [NativeTypeName("uint8_t")]
        public byte fade;

        [Obsolete("The libtcod event API has been deprecated, switch to using SDL event types exclusively")]
        public TCOD_key_t key_state;

        [NativeTypeName("_Bool")]
        public byte is_window_closed;

        [NativeTypeName("_Bool")]
        public byte app_has_mouse_focus;

        [NativeTypeName("_Bool")]
        public byte app_is_active;

        /// Active tileset for libtcod.
        [NativeTypeName("struct TCOD_Tileset *")]
        public TCOD_Tileset* tileset;

        [NativeTypeName("struct TCOD_Context *")]
        public TCOD_Context* engine;

        [InlineArray(512)]
        public partial struct _font_file_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(512)]
        public partial struct _window_title_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct scale_data_t
    {
        public float force_recalc;

        public float last_scale_xc;

        public float last_scale_yc;

        public float last_scale_factor;

        [NativeTypeName("_Bool")]
        public byte last_fullscreen;

        public float min_scale_factor;

        public float src_height_width_ratio;

        public float dst_height_width_ratio;

        public int src_x0;

        public int src_y0;

        public int src_copy_width;

        public int src_copy_height;

        public int src_proportionate_width;

        public int src_proportionate_height;

        public int dst_display_width;

        public int dst_display_height;

        public int dst_offset_x;

        public int dst_offset_y;

        public int surface_width;

        public int surface_height;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_circular_raycasting(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_diamond_raycasting(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_recursive_shadowcasting(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_permissive2(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls, int permissiveness);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_restrictive_shadowcasting(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov_symmetric_shadowcast(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_postprocess(TCOD_Map* map, int pov_x, int pov_y, int radius);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_key_t TCOD_sys_check_for_keypress(int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_key_t TCOD_sys_wait_for_keypress([NativeTypeName("_Bool")] byte flush);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_sys_is_key_pressed(TCOD_keycode_t key);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_pixel_to_tile(double* x, double* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_print_internal(TCOD_Console* con, int x, int y, int w, int h, TCOD_bkgnd_flag_t flag, TCOD_alignment_t align, [NativeTypeName("char *")] sbyte* msg, [NativeTypeName("_Bool")] byte can_split, [NativeTypeName("_Bool")] byte count_only);
        // Managed wrapper for TCOD_console_print_internal
        public static int TCOD_console_print_internal(
            TCOD_Console* con,
            int x,
            int y,
            int w,
            int h,
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
                return TCOD_console_print_internal(con, x, y, w, h, flag, align, (sbyte*)msgPtr.ToPointer(), can_split, count_only);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(msgPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_console_vsprint([NativeTypeName("const char *")] sbyte* fmt, [NativeTypeName("va_list")] sbyte* ap);
        // Managed wrapper for TCOD_console_vsprint
        public static sbyte* TCOD_console_vsprint(
            string fmt,
            string ap
        )
        {
            var fmtPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(fmt);
            var apPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(ap);
            try
            {
                return TCOD_console_vsprint((sbyte*)fmtPtr.ToPointer(), (sbyte*)apPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fmtPtr);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(apPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* TCOD_console_vsprint_utf([NativeTypeName("const wchar_t *")] ushort* fmt, [NativeTypeName("va_list")] sbyte* ap);
        // Managed wrapper for TCOD_console_vsprint_utf
        public static ushort* TCOD_console_vsprint_utf(
            [NativeTypeName("const wchar_t *")] ushort* fmt,
            string ap
        )
        {
            var apPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(ap);
            try
            {
                return TCOD_console_vsprint_utf(fmt, (sbyte*)apPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(apPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_print_internal_utf([NativeTypeName("TCOD_console_t")] TCOD_Console* con, int x, int y, int rw, int rh, TCOD_bkgnd_flag_t flag, TCOD_alignment_t align, [NativeTypeName("wchar_t *")] ushort* msg, [NativeTypeName("_Bool")] byte can_split, [NativeTypeName("_Bool")] byte count_only);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SDL_Surface *")]
        public static extern void* TCOD_sys_load_image([NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_sys_load_image
        public static void* TCOD_sys_load_image(
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_sys_load_image((sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_get_image_size([NativeTypeName("const struct SDL_Surface *")] void* image, int* w, int* h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_sys_get_image_pixel([NativeTypeName("const struct SDL_Surface *")] void* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_sys_get_image_alpha([NativeTypeName("const struct SDL_Surface *")] void* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_sys_check_magic_number([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("size_t")] nuint size, [NativeTypeName("uint8_t *")] byte* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_set_size([NativeTypeName("TCOD_list_t")] TCOD_List* l, int size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_console_stringLength([NativeTypeName("const unsigned char *")] byte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned char *")]
        public static extern byte* TCOD_console_forward([NativeTypeName("unsigned char *")] byte* s, int l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void sync_time_();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_map_ascii_to_font(int asciiCode, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_decode_font_();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_sys_save_bitmap([NativeTypeName("struct SDL_Surface *")] void* bitmap, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_sys_save_bitmap
        public static TCOD_Error TCOD_sys_save_bitmap(
            [NativeTypeName("struct SDL_Surface *")] void* bitmap,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_sys_save_bitmap(bitmap, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_save_fps();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sys_restore_fps();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_sys_load_player_config();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_event_t TCOD_sys_handle_mouse_event([NativeTypeName("const union SDL_Event *")] void* ev, TCOD_mouse_t* mouse);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_event_t TCOD_sys_handle_key_event([NativeTypeName("const union SDL_Event *")] void* ev, TCOD_key_t* key);
    }
}

