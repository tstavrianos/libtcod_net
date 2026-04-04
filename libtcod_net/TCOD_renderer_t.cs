using System;

public enum TCOD_renderer_t
{
    TCOD_RENDERER_GLSL = 0,

    [Obsolete]
    TCOD_RENDERER_OPENGL = 1,

    [Obsolete]
    TCOD_RENDERER_SDL = 2,

    TCOD_RENDERER_SDL2 = 3,

    TCOD_RENDERER_OPENGL2 = 4,

    TCOD_RENDERER_XTERM = 5,
}
