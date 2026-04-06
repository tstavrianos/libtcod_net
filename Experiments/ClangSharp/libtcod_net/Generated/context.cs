using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
/// <summary>
/// A struct of parameters used to create a new context with TCOD_context_new.
/// </summary>
public unsafe partial struct TCOD_ContextParams
    {
        /// Compiled libtcod version for ABI compatiblity with older versions of libtcod.
        public int tcod_version;

        /// window_x and window_y are the starting position of the window.
        public int window_x;

        public int window_y;

        /// pixel_width and pixel_height are the desired size of the window in pixels.
        public int pixel_width;

        public int pixel_height;

        /// columns and rows are the desired size of the terminal window.
        public int columns;

        public int rows;

        /// renderer_type is one of the TCOD_renderer_t values.
        public int renderer_type;

        /// tileset is an optional pointer to a tileset object.
        public TCOD_Tileset* tileset;

        /// If vsync is true, then vertical sync will be enabled whenever possible.
        public int vsync;

        /// sdl_window_flags is a bitfield of SDL_WindowFlags flags.
        public int sdl_window_flags;

        /// window_title will be the title of the opened window.
        [NativeTypeName("const char *")]
        public sbyte* window_title;

        /// The number of items in argv.
        public int argc;

        /// argc and argv are optional CLI parameters.
        [NativeTypeName("const char *const *")]
        public sbyte** argv;

        /// If user attention is required for the given CLI parameters then cli_output will be called with cli_userdata and an error or help message.
        [NativeTypeName("void (*)(void *, const char *)")]
        public delegate* unmanaged[Cdecl]<void*, sbyte*, void> cli_output;

        /// This is passed to the userdata parameter of cli_output if called.
        public void* cli_userdata;

        /// If this is false then window_x/window_y parameters of zero are assumed to be undefined and will be changed to SDL_WINDOWPOS_UNDEFINED.
        [NativeTypeName("_Bool")]
        public byte window_xy_defined;

        public TCOD_Console* console;
    }

    /// <summary>
    /// A rendering context for libtcod.
    /// </summary>
    public unsafe partial struct TCOD_Context
    {
        /// The TCOD_renderer_t value of this context.
        public int type;

        /// A pointer to this contexts unique data.
        [NativeTypeName("void *restrict")]
        public void* contextdata_;

        /// Called when this context is deleted.
        [NativeTypeName("void (*)(struct TCOD_Context *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, void> c_destructor_;

        /// Called to present a console to a contexts display.
        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, const struct TCOD_Console *restrict, const struct TCOD_ViewportOptions *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, TCOD_Console*, TCOD_ViewportOptions*, TCOD_Error> c_present_;

        /// Convert pixel coordinates to the contexts tile coordinates.
        [NativeTypeName("void (*)(struct TCOD_Context *restrict, double *restrict, double *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, double*, double*, void> c_pixel_to_tile_;

        /// Ask this context to save a screenshot.
        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, const char *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, sbyte*, TCOD_Error> c_save_screenshot_;

        /// Return this contexts SDL_Window, if any.
        [NativeTypeName("struct SDL_Window *(*)(struct TCOD_Context *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, void*> c_get_sdl_window_;

        /// Return this contexts SDL_Renderer, if any.
        [NativeTypeName("struct SDL_Renderer *(*)(struct TCOD_Context *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, void*> c_get_sdl_renderer_;

        /// Draw a console without flipping the display.
        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, const struct TCOD_Console *restrict, const struct TCOD_ViewportOptions *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, TCOD_Console*, TCOD_ViewportOptions*, TCOD_Error> c_accumulate_;

        /// Change the tileset used by this context.
        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, TCOD_Tileset *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, TCOD_Tileset*, TCOD_Error> c_set_tileset_;

        /// Output the recommended console size to columns and rows.
        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, float, int *restrict, int *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, float, int*, int*, TCOD_Error> c_recommended_console_size_;

        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, TCOD_ColorRGBA *restrict, int *restrict, int *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, TCOD_ColorRGBA*, int*, int*, TCOD_Error> c_screen_capture_;

        [NativeTypeName("TCOD_Error (*)(struct TCOD_Context *restrict, const TCOD_MouseTransform *restrict)")]
        public delegate* unmanaged[Cdecl]<TCOD_Context*, TCOD_MouseTransform*, TCOD_Error> c_set_mouse_transform_;
    }

    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Delete a rendering context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_context_delete([NativeTypeName("struct TCOD_Context *")] TCOD_Context* renderer);

        /// <summary>
        /// Create an uninitialized rendering context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct TCOD_Context *")]
        public static extern TCOD_Context* TCOD_context_new_();

        /// <summary>
        /// Present a console to the screen, using a rendering context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_present([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, [NativeTypeName("const struct TCOD_Console *")] TCOD_Console* console, [NativeTypeName("const struct TCOD_ViewportOptions *")] TCOD_ViewportOptions* viewport);

        /// <summary>
        /// Convert the screen coordinates to tile coordinates for this context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_d([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, double* x, double* y);

        /// <summary>
        /// Convert the screen coordinates to integer tile coordinates for this context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_i([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, int* x, int* y);

        /// <summary>
        /// Convert the pixel coordinates of SDL mouse events to the tile coordinates of the current context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_convert_event_coordinates([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, [NativeTypeName("union SDL_Event *")] void* @event);

        /// <summary>
        /// Save the last presented console to a PNG file.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_save_screenshot([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_context_save_screenshot
        public static TCOD_Error TCOD_context_save_screenshot(
            [NativeTypeName("struct TCOD_Context *")] TCOD_Context* context,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_context_save_screenshot(context, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        /// <summary>
        /// Return a pointer the SDL_Window for this context if it uses one.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SDL_Window *")]
        public static extern void* TCOD_context_get_sdl_window([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context);

        /// <summary>
        /// Return a pointer the SDL_Renderer for this context if it uses one.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct SDL_Renderer *")]
        public static extern void* TCOD_context_get_sdl_renderer([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context);

        /// <summary>
        /// Change the active tileset for this context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_change_tileset([NativeTypeName("struct TCOD_Context *")] TCOD_Context* self, TCOD_Tileset* tileset);

        /// <summary>
        /// Return the TCOD_renderer_t renderer type for this context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_context_get_renderer_type([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context);

        /// <summary>
        /// Set columns and rows to the recommended console size for this context.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_recommended_console_size([NativeTypeName("struct TCOD_Context *")] TCOD_Context* context, float magnification, [NativeTypeName("int *restrict")] int* columns, [NativeTypeName("int *restrict")] int* rows);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_screen_capture([NativeTypeName("struct TCOD_Context *restrict")] TCOD_Context* context, TCOD_ColorRGBA* out_pixels, [NativeTypeName("int *restrict")] int* width, [NativeTypeName("int *restrict")] int* height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_ColorRGBA* TCOD_context_screen_capture_alloc([NativeTypeName("struct TCOD_Context *restrict")] TCOD_Context* context, [NativeTypeName("int *restrict")] int* width, [NativeTypeName("int *restrict")] int* height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_set_mouse_transform([NativeTypeName("struct TCOD_Context *restrict")] TCOD_Context* context, [NativeTypeName("const TCOD_MouseTransform *restrict")] TCOD_MouseTransform* transform);
    }
}

