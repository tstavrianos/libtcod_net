using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
/// <summary>
/// An SDL tileset atlas.
/// </summary>
public unsafe partial struct TCOD_TilesetAtlasSDL2
    {
        /// The renderer used to create this atlas.
        [NativeTypeName("struct SDL_Renderer *")]
        public void* renderer;

        /// The atlas texture.
        [NativeTypeName("struct SDL_Texture *")]
        public void* texture;

        /// The tileset used to create this atlas.
        [NativeTypeName("struct TCOD_Tileset *")]
        public TCOD_Tileset* tileset;

        /// Internal use only.
        [NativeTypeName("struct TCOD_TilesetObserver *")]
        public TCOD_TilesetObserver* observer;

        /// Internal use only.
        public int texture_columns;
    }

    /// <summary>
    /// The renderer data for an SDL rendering context.
    /// </summary>
    public unsafe partial struct TCOD_RendererSDL2
    {
        [NativeTypeName("struct SDL_Window *")]
        public void* window;

        [NativeTypeName("struct SDL_Renderer *")]
        public void* renderer;

        [NativeTypeName("struct TCOD_TilesetAtlasSDL2 *restrict")]
        public TCOD_TilesetAtlasSDL2* atlas;

        [NativeTypeName("struct TCOD_Console *restrict")]
        public TCOD_Console* cache_console;

        [NativeTypeName("struct SDL_Texture *restrict")]
        public void* cache_texture;

        [NativeTypeName("uint32_t")]
        public uint sdl_subsystems;

        public TCOD_MouseTransform cursor_transform;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct TCOD_Context *")]
        public static extern TCOD_Context* TCOD_renderer_init_sdl2(int x, int y, int width, int height, [NativeTypeName("const char *")] sbyte* title, int window_flags, int vsync, [NativeTypeName("struct TCOD_Tileset *")] TCOD_Tileset* tileset);
        // Managed wrapper for TCOD_renderer_init_sdl2
        public static TCOD_Context* TCOD_renderer_init_sdl2(
            int x,
            int y,
            int width,
            int height,
            string title,
            int window_flags,
            int vsync,
            [NativeTypeName("struct TCOD_Tileset *")] TCOD_Tileset* tileset
        )
        {
            var titlePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(title);
            try
            {
                return TCOD_renderer_init_sdl2(x, y, width, height, (sbyte*)titlePtr.ToPointer(), window_flags, vsync, tileset);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(titlePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Context* TCOD_renderer_init_sdl3([NativeTypeName("SDL_PropertiesID")] uint window_props, [NativeTypeName("SDL_PropertiesID")] uint renderer_props, [NativeTypeName("struct TCOD_Tileset *")] TCOD_Tileset* tileset);

        /// <summary>
        /// Return a new SDL atlas created from a tileset for an SDL3 renderer.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct TCOD_TilesetAtlasSDL2 *")]
        public static extern TCOD_TilesetAtlasSDL2* TCOD_sdl2_atlas_new([NativeTypeName("struct SDL_Renderer *")] void* renderer, [NativeTypeName("struct TCOD_Tileset *")] TCOD_Tileset* tileset);

        /// <summary>
        /// Delete an SDL tileset atlas.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_sdl2_atlas_delete([NativeTypeName("struct TCOD_TilesetAtlasSDL2 *")] TCOD_TilesetAtlasSDL2* atlas);

        /// <summary>
        /// Setup a cache and target texture for rendering.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_sdl2_render_texture_setup([NativeTypeName("const struct TCOD_TilesetAtlasSDL2 *restrict")] TCOD_TilesetAtlasSDL2* atlas, [NativeTypeName("const struct TCOD_Console *restrict")] TCOD_Console* console, [NativeTypeName("struct TCOD_Console *restrict *")] TCOD_Console** cache, [NativeTypeName("struct SDL_Texture *restrict *")] void** target);

        /// <summary>
        /// Render a console onto a managed target texture.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_sdl2_render_texture([NativeTypeName("const struct TCOD_TilesetAtlasSDL2 *restrict")] TCOD_TilesetAtlasSDL2* atlas, [NativeTypeName("const struct TCOD_Console *restrict")] TCOD_Console* console, [NativeTypeName("struct TCOD_Console *restrict")] TCOD_Console* cache, [NativeTypeName("struct SDL_Texture *restrict")] void* target);
    }
}

