using libtcod_net;
using libtcod_net.TCOD;
using static SDL3.SDL;

using var tileset = Tileset.LoadFromFile(
    filename: "RDE_vector_32x32_gs_ro_transparent.png",
    columns: 16,
    rows: 16,
    charMap: libtcod.TCOD_CHARMAP_CP437
);
using var context = Context.Create(
    columns: 80,
    rows: 50,
    tileset: tileset,
    windowTitle: "libtcod-net"
);
using var viewport = Viewport.Create();
using var console = Console.Create(width: 80, height: 50);

var running = true;
while (running)
{
    console.Put(1, 1, '@');
    context.Present(console, viewport);
    console.Clear();

    while (SDL_WaitEvent(out var @event))
    {
        if (@event.type == (uint)SDL_EventType.SDL_EVENT_QUIT)
        {
            running = false;
            break;
        }
    }
}
