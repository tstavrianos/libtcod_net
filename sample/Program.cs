using libtcod_net;
using static libtcod_net.NativeMethods;
using static SDL3.SDL;

var tileSet = TCOD_tileset_load(
    "RDE_vector_32x32_gs_ro_transparent.png",
    16,
    16,
    TCOD_CharMaps.CP437.Length,
    TCOD_CharMaps.CP437
);

using var paramsScope = ContextInteropHelpers.CreateDefaultParams(
    columns: 80,
    rows: 50,
    windowTitle: "libtcod-net",
    tileset: tileSet
);

var result = ContextInteropHelpers.CreateContext(in paramsScope.Value, out var context);
Console.WriteLine($"TCOD_context_new result: {result}, context: 0x{context.ToInt64():X}");
if (context == nint.Zero)
{
    TCOD_tileset_delete(tileSet);
    return;
}
var viewPort = TCOD_viewport_new();
Console.WriteLine($"TCOD_viewport_new result:  viewPort: 0x{viewPort.ToInt64():X}");
if (viewPort == nint.Zero)
{
    TCOD_context_delete(context);
    TCOD_tileset_delete(tileSet);
    return;
}

var console = TCOD_console_new(80, 50);
Console.WriteLine($"TCOD_console_new result: console: 0x{console.ToInt64():X}");
if (console == nint.Zero)
{
    TCOD_context_delete(context);
    TCOD_viewport_delete(viewPort);
    TCOD_tileset_delete(tileSet);
    return;
}
while (true)
{
    TCOD_console_put_rgb(
        console,
        1,
        1,
        '@',
        nint.Zero,
        nint.Zero,
        TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    );
    TCOD_context_present(context, console, viewPort);

    TCOD_console_clear(console);

    while (SDL_WaitEvent(out var @event))
    {
        if (@event.type == (uint)SDL_EventType.SDL_EVENT_QUIT)
        {
            goto cleanup;
        }
    }
}

cleanup:
TCOD_viewport_delete(viewPort);
TCOD_console_delete(console);
TCOD_context_delete(context);
TCOD_tileset_delete(tileSet);
