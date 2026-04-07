using System;
using System.Collections.Generic;
using libtcod_net.TCOD;

namespace SampleTCOD;

/// <summary>
/// A simple pathfinding utility class.
/// </summary>
internal static class SimplePathfinder
{
    private sealed record CostData(double[,] Map, double Cardinal);

    /// <summary>
    /// Calculates the path from a start position to a target position using the provided cost map and movement costs.
    /// </summary>
    /// <param name="xStart">The X coordinate of the start position.</param>
    /// <param name="yStart">The Y coordinate of the start position.</param>
    /// <param name="xTarget">The X coordinate of the target position.</param>
    /// <param name="yTarget">The Y coordinate of the target position.</param>
    /// <param name="cardinalCost">The cost of moving in cardinal directions.</param>
    /// <param name="diagonalCost">The cost of moving in diagonal directions.</param>
    /// <param name="costMap">The cost map representing the movement cost for each cell.</param>
    /// <returns>The list of positions representing the calculated path.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the cardinal cost is not positive.</exception>
    public static IReadOnlyList<(int X, int Y)> CalculatePath(
        int xStart,
        int yStart,
        int xTarget,
        int yTarget,
        double cardinalCost,
        double diagonalCost,
        double[,] costMap
    )
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cardinalCost);

        var width = costMap.GetLength(0);
        var height = costMap.GetLength(1);
        var costData = new CostData(costMap, cardinalCost);
        var diagonalMultiplier = diagonalCost <= 0 ? 0f : (float)(diagonalCost / cardinalCost);

        using var path = Path.Create(
            width,
            height,
            static (_, _, xTo, yTo, data) =>
            {
                var cellCost = data!.Map[xTo, yTo];
                if (cellCost <= 0)
                {
                    return 0f;
                }

                return (float)(data.Cardinal * cellCost);
            },
            costData,
            diagonalMultiplier
        );

        var result = new List<(int X, int Y)>();
        if (!path.Compute(xStart, yStart, xTarget, yTarget))
        {
            return result;
        }

        var x = xStart;
        var y = yStart;
        while (path.TryWalk(ref x, ref y, false))
        {
            result.Add((x, y));
        }

        return result;
    }
}
