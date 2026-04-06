using System.Collections.Generic;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Bresenham line algorithm.
/// </summary>
public static class Line
{
    /// <summary>
    /// Enumerates the points on a line using the Bresenham line algorithm.
    /// </summary>
    /// <param name="xFrom">The starting x-coordinate.</param>
    /// <param name="yFrom">The starting y-coordinate.</param>
    /// <param name="xTo">The ending x-coordinate.</param>
    /// <param name="yTo">The ending y-coordinate.</param>
    /// <returns>An enumerable of points on the line.</returns>
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
