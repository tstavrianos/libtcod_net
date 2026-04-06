using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

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

    public void Present(Console console, Viewport viewport)
    {
        ArgumentNullException.ThrowIfNull(console);
        ArgumentNullException.ThrowIfNull(viewport);
        var ret = TCOD_context_present(Pointer, console.Pointer, viewport.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void SaveScreenshot(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_context_save_screenshot(Pointer, filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
    }

    public nint GetSDLWindow()
    {
        return new nint(TCOD_context_get_sdl_window(Pointer));
    }

    public nint GetSDLRenderer()
    {
        return new nint(TCOD_context_get_sdl_renderer(Pointer));
    }

    public void ChangeTileset(Tileset tileset)
    {
        ArgumentNullException.ThrowIfNull(tileset);
        var ret = TCOD_context_change_tileset(Pointer, tileset.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public TCOD_renderer_t GetRendererType()
    {
        var ret = TCOD_context_get_renderer_type(Pointer);
        ErrorHelper.CheckAndThrow(ret);
        return (TCOD_renderer_t)ret;
    }

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
