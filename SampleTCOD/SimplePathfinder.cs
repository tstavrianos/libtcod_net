using System.Collections.Generic;
using libtcod_net.TCOD;

namespace SampleTCOD;

internal static class SimplePathfinder
{
    private sealed record CostData(double[,] Map, double Cardinal);

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
        if (cardinalCost <= 0)
        {
            throw new System.ArgumentOutOfRangeException(
                nameof(cardinalCost),
                "Cardinal cost must be greater than zero."
            );
        }

        var width = costMap.GetLength(0);
        var height = costMap.GetLength(1);
        var costData = new CostData(costMap, cardinalCost);
        var diagonalMultiplier = diagonalCost <= 0 ? 0f : (float)(diagonalCost / cardinalCost);

        using var path = Path.Create<CostData>(
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
