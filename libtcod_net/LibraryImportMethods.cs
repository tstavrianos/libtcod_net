using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class LibraryImportMethods
{
    private const string NativeLib = "libtcod";

    #region Console
    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_console_new(int w, int h);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_get_width")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_get_width(nint con);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_get_height")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_get_height(nint con);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_set_key_color")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_set_key_color(nint con, TCOD_ColorRGB col);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_blit")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_blit(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_blit_key_color")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_blit_key_color(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_delete(nint console);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_clear(nint con);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_get_char_background")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial TCOD_ColorRGB TCOD_console_get_char_background(nint con, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_get_char_foreground")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial TCOD_ColorRGB TCOD_console_get_char_foreground(nint con, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_get_char")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_get_char(nint con, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_put_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_put_rgb_ptr(
        nint console,
        int x,
        int y,
        int ch,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_draw_rect_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_draw_rect_rgb_ptr(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_draw_frame_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_draw_frame_rgb_ptr(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_set_color_control")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_set_color_control(
        TCOD_colctrl_t con,
        TCOD_ColorRGB fore,
        TCOD_ColorRGB back
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_printn",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_printn_ptr(
        nint console,
        int x,
        int y,
        nuint n,
        string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_printn_rect",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_printn_rect_ptr(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_get_height_rect_n",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_get_height_rect_n(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        string str
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_get_height_rect_wn",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_get_height_rect_wn(int width, nuint n, string str);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_printn_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_printn_rgb(
        nint console,
        TCOD_PrintParamsRGB @params,
        int n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_flush_ex")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_flush_ex(nint console, nint viewport);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_flush")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_flush();

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_from_file",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_console_from_file(string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_load_asc",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_load_asc(nint con, string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_load_apf",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_load_apf(nint con, string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_save_asc",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_save_asc(nint con, string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_save_apf",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_save_apf(nint con, string filename);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_credits_render_ex")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_credits_render_ex(
        nint console,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool alpha,
        float delta_time
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_put_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_console_put_rgb_struct(
        nint console,
        int x,
        int y,
        int ch,
        TCOD_ColorRGB fg,
        TCOD_ColorRGB bg,
        TCOD_bkgnd_flag_t flag
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_draw_rect_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_draw_rect_rgb_struct(
        nint console,
        int x,
        int y,
        int width,
        int height,
        int ch,
        TCOD_ColorRGB fg,
        TCOD_ColorRGB bg,
        TCOD_bkgnd_flag_t flag
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_console_draw_frame_rgb")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_console_draw_frame_rgb_struct(
        nint con,
        int x,
        int y,
        int width,
        int height,
        nint decoration,
        TCOD_ColorRGB fg,
        TCOD_ColorRGB bg,
        TCOD_bkgnd_flag_t flag,
        [MarshalAs(UnmanagedType.I1)] bool clear
    );

    #endregion

    #region Line
    [LibraryImport(NativeLib, EntryPoint = "TCOD_line")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_line(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        TCOD_line_listener_t listener
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_line_init_mt")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_line_init_mt(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo,
        out TCOD_bresenham_data_t data
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_line_step_mt")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_line_step_mt(
        ref int xCur,
        ref int yCur,
        ref TCOD_bresenham_data_t data
    );

    #endregion

    #region Context
    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_new_ptr(nint @params, out nint @out);

    // Note: Use NativeMethods.TCOD_context_new for passing TCOD_ContextParams by ref
    // LibraryImport doesn't handle 'in' struct parameters well

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_context_delete(nint renderer);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_present")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_present(nint context, nint console, nint viewport);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_screen_pixel_to_tile_d")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_screen_pixel_to_tile_d(
        nint context,
        ref double x,
        ref double y
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_screen_pixel_to_tile_i")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_screen_pixel_to_tile_i(
        nint context,
        ref int x,
        ref int y
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_convert_event_coordinates")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_convert_event_coordinates(nint context, nint @event);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_context_save_screenshot",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_save_screenshot(nint context, string? filename);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_get_sdl_window")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_context_get_sdl_window(nint context);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_get_sdl_renderer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_context_get_sdl_renderer(nint context);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_change_tileset")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_change_tileset(nint self, nint tileset);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_get_renderer_type")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_get_renderer_type(nint context);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_recommended_console_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_recommended_console_size(
        nint context,
        float magnification,
        out int columns,
        out int rows
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_screen_capture")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_screen_capture(
        nint context,
        nint out_pixels,
        ref int width,
        ref int height
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_screen_capture_alloc")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_context_screen_capture_alloc(
        nint context,
        out int width,
        out int height
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_context_set_mouse_transform")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_context_set_mouse_transform(nint context, nint transform);

    #endregion

    #region Viewport
    [LibraryImport(NativeLib, EntryPoint = "TCOD_viewport_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_viewport_new();

    [LibraryImport(NativeLib, EntryPoint = "TCOD_viewport_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_viewport_delete(nint viewport);

    #endregion

    #region Tileset
    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_tileset_load",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load(
        string filename,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_load_mem")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load_mem(
        nint buffer_length,
        nint buffer,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_load_mem")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load_mem_bytes(
        nint buffer_length,
        [In] byte[] buffer,
        int columns,
        int rows,
        int n,
        [In] int[] charmap
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_load_raw")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load_raw(
        int width,
        int height,
        [In] TCOD_ColorRGBA[] pixels,
        int columns,
        int rows,
        int n,
        [In] int[] charmap
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_load_raw")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load_raw_ptr(
        int width,
        int height,
        nint pixels,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_tileset_delete(nint tileset);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_load_bdf",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_load_bdf(string bdf);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_load_bdf_memory")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_load_bdf_memory(int size, nint buffer);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_load_bdf_memory")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_load_bdf_memory_bytes(int size, [In] byte[] buffer);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_load_truetype_font_",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_load_truetype_font_(int tile_width, int tile_height);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_tileset_load_fallback_font_")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_tileset_load_fallback_font_(int tile_width, int tile_height);

    #endregion

    #region BSP
    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_new();

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_new_with_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_new_with_size(int x, int y, int w, int h);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_bsp_delete(nint node);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_left")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_left(nint node);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_right")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_right(nint node);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_father")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_father(nint node);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_is_leaf")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_is_leaf(nint node);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_traverse_pre_order")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_traverse_pre_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_traverse_in_order")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_traverse_in_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_traverse_post_order")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_traverse_post_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_traverse_level_order")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_traverse_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_traverse_inverted_level_order")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_traverse_inverted_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_contains")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_bsp_contains(nint node, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_find_node")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_bsp_find_node(nint node, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_resize")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_bsp_resize(nint node, int x, int y, int w, int h);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_split_once")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_bsp_split_once(
        nint node,
        [MarshalAs(UnmanagedType.I1)] bool horizontal,
        int position
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_split_recursive")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_bsp_split_recursive(
        nint node,
        nint randomizer,
        int nb,
        int minHSize,
        int minVSize,
        float maxHRatio,
        float maxVRatio
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_bsp_remove_sons")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_bsp_remove_sons(nint node);

    #endregion

    #region REXPaint
    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_from_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_console_from_xp(string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_load_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_load_xp(nint console, string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_console_save_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_console_save_xp(
        nint console,
        string filename,
        int compress_level
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_load_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_load_xp_array(string path, int n, [Out] nint[] @out);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_load_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_load_xp_ptr(string path, int n, nint @out);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_save_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_save_xp_array(
        int n,
        [In] nint[] consoles,
        string path,
        int compress_level
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_save_xp",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_save_xp_ptr(
        int n,
        nint consoles,
        string path,
        int compress_level
    );

    #endregion

    #region Image
    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_image_new(int width, int height);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_from_console")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_image_from_console(nint console);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_refresh_console")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_refresh_console(nint image, nint console);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_clear(nint image, TCOD_ColorRGB color);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_invert")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_invert(nint image);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_hflip")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_hflip(nint image);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_rotate90")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_rotate90(nint image, int numRotations);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_vflip")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_vflip(nint image);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_scale")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_scale(nint image, int new_w, int new_h);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_image_load",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_image_load(string filename);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_image_save",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_image_save(nint image, string filename);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_get_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_get_size(nint image, out int w, out int h);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_get_pixel")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial TCOD_ColorRGB TCOD_image_get_pixel(nint image, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_get_alpha")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_image_get_alpha(nint image, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_get_mipmap_pixel")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial TCOD_ColorRGB TCOD_image_get_mipmap_pixel(
        nint image,
        float x0,
        float y0,
        float x1,
        float y1
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_put_pixel")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_put_pixel(nint image, int x, int y, TCOD_ColorRGB color);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_blit")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_blit(
        nint image,
        nint console,
        float x,
        float y,
        TCOD_bkgnd_flag_t bkgnd_flag,
        float scale_x,
        float scale_y,
        float angle
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_blit_rect")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_blit_rect(
        nint image,
        nint console,
        int x,
        int y,
        int w,
        int h,
        TCOD_bkgnd_flag_t bkgnd_flag
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_blit_2x")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_blit_2x(
        nint image,
        nint dest,
        int dx,
        int dy,
        int sx,
        int sy,
        int w,
        int h
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_delete(nint image);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_set_key_color")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_image_set_key_color(nint image, TCOD_ColorRGB key_color);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_image_is_pixel_transparent")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_image_is_pixel_transparent(nint image, int x, int y);

    #endregion

    #region Random
    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_random_new(TCOD_random_algo_t algo);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_new_from_seed")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_random_new_from_seed(TCOD_random_algo_t algo, uint seed);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_int")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_random_get_int(nint mersenne, int min, int max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_float")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_random_get_float(nint mersenne, float min, float max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_random_delete(nint mersenne);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_instance")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_random_get_instance();

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_save")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_random_save(nint mersenne);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_restore")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_random_restore(nint mersenne, nint backup);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_set_distribution")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_random_set_distribution(
        nint mersenne,
        TCOD_distribution_t distribution
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_double")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double TCOD_random_get_double(nint mersenne, double min, double max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_int_mean")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_random_get_int_mean(nint mersenne, int min, int max, int mean);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_float_mean")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_random_get_float_mean(
        nint mersenne,
        float min,
        float max,
        float mean
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_get_double_mean")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial double TCOD_random_get_double_mean(
        nint mersenne,
        double min,
        double max,
        double mean
    );

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_random_dice_new",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial TCOD_dice_t TCOD_random_dice_new(string s);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_random_dice_roll")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_random_dice_roll(nint mersenne, TCOD_dice_t dice);

    [LibraryImport(
        NativeLib,
        EntryPoint = "TCOD_random_dice_roll_s",
        StringMarshalling = StringMarshalling.Utf8
    )]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_random_dice_roll_s(nint mersenne, string s);

    #endregion

    #region Path
    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_dijkstra_new(nint map, float diagonalCost);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_new_using_function")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_dijkstra_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_compute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_dijkstra_compute(nint dijkstra, int root_x, int root_y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_get_distance")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_dijkstra_get_distance(nint dijkstra, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_path_set")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_dijkstra_path_set(nint dijkstra, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_is_empty")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_dijkstra_is_empty(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_dijkstra_size(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_reverse")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_dijkstra_reverse(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_get")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_dijkstra_get(nint path, int index, out int x, out int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_path_walk")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_dijkstra_path_walk(nint dijkstra, out int x, out int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_dijkstra_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_dijkstra_delete(nint dijkstra);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_new_using_map")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_path_new_using_map(nint map, float diagonalCost);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_new_using_function")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_path_new_using_function(
        int map_width,
        int map_height,
        TCOD_path_func_t func,
        nint user_data,
        float diagonalCost
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_compute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_path_compute(nint path, int ox, int oy, int dx, int dy);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_walk")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_path_walk(
        nint path,
        out int x,
        out int y,
        [MarshalAs(UnmanagedType.I1)] bool recalculate_when_needed
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_is_empty")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_path_is_empty(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_size")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_path_size(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_reverse")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_path_reverse(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_get")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_path_get(nint path, int index, out int x, out int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_get_origin")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_path_get_origin(nint path, out int x, out int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_get_destination")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_path_get_destination(nint path, out int x, out int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_path_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_path_delete(nint path);

    #endregion

    #region Heap
    [LibraryImport(NativeLib, EntryPoint = "TCOD_heap_init")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_heap_init(ref TCOD_Heap heap, nuint data_size);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heap_uninit")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heap_uninit(ref TCOD_Heap heap);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heap_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heap_clear(ref TCOD_Heap heap);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_minheap_push")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_minheap_push(ref TCOD_Heap minheap, int priority, nint data);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_minheap_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_minheap_pop(ref TCOD_Heap minheap, nint @out);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_minheap_heapify")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_minheap_heapify(ref TCOD_Heap minheap);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_minheap_pop")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_minheap_pop_bytes(ref TCOD_Heap minheap, [Out] byte[] @out);

    #endregion

    #region Pathfinder
    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_pf_new(int ndim, nint shape);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_delete(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_distance_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_distance_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_graph2d_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_graph2d_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides,
        int cardinal,
        int diagonal
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_traversal_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_traversal_pointer(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_recompile")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_pf_recompile(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_compute")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_pf_compute(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_compute_step")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_pf_compute_step(nint path);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_pf_new_array(int ndim, [In] nuint[] shape);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_pf_new_ptr(int ndim, nint shape);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_distance_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_distance_pointer_array(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_distance_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_distance_pointer_ptr(
        nint path,
        nint data,
        int int_type,
        nint strides
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_graph2d_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_graph2d_pointer_array(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides,
        int cardinal,
        int diagonal
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_graph2d_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_graph2d_pointer_ptr(
        nint path,
        nint data,
        int int_type,
        nint strides,
        int cardinal,
        int diagonal
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_traversal_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_traversal_pointer_array(
        nint path,
        nint data,
        int int_type,
        [In] nuint[] strides
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_pf_set_traversal_pointer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_pf_set_traversal_pointer_ptr(
        nint path,
        nint data,
        int int_type,
        nint strides
    );
    #endregion

    #region Noise

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_noise_new(
        int dimensions,
        float hurst,
        float lacunarity,
        nint random
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_set_type")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_set_type(nint noise, TCOD_noise_type_t type);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_ex")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get_ex(nint noise, nint f, TCOD_noise_type_t type);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_fbm_ex")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get_fbm_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_turbulence_ex")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get_turbulence_ex(
        nint noise,
        nint f,
        float octaves,
        TCOD_noise_type_t type
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get(nint noise, nint f);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_fbm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get_fbm(nint noise, nint f, float octaves);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_turbulence")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_noise_get_turbulence(nint noise, nint f, float octaves);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_delete(nint noise);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_vectorized_array(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        [In] float[] x,
        [In] float[] y,
        [In] float[] z,
        [In] float[] w,
        [Out] float[] @out
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_vectorized_ptr(
        nint noise,
        TCOD_noise_type_t type,
        int n,
        nint x,
        nint y,
        nint z,
        nint w,
        nint @out
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_fbm_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_fbm_vectorized_array(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_fbm_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_fbm_vectorized_ptr(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_turbulence_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_turbulence_vectorized_array(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_noise_get_turbulence_vectorized")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_noise_get_turbulence_vectorized_ptr(
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
    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_map_new(int width, int height);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_map_clear(
        nint map,
        [MarshalAs(UnmanagedType.I1)] bool transparent,
        [MarshalAs(UnmanagedType.I1)] bool walkable
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_copy")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_map_copy(nint source, nint dest);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_set_properties")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_map_set_properties(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool is_transparent,
        [MarshalAs(UnmanagedType.I1)] bool is_walkable
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_map_delete(nint map);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_compute_fov")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_map_compute_fov(
        nint map,
        int pov_x,
        int pov_y,
        int max_radius,
        [MarshalAs(UnmanagedType.I1)] bool light_walls,
        TCOD_fov_algorithm_t algo
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_is_in_fov")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_map_is_in_fov(nint map, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_set_in_fov")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_map_set_in_fov(
        nint map,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool fov
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_is_transparent")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_map_is_transparent(nint map, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_is_walkable")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_map_is_walkable(nint map, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_get_width")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_map_get_width(nint map);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_get_height")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_map_get_height(nint map);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_map_get_nb_cells")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_map_get_nb_cells(nint map);

    #endregion

    #region Heightmap
    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_new")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_heightmap_new(int w, int h);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_delete")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_delete(nint hm);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_get_interpolated_value")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_heightmap_get_interpolated_value(nint hm, float x, float y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_get_slope")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial float TCOD_heightmap_get_slope(nint hm, int x, int y);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_get_normal")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_get_normal(
        nint hm,
        float x,
        float y,
        [Out] float[] n,
        float waterLevel
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_count_cells")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial int TCOD_heightmap_count_cells(nint hm, float min, float max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_has_land_on_border")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool TCOD_heightmap_has_land_on_border(nint hm, float waterLevel);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_get_minmax")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_get_minmax(
        nint heightmap,
        out float min_out,
        out float max_out
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_copy")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_copy(nint hm_source, nint hm_dest);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_add")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_add(nint hm, float value);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_scale")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_scale(nint hm, float value);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_clamp")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_clamp(nint hm, float min, float max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_normalize")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_normalize(nint hm, float min, float max);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_clear")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_clear(nint hm);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_lerp_hm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_lerp_hm(nint hm1, nint hm2, nint @out, float coef);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_add_hm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_add_hm(nint hm1, nint hm2, nint @out);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_multiply_hm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_multiply_hm(nint hm1, nint hm2, nint @out);

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_add_hill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_add_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_dig_hill")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_dig_hill(
        nint hm,
        float hx,
        float hy,
        float h_radius,
        float h_height
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_dig_bezier")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_dig_bezier(
        nint hm,
        [In] int[] px,
        [In] int[] py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_rain_erosion")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_rain_erosion(
        nint hm,
        int nbDrops,
        float erosionCoef,
        float sedimentationCoef,
        nint rnd
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_kernel_transform")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        float minLevel,
        float maxLevel
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_threshold_mask")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_threshold_mask(
        nint hm,
        [Out] byte[] mask,
        float minLevel,
        float maxLevel
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_kernel_transform_out")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_kernel_transform_out(
        nint hm_src,
        nint hm_dst,
        int kernel_size,
        [In] int[] dx,
        [In] int[] dy,
        [In] float[] weight,
        [In] byte[] mask
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_add_voronoi")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_add_voronoi(
        nint hm,
        int nbPoints,
        int nbCoef,
        [In] float[] coef,
        nint rnd
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_mid_point_displacement")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_mid_point_displacement(
        nint hm,
        nint rnd,
        float roughness
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_add_fbm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_add_fbm(
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

    [LibraryImport(NativeLib, EntryPoint = "TCOD_heightmap_scale_fbm")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_heightmap_scale_fbm(
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
    [LibraryImport(NativeLib, EntryPoint = "TCOD_sys_update_char")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial void TCOD_sys_update_char(
        int asciiCode,
        int font_x,
        int font_y,
        nint img,
        int x,
        int y
    );

    [LibraryImport(NativeLib, EntryPoint = "TCOD_sys_get_SDL_window")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_sys_get_SDL_window();

    [LibraryImport(NativeLib, EntryPoint = "TCOD_sys_get_SDL_renderer")]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static partial nint TCOD_sys_get_SDL_renderer();

    #endregion
}
