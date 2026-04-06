using System;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;
using static SDL3.SDL;

var tcodTileset = TCOD_tileset_load(
    "RDE_vector_32x32_gs_ro_transparent.png",
    16,
    16,
    TCOD_Charmaps.TCOD_CHARMAP_CP437
);
var titlePtr = Marshal.StringToCoTaskMemUTF8("libtcod-net");
TCOD_context_new(
    new TCOD_ContextParams()
    {
        columns = 80,
        rows = 50,
        window_title = titlePtr,
        tileset = tcodTileset,
    },
    out var tcodContext
);
Marshal.FreeCoTaskMem(titlePtr);

Console.WriteLine($"TCOD_context_new result: context: 0x{tcodContext.ToInt64():X}");
if (tcodContext == nint.Zero)
{
    TCOD_tileset_delete(tcodTileset);
    return;
}
var tcodViewport = TCOD_viewport_new();
Console.WriteLine($"TCOD_viewport_new result:  viewPort: 0x{tcodViewport.ToInt64():X}");
if (tcodViewport == nint.Zero)
{
    TCOD_context_delete(tcodContext);
    TCOD_tileset_delete(tcodTileset);
    return;
}

var tcodConsole = TCOD_console_new(80, 50);
Console.WriteLine($"TCOD_console_new result: console: 0x{tcodConsole.ToInt64():X}");
if (tcodConsole == nint.Zero)
{
    TCOD_viewport_delete(tcodViewport);
    TCOD_context_delete(tcodContext);
    TCOD_tileset_delete(tcodTileset);
    return;
}
while (true)
{
    TCOD_console_put_rgb(
        tcodConsole,
        1,
        1,
        '@',
        nint.Zero,
        nint.Zero,
        TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    );
    TCOD_context_present(tcodContext, tcodConsole, tcodViewport);

    TCOD_console_clear(tcodConsole);

    while (SDL_WaitEvent(out var @event))
    {
        if (@event.type == (uint)SDL_EventType.SDL_EVENT_QUIT)
        {
            goto cleanup;
        }
    }
}

cleanup:
TCOD_console_delete(tcodConsole);
TCOD_viewport_delete(tcodViewport);
TCOD_context_delete(tcodContext);
TCOD_tileset_delete(tcodTileset);
