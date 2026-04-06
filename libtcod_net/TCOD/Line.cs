using System.Collections.Generic;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public static class Line
{
    public static unsafe IEnumerable<(int X, int Y)> Enumerate(
        int xFrom,
        int yFrom,
        int xTo,
        int yTo
    )
    {
        var ret = new List<(int, int)>();
        var line = new TCOD_bresenham_data_t();
        TCOD_line_init_mt(xFrom, yFrom, xTo, yTo, &line);

        while (!TCOD_line_step_mt(&xFrom, &yFrom, &line))
        {
            ret.Add((xFrom, yFrom));
        }

        return ret;
    }
}
