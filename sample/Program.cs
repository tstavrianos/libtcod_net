using System;
using static libtcod_net.libtcod;
using static SDL3.SDL;

internal static unsafe class Program
{
    public static void Main(string[] args)
    {
        TCOD_Tileset* tcodTileset;
        fixed (int* c = TCOD_CHARMAP_CP437.AsSpan())
            tcodTileset = TCOD_tileset_load(
                "RDE_vector_32x32_gs_ro_transparent.png"u8,
                16,
                16,
                TCOD_CHARMAP_CP437.Length,
                c
            );

        var contextParams = new TCOD_ContextParams()
        {
            columns = 80,
            rows = 50,
            window_title = "libtcod-net"u8,
            tileset = tcodTileset,
        };
        TCOD_Context* tcodContext;
        TCOD_context_new(&contextParams, &tcodContext);

        Console.WriteLine($"TCOD_context_new result: context: 0x{((nint)tcodContext).ToInt64():X}");
        if (tcodContext == null)
        {
            TCOD_tileset_delete(tcodTileset);
            return;
        }
        var tcodViewport = TCOD_viewport_new();
        Console.WriteLine(
            $"TCOD_viewport_new result:  viewPort: 0x{((nint)tcodViewport).ToInt64():X}"
        );
        if (tcodViewport == null)
        {
            TCOD_context_delete(tcodContext);
            TCOD_tileset_delete(tcodTileset);
            return;
        }

        var tcodConsole = TCOD_console_new(80, 50);
        Console.WriteLine($"TCOD_console_new result: console: 0x{((nint)tcodConsole).ToInt64():X}");
        if (tcodConsole == null)
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
                null,
                null,
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
    }
}
