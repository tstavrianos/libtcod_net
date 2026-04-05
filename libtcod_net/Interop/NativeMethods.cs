using System.Runtime.InteropServices;

namespace libtcod.Interop;

public static partial class libtcod
{
    private const string DllImportNativeLib = "libtcod";

    #region Console
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_console_new(int w, int h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_get_width(nint con);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_get_height(nint con);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_set_key_color(nint con, TCOD_ColorRGB col);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_blit(
        nint src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        nint dst,
        int xDst,
        int yDst,
        float foreground_alpha,
        float background_alpha
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_blit_key_color(
        nint src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        nint dst,
        int xDst,
        int yDst,
        float foreground_alpha,
        float background_alpha,
        nint key_color
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_delete(nint console);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_clear(nint con);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_ColorRGB TCOD_console_get_char_background(nint con, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_ColorRGB TCOD_console_get_char_foreground(nint con, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_get_char(nint con, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_put_rgb(
        nint console,
        int x,
        int y,
        int ch,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_draw_rect_rgb(
        nint console,
        int x,
        int y,
        int width,
        int height,
        int ch,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        nint decoration,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        [MarshalAs(UnmanagedType.I1)] bool clear
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        [In] int[] decoration,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        [MarshalAs(UnmanagedType.I1)] bool clear
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_console_set_color_control(
        TCOD_colctrl_t con,
        TCOD_ColorRGB fore,
        TCOD_ColorRGB back
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_printn(
        nint console,
        int x,
        int y,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_printn_rect(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_get_height_rect_n(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_console_get_height_rect_wn(
        int width,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_printn_rgb(
        nint console,
        TCOD_PrintParamsRGB @params,
        int n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_flush_ex(nint console, nint viewport);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_console_flush();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_console_from_file(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_asc(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_apf(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_asc(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_apf(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_credits_render_ex(
        nint console,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool alpha,
        float delta_time
    );
    #endregion

    #region Line
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_line(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        TCOD_line_listener_t listener
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_line_init_mt(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        out TCOD_bresenham_data_t data
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_line_step_mt(
        ref int xCur,
        ref int yCur,
        ref TCOD_bresenham_data_t data
    );
    #endregion

    #region Context
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_new(in TCOD_ContextParams @params, out nint @out);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_context_delete(nint renderer);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_present(nint context, nint console, nint viewport);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_d(
        nint context,
        ref double x,
        ref double y
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_i(
        nint context,
        ref int x,
        ref int y
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_save_screenshot(
        nint context,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_context_get_sdl_window(nint context);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_context_get_sdl_renderer(nint context);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_change_tileset(nint self, nint tileset);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_context_get_renderer_type(nint context);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_recommended_console_size(
        nint context,
        float magnification,
        out int columns,
        out int rows
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_screen_capture(
        nint context,
        nint out_pixels,
        ref int width,
        ref int height
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_context_screen_capture_alloc(
        nint context,
        out int width,
        out int height
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_context_set_mouse_transform(nint context, nint transform);
    #endregion

    #region Viewport
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_viewport_new();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_viewport_delete(nint viewport);
    #endregion

    #region Tileset
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_tileset_load(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_tileset_load_mem(
        nuint buffer_length,
        nint buffer,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_tileset_load_raw(
        int width,
        int height,
        nint pixels,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_tileset_delete(nint tileset);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_load_bdf([MarshalAs(UnmanagedType.LPUTF8Str)] string bdf);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_load_bdf_memory(int size, nint buffer);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_load_truetype_font_(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int tile_width,
        int tile_height
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_tileset_load_fallback_font_(int tile_width, int tile_height);
    #endregion

    #region BSP
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_new();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_new_with_size(int x, int y, int w, int h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_bsp_delete(nint node);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_left(nint node);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_right(nint node);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_father(nint node);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_is_leaf(nint node);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_pre_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_in_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_post_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_inverted_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_contains(nint node, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_bsp_find_node(nint node, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_bsp_resize(nint node, int x, int y, int w, int h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_bsp_split_once(
        nint node,
        [MarshalAs(UnmanagedType.I1)] bool horizontal,
        int position
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_bsp_split_recursive(
        nint node,
        nint randomizer,
        int nb,
        int minHSize,
        int minVSize,
        float maxHRatio,
        float maxVRatio
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_bsp_remove_sons(nint node);
    #endregion

    #region REXPaint
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_console_from_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_xp(
        nint console,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_xp(
        nint console,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        int compress_level
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_load_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int n,
        [Out] nint[] @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_load_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int n,
        nint @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_save_xp(
        int n,
        [In] nint[] consoles,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int compress_level
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_save_xp(
        int n,
        nint consoles,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int compress_level
    );
    #endregion

    #region Image
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_image_new(int width, int height);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_image_from_console(nint console);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_refresh_console(nint image, nint console);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_clear(nint image, TCOD_ColorRGB color);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_invert(nint image);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_hflip(nint image);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_rotate90(nint image, int numRotations);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_vflip(nint image);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_scale(nint image, int new_w, int new_h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_image_load([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_image_save(
        nint image,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_get_size(nint image, out int w, out int h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_ColorRGB TCOD_image_get_pixel(nint image, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_image_get_alpha(nint image, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_ColorRGB TCOD_image_get_mipmap_pixel(
        nint image,
        float x0,
        float y0,
        float x1,
        float y1
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_put_pixel(nint image, int x, int y, TCOD_ColorRGB color);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_blit(
        nint image,
        nint console,
        float x,
        float y,
        TCOD_bkgnd_flag_t bkgnd_flag,
        float scale_x,
        float scale_y,
        float angle
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_blit_rect(
        nint image,
        nint console,
        int x,
        int y,
        int w,
        int h,
        TCOD_bkgnd_flag_t bkgnd_flag
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_blit_2x(
        nint image,
        nint dest,
        int dx,
        int dy,
        int sx,
        int sy,
        int w,
        int h
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_delete(nint image);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_image_set_key_color(nint image, TCOD_ColorRGB key_color);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_image_is_pixel_transparent(nint image, int x, int y);
    #endregion

    #region Random
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_random_get_instance();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_random_new(TCOD_random_algo_t algo);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_random_save(nint mersenne);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_random_restore(nint mersenne, nint backup);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_random_new_from_seed(TCOD_random_algo_t algo, uint seed);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_random_delete(nint mersenne);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_random_set_distribution(
        nint mersenne,
        TCOD_distribution_t distribution
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_random_get_int(nint mersenne, int min, int max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_random_get_float(nint mersenne, float min, float max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern double TCOD_random_get_double(nint mersenne, double min, double max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_random_get_int_mean(nint mersenne, int min, int max, int mean);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_random_get_float_mean(
        nint mersenne,
        float min,
        float max,
        float mean
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern double TCOD_random_get_double_mean(
        nint mersenne,
        double min,
        double max,
        double mean
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_dice_t TCOD_random_dice_new(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string s
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_random_dice_roll(nint mersenne, TCOD_dice_t dice);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_random_dice_roll_s(
        nint mersenne,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string s
    );
    #endregion

    #region Path
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_path_new_using_map(nint map, float diagonalCost);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_path_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_compute(nint path, int ox, int oy, int dx, int dy);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_walk(
        nint path,
        out int x,
        out int y,
        [MarshalAs(UnmanagedType.I1)] bool recalculate_when_needed
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_path_is_empty(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_path_size(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_path_reverse(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_path_get(nint path, int index, out int x, out int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_path_get_origin(nint path, out int x, out int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_path_get_destination(nint path, out int x, out int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_path_delete(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_dijkstra_new(nint map, float diagonalCost);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_dijkstra_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_dijkstra_compute(nint dijkstra, int root_x, int root_y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_dijkstra_get_distance(nint dijkstra, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_path_set(nint dijkstra, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_is_empty(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_dijkstra_size(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_dijkstra_reverse(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_dijkstra_get(nint path, int index, out int x, out int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_dijkstra_path_walk(nint dijkstra, out int x, out int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_dijkstra_delete(nint dijkstra);
    #endregion

    #region Heap
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_heap_init(ref TCOD_Heap heap, nuint data_size);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heap_uninit(ref TCOD_Heap heap);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heap_clear(ref TCOD_Heap heap);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_minheap_push(ref TCOD_Heap minheap, int priority, nint data);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_minheap_push(
        ref TCOD_Heap minheap,
        int priority,
        [In] byte[] data
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_minheap_pop(ref TCOD_Heap minheap, nint @out);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_minheap_pop(ref TCOD_Heap minheap, [Out] byte[] @out);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_minheap_heapify(ref TCOD_Heap minheap);
    #endregion

    #region Pathfinder
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_pf_new(int ndim, [In] nuint[] shape);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_pf_new(int ndim, nint shape);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_delete(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_distance_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_distance_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_graph2d_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides,
        int cardinal,
        int diagonal
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_graph2d_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides,
        int cardinal,
        int diagonal
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_traversal_pointer(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_pf_set_traversal_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_pf_recompile(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_pf_compute(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_pf_compute_step(nint path);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_frontier_new(int ndim);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_frontier_delete(nint frontier);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_frontier_pop(nint frontier);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_frontier_push(
        nint frontier,
        nint index,
        int dist,
        int heuristic
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_frontier_push(
        nint frontier,
        [In] int[] index,
        int dist,
        int heuristic
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_frontier_size(nint frontier);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_frontier_clear(nint frontier);
    #endregion

    #region Noise
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_noise_new(
        int dimensions,
        float hurst,
        float lacunarity,
        nint random
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_set_type(nint noise, TCOD_noise_type_t type);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_ex(nint noise, nint f, TCOD_noise_type_t type);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_ex(
        nint noise,
        [In] float[] f,
        TCOD_noise_type_t type
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_fbm_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_fbm_ex(
        nint noise,
        [In] float[] f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_turbulence_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_turbulence_ex(
        nint noise,
        [In] float[] f,
        float octaves,
        TCOD_noise_type_t type
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get(nint noise, nint f);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get(nint noise, [In] float[] f);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_fbm(nint noise, nint f, float octaves);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_fbm(nint noise, [In] float[] f, float octaves);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_turbulence(nint noise, nint f, float octaves);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_noise_get_turbulence(nint noise, [In] float[] f, float octaves);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_delete(nint noise);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_fbm_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_fbm_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_turbulence_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_noise_get_turbulence_vectorized(
        nint noise,
        TCOD_noise_type_t type,
        float octaves,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );
    #endregion

    #region FOV
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_map_new(int width, int height);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_map_clear(
        nint map,
        [MarshalAs(UnmanagedType.I1)] bool transparent,
        [MarshalAs(UnmanagedType.I1)] bool walkable
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_map_copy(nint source, nint dest);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_map_set_properties(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool is_transparent,
        [MarshalAs(UnmanagedType.I1)] bool is_walkable
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_map_delete(nint map);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_map_compute_fov(
        nint map,
        int pov_x,
        int pov_y,
        int max_radius,
        [MarshalAs(UnmanagedType.I1)] bool light_walls,
        TCOD_fov_algorithm_t algo
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_in_fov(nint map, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_map_set_in_fov(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool fov
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_transparent(nint map, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_map_is_walkable(nint map, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_map_get_width(nint map);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_map_get_height(nint map);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_map_get_nb_cells(nint map);
    #endregion

    #region Heightmap
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_heightmap_new(int w, int h);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_delete(nint hm);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_heightmap_get_interpolated_value(nint hm, float x, float y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern float TCOD_heightmap_get_slope(nint hm, int x, int y);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_get_normal(
        nint hm,
        float x,
        float y,
        [Out] float[] n,
        float waterLevel
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern int TCOD_heightmap_count_cells(nint hm, float min, float max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_heightmap_has_land_on_border(nint hm, float waterLevel);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_get_minmax(
        nint heightmap,
        out float min_out,
        out float max_out
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_copy(nint hm_source, nint hm_dest);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_add(nint hm, float value);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_scale(nint hm, float value);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_clamp(nint hm, float min, float max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_normalize(nint hm, float min, float max);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_clear(nint hm);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_lerp_hm(nint hm1, nint hm2, nint @out, float coef);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_add_hm(nint hm1, nint hm2, nint @out);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_multiply_hm(nint hm1, nint hm2, nint @out);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_add_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_dig_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_dig_bezier(
        nint hm,
        nint px,
        nint py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_rain_erosion(
        nint hm,
        int nbDrops,
        float erosionCoef,
        float sedimentationCoef,
        nint rnd
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        nint dx,
        nint dy,
        nint weight,
        float minLevel,
        float maxLevel
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_threshold_mask(
        nint hm,
        [Out] byte[] mask,
        float minLevel,
        float maxLevel
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_kernel_transform_out(
        nint hm_src,
        nint hm_dst,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        [In] byte[] mask
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_kernel_transform_out(
        nint hm_src,
        nint hm_dst,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        nint mask
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_add_voronoi(
        nint hm,
        int nbPoints,
        int nbCoef,
        [In] float[] coef,
        nint rnd
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_mid_point_displacement(
        nint hm,
        nint rnd,
        float roughness
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_add_fbm(
        nint hm,
        nint noise,
        float mul_x,
        float mul_y,
        float add_x,
        float add_y,
        float octaves,
        float delta,
        float scale
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_heightmap_scale_fbm(
        nint hm,
        nint noise,
        float mul_x,
        float mul_y,
        float add_x,
        float add_y,
        float octaves,
        float delta,
        float scale
    );
    #endregion

    #region Sys
    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_sys_update_char(
        int asciiCode,
        int font_x,
        int font_y,
        nint img,
        int x,
        int y
    );

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_sys_get_SDL_window();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern nint TCOD_sys_get_SDL_renderer();

    #endregion

    #region Error

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true,
        EntryPoint = "TCOD_get_error"
    )]
    private static extern nint TCOD_get_error_();

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern TCOD_Error TCOD_set_error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    [DllImport(
        DllImportNativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true
    )]
    public static extern void TCOD_clear_error();

    #endregion
}
