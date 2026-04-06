using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a rendering context.
/// </summary>
public sealed unsafe class Context : TCODResource<TCOD_Context>
{
    private Context(TCOD_Context* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Context with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
    }

    /// <summary>
    /// Creates a new rendering context with the specified parameters.
    /// </summary>
    /// <param name="columns">The number of columns in the console.</param>
    /// <param name="rows">The number of rows in the console.</param>
    /// <param name="windowX">The x-coordinate of the window.</param>
    /// <param name="windowY">The y-coordinate of the window.</param>
    /// <param name="pixelWidth">The width of the window in pixels.</param>
    /// <param name="pixelHeight">The height of the window in pixels.</param>
    /// <param name="rendererType">The type of renderer to use.</param>
    /// <param name="tileset">The tileset to use.</param>
    /// <param name="vsync">Whether to enable vertical synchronization.</param>
    /// <param name="sdlWindowFlags">Flags for the SDL window.</param>
    /// <param name="windowTitle">The title of the window.</param>
    /// <param name="windowXYDefined">If set to false, windowX and windowY of zero will be set to SDL_WINDOWPOS_UNDEFINED.</param>
    /// <param name="console">The console to use.</param>
    /// <returns>A new Context instance.</returns>
    public static Context Create(
        int columns,
        int rows,
        int windowX = 0,
        int windowY = 0,
        int pixelWidth = 0,
        int pixelHeight = 0,
        TCOD_renderer_t rendererType = TCOD_renderer_t.TCOD_RENDERER_GLSL,
        Tileset? tileset = null,
        bool vsync = false,
        int sdlWindowFlags = 0,
        string? windowTitle = null,
        bool windowXYDefined = false,
        Console? console = null
    )
    {
        using var titlePtr = new StringMarshal(windowTitle);

        var parameters = new TCOD_ContextParams()
        {
            columns = columns,
            rows = rows,
            window_x = windowX,
            window_y = windowY,
            pixel_width = pixelWidth,
            pixel_height = pixelHeight,
            renderer_type = (int)rendererType,
            tileset = tileset is not null ? tileset.Pointer : null,
            vsync = vsync ? 1 : 0,
            sdl_window_flags = sdlWindowFlags,
            window_xy_defined = windowXYDefined,
            console = console is not null ? console.Pointer : null,
            window_title = titlePtr.CStr,
        };

        TCOD_Context* p;
        var ret = TCOD_context_new(&parameters, &p);
        ErrorHelper.CheckAndThrow(ret);
        return new Context(p);
    }

    /// <summary>
    /// Present a console to the screen, using a rendering context.
    /// </summary>
    /// <param name="console">The console to present. The console can be any size</param>
    /// <param name="viewport">The optional viewport to use. If null, the default options are used, which are to stretch the console to fit the window.</param>
    /// <exception cref="ArgumentNullException">Thrown if console is null.</exception>
    public void Present(Console console, Viewport? viewport)
    {
        ArgumentNullException.ThrowIfNull(console);
        var ret = TCOD_context_present(
            Pointer,
            console.Pointer,
            viewport is not null ? viewport.Pointer : null
        );
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// Save the last presented console to a PNG file.
    /// </summary>
    /// <param name="filename">The filename to save the screenshot to.</param>
    /// <exception cref="ArgumentException">Thrown if filename is null or empty.</exception>
    public void SaveScreenshot(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_context_save_screenshot(Pointer, filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// Return a pointer the SDL_Window for this context if it uses one.
    /// </summary>
    /// <returns>A pointer to the SDL_Window, or zero if not available.</returns>
    public nint GetSDLWindow()
    {
        return new nint(TCOD_context_get_sdl_window(Pointer));
    }

    /// <summary>
    /// Return a pointer the SDL_Renderer for this context if it uses one.
    /// </summary>
    /// <returns>A pointer to the SDL_Renderer, or zero if not available.</returns>
    public nint GetSDLRenderer()
    {
        return new nint(TCOD_context_get_sdl_renderer(Pointer));
    }

    /// <summary>
    /// Change the active tileset for this context.
    /// </summary>
    /// <param name="tileset">The new tileset to use.</param>
    /// <exception cref="ArgumentNullException">Thrown if tileset is null.</exception>
    public void ChangeTileset(Tileset tileset)
    {
        ArgumentNullException.ThrowIfNull(tileset);
        var ret = TCOD_context_change_tileset(Pointer, tileset.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// Get the renderer type for this context.
    /// </summary>
    /// <returns>The renderer type.</returns>
    public TCOD_renderer_t GetRendererType()
    {
        var ret = TCOD_context_get_renderer_type(Pointer);
        ErrorHelper.CheckAndThrow(ret);
        return (TCOD_renderer_t)ret;
    }

    /// <summary>
    /// Get the recommended console size for this context, given a magnification factor. This is the size that would be needed to fill the window without stretching, if each cell is drawn at the specified magnification. A magnification of 1 means that each cell is drawn at its native size in the tileset. A magnification of 2 means that each cell is drawn at twice its native size, and so on.
    /// </summary>
    /// <param name="magnification">The magnification factor to use. Values of 0.0f or lower will default to 1.0f</param>
    /// <returns>A tuple containing the recommended number of columns and rows.</returns>
    public (int Columns, int Rows) RecommendedConsoleSize(float magnification = 1)
    {
        int c,
            r;
        var ret = TCOD_context_recommended_console_size(Pointer, magnification, &c, &r);
        ErrorHelper.CheckAndThrow(ret);
        return (c, r);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_context_delete(Pointer);
    }
}
