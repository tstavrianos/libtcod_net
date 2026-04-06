using System.Collections.Generic;

namespace libtcod_net.TCOD;

public static class Line
{
    public static IEnumerable<(int X, int Y)> Enumerate(int xFrom, int yFrom, int xTo, int yTo)
    {
        var line = new libtcod.TCOD_bresenham_data_t();
        libtcod.TCOD_line_init_mt(xFrom, yFrom, xTo, yTo, ref line);

        while (!libtcod.TCOD_line_step_mt(ref xFrom, ref yFrom, ref line))
        {
            yield return (xFrom, yFrom);
        }
    }
}
