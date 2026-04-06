using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_new(in TCOD_ContextParams @params, out nint @out);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_context_delete(nint renderer);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_present(nint context, nint console, nint viewport);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_d(
        nint context,
        ref double x,
        ref double y
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_i(
        nint context,
        ref int x,
        ref int y
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_save_screenshot(
        nint context,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_context_get_sdl_window(nint context);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_context_get_sdl_renderer(nint context);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_change_tileset(nint self, nint tileset);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_context_get_renderer_type(nint context);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_recommended_console_size(
        nint context,
        float magnification,
        out int columns,
        out int rows
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_screen_capture(
        nint context,
        nint out_pixels,
        ref int width,
        ref int height
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_context_screen_capture_alloc(
        nint context,
        out int width,
        out int height
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_context_set_mouse_transform(nint context, nint transform);
}
