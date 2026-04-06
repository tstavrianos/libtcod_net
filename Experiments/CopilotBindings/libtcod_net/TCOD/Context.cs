using System;
using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

public sealed class Context : TCODResource
{
    private Context(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Context with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
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
        libtcod.TCOD_renderer_t rendererType = libtcod.TCOD_renderer_t.TCOD_RENDERER_GLSL,
        Tileset? tileset = null,
        bool vsync = false,
        int sdlWindowFlags = 0,
        string? windowTitle = null,
        bool windowXYDefined = false,
        Console? console = null
    )
    {
        nint titlePtr = windowTitle is not null
            ? Marshal.StringToCoTaskMemUTF8(windowTitle)
            : nint.Zero;

        try
        {
            var parameters = new libtcod.TCOD_ContextParams()
            {
                columns = columns,
                rows = rows,
                window_x = windowX,
                window_y = windowY,
                pixel_width = pixelWidth,
                pixel_height = pixelHeight,
                renderer_type = rendererType,
                tileset = tileset?.Pointer ?? nint.Zero,
                vsync = vsync ? 1 : 0,
                sdl_window_flags = sdlWindowFlags,
                window_xy_defined = windowXYDefined,
                console = console?.Pointer ?? nint.Zero,
                window_title = titlePtr,
            };

            var ret = libtcod.TCOD_context_new(parameters, out var p);
            ErrorHelper.CheckAndThrow(ret);
            return new Context(p);
        }
        finally
        {
            if (titlePtr != nint.Zero)
                Marshal.FreeCoTaskMem(titlePtr);
        }
    }

    public void Present(Console console, Viewport viewport)
    {
        ArgumentNullException.ThrowIfNull(console);
        ArgumentNullException.ThrowIfNull(viewport);
        var ret = libtcod.TCOD_context_present(Pointer, console.Pointer, viewport.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void SaveScreenshot(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_context_save_screenshot(Pointer, filename);
        ErrorHelper.CheckAndThrow(ret);
    }

    public nint GetSDLWindow()
    {
        return libtcod.TCOD_context_get_sdl_window(Pointer);
    }

    public nint GetSDLRenderer()
    {
        return libtcod.TCOD_context_get_sdl_renderer(Pointer);
    }

    public void ChangeTileset(Tileset tileset)
    {
        ArgumentNullException.ThrowIfNull(tileset);
        var ret = libtcod.TCOD_context_change_tileset(Pointer, tileset.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public libtcod.TCOD_renderer_t GetRendererType()
    {
        var ret = libtcod.TCOD_context_get_renderer_type(Pointer);
        ErrorHelper.CheckAndThrow(ret);
        return (libtcod.TCOD_renderer_t)ret;
    }

    public (int Columns, int Rows) RecommendedConsoleSize(float magnification = 1)
    {
        var ret = libtcod.TCOD_context_recommended_console_size(
            Pointer,
            magnification,
            out var c,
            out var r
        );
        ErrorHelper.CheckAndThrow(ret);
        return (c, r);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_context_delete(Pointer);
    }
}
