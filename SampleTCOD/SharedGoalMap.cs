using System;
using System.Collections.Generic;
using libtcod_net.TCOD;

namespace SampleTCOD;

/// <summary>
/// Dijkstra distance field implementation that allows you to find the best next step towards a target from multiple origins.
/// The distance field is shared across all origins, so it's efficient for scenarios where many entities are pathfinding towards
/// the same target.
/// </summary>
public sealed class SharedGoalMap
{
    private const double Epsilon = 1e-9;

    private readonly record struct Neighbor(int X, int Y, double StepCost, int IndexAdjustment);

    private readonly bool[] _blocked;
    private readonly double _cardinalCost;
    private readonly double _diagonalCost;
    private readonly int _mapWidth;
    private readonly int _mapHeight;
    private readonly double[] _distance;
    private readonly int[] _plannedDestinations;
    private int _previousTargetX = -1;
    private int _previousTargetY = -1;
    private readonly PriorityQueue<(int X, int Y), double> _frontier = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SharedGoalMap"/> class.
    /// </summary>
    /// <param name="map">The map to use for pathfinding.</param>
    /// <param name="cardinalCost">The cost of moving in cardinal directions.</param>
    /// <param name="diagonalCost">The cost of moving in diagonal directions.</param>
    /// <exception cref="ArgumentNullException">Thrown when the map is null.</exception>
    public SharedGoalMap(Map map, double cardinalCost = 1, double diagonalCost = 1.4142135623730951)
    {
        ArgumentNullException.ThrowIfNull(map);
        ValidateCosts(cardinalCost, diagonalCost);

        _mapWidth = map.Width;
        _mapHeight = map.Height;
        _cardinalCost = cardinalCost;
        _diagonalCost = diagonalCost;
        _blocked = new bool[map.Width * map.Height];
        _distance = new double[map.Width * map.Height];
        _plannedDestinations = new int[map.Width * map.Height];
        RebuildBlockedCells(map.IsWalkable);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SharedGoalMap"/> class.
    /// </summary>
    /// <param name="mapWidth">The width of the map.</param>
    /// <param name="mapHeight">The height of the map.</param>
    /// <param name="isWalkable">A function that determines if a cell is walkable.</param>
    /// <param name="cardinalCost">The cost of moving in cardinal directions.</param>
    /// <param name="diagonalCost">The cost of moving in diagonal directions.</param>
    /// <exception cref="ArgumentNullException">Thrown when the isWalkable function is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the map size is not positive.</exception>
    public SharedGoalMap(
        int mapWidth,
        int mapHeight,
        Func<int, int, bool> isWalkable,
        double cardinalCost = 1,
        double diagonalCost = 1.4142135623730951
    )
    {
        ArgumentNullException.ThrowIfNull(isWalkable);
        ValidateCosts(cardinalCost, diagonalCost);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(mapWidth);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(mapHeight);

        _mapWidth = mapWidth;
        _mapHeight = mapHeight;
        _cardinalCost = cardinalCost;
        _diagonalCost = diagonalCost;
        _blocked = new bool[mapWidth * mapHeight];
        _distance = new double[mapWidth * mapHeight];
        _plannedDestinations = new int[mapWidth * mapHeight];
        RebuildBlockedCells(isWalkable);
    }

    private void RebuildBlockedCells(Func<int, int, bool> isWalkable)
    {
        for (var x = 0; x < _mapWidth; x++)
        {
            for (var y = 0; y < _mapHeight; y++)
            {
                _blocked[x + y * _mapWidth] = !isWalkable(x, y);
            }
        }
    }

    private static void ValidateCosts(double cardinalCost, double diagonalCost)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cardinalCost);
        ArgumentOutOfRangeException.ThrowIfNegative(diagonalCost);
    }

    private bool InBounds(int x, int y) => x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight;

    private bool IsWalkable(int x, int y) => !_blocked[x + y * _mapWidth];

    private int FillNeighbors(int x, int y, Span<Neighbor> neighbors)
    {
        var count = 0;

        if (x > 0)
            neighbors[count++] = new Neighbor(x - 1, y, _cardinalCost, -1);
        if (x + 1 < _mapWidth)
            neighbors[count++] = new Neighbor(x + 1, y, _cardinalCost, 1);
        if (y > 0)
            neighbors[count++] = new Neighbor(x, y - 1, _cardinalCost, -_mapWidth);
        if (y + 1 < _mapHeight)
            neighbors[count++] = new Neighbor(x, y + 1, _cardinalCost, _mapWidth);

        if (_diagonalCost <= 0)
            return count;

        if (x > 0 && y > 0)
            neighbors[count++] = new Neighbor(x - 1, y - 1, _diagonalCost, -_mapWidth - 1);
        if (x > 0 && y + 1 < _mapHeight)
            neighbors[count++] = new Neighbor(x - 1, y + 1, _diagonalCost, _mapWidth - 1);
        if (x + 1 < _mapWidth && y > 0)
            neighbors[count++] = new Neighbor(x + 1, y - 1, _diagonalCost, -_mapWidth + 1);
        if (x + 1 < _mapWidth && y + 1 < _mapHeight)
            neighbors[count++] = new Neighbor(x + 1, y + 1, _diagonalCost, _mapWidth + 1);

        return count;
    }

    private bool ComputeDistanceField(int targetX, int targetY)
    {
        if (!InBounds(targetX, targetY) || !IsWalkable(targetX, targetY))
            return false;

        if (targetX == _previousTargetX && targetY == _previousTargetY)
        {
            return true;
        }
        Array.Fill(_distance, double.PositiveInfinity);

        _previousTargetX = targetX;
        _previousTargetY = targetY;

        var targetIndex = targetX + targetY * _mapWidth;
        _distance[targetIndex] = 0.0;

        _frontier.Clear();
        _frontier.Enqueue((targetX, targetY), 0.0);

        Span<Neighbor> neighbors = stackalloc Neighbor[8];
        while (_frontier.TryDequeue(out var current, out var currentDistance))
        {
            var currentIndex = current.X + current.Y * _mapWidth;
            if (currentDistance > _distance[currentIndex] + Epsilon)
                continue;

            var neighborCount = FillNeighbors(current.X, current.Y, neighbors);
            for (var i = 0; i < neighborCount; i++)
            {
                var neighbor = neighbors[i];
                if (!IsWalkable(neighbor.X, neighbor.Y))
                    continue;

                var neighborIndex = currentIndex + neighbor.IndexAdjustment;
                var candidate = currentDistance + neighbor.StepCost;
                if (candidate + Epsilon >= _distance[neighborIndex])
                    continue;

                _distance[neighborIndex] = candidate;
                _frontier.Enqueue((neighbor.X, neighbor.Y), candidate);
            }
        }

        return true;
    }

    private bool TryGetSourceState(
        (int X, int Y) source,
        out int sourceIndex,
        out double sourceDistance
    )
    {
        if (!InBounds(source.X, source.Y) || !IsWalkable(source.X, source.Y))
        {
            sourceIndex = -1;
            sourceDistance = double.PositiveInfinity;
            return false;
        }

        sourceIndex = source.X + source.Y * _mapWidth;
        sourceDistance = _distance[sourceIndex];
        return !double.IsPositiveInfinity(sourceDistance);
    }

    private int FindBestDestination(
        int sourceIndex,
        int sourceX,
        int sourceY,
        double sourceDistance,
        Span<Neighbor> neighbors,
        int[]? unprocessedOccupancy
    )
    {
        var bestDestination = sourceIndex;
        var bestDistance = sourceDistance;

        var neighborCount = FillNeighbors(sourceX, sourceY, neighbors);
        for (var j = 0; j < neighborCount; j++)
        {
            var neighbor = neighbors[j];
            if (!IsWalkable(neighbor.X, neighbor.Y))
                continue;

            var neighborIndex = sourceIndex + neighbor.IndexAdjustment;
            if (_plannedDestinations[neighborIndex] >= 0)
                continue;

            if (unprocessedOccupancy != null && unprocessedOccupancy[neighborIndex] > 0)
                continue;

            var neighborDistance = _distance[neighborIndex];
            if (double.IsPositiveInfinity(neighborDistance))
                continue;

            var total = neighborDistance + neighbor.StepCost;
            if (total + Epsilon >= bestDistance)
                continue;

            bestDistance = total;
            bestDestination = neighborIndex;
        }

        return bestDestination;
    }

    /// <summary>
    /// Computes the optimal destinations for a set of sources towards a target.
    /// </summary>
    /// <param name="sources">The list of source positions.</param>
    /// <param name="targetX">The X coordinate of the target.</param>
    /// <param name="targetY">The Y coordinate of the target.</param>
    /// <param name="orderedByDistance">Whether to order the sources by distance to the target.</param>
    /// <returns>The list of computed destinations for each source.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the sources list is null.</exception>
    public IReadOnlyList<(int X, int Y)> Compute(
        IReadOnlyList<(int X, int Y)> sources,
        int targetX,
        int targetY,
        bool orderedByDistance = false
    )
    {
        ArgumentNullException.ThrowIfNull(sources);

        if (sources.Count == 0)
            return Array.Empty<(int X, int Y)>();

        var result = new (int X, int Y)[sources.Count];
        for (var i = 0; i < sources.Count; i++)
        {
            result[i] = sources[i];
        }

        Array.Fill(_plannedDestinations, -1);

        var hasDistanceField = ComputeDistanceField(targetX, targetY);
        if (!hasDistanceField)
            return result;

        Span<Neighbor> neighbors = stackalloc Neighbor[8];
        if (!orderedByDistance)
        {
            for (var i = 0; i < sources.Count; i++)
            {
                var (x, y) = sources[i];
                if (!TryGetSourceState((x, y), out var sourceIndex, out var sourceDistance))
                    continue;

                var bestDestination = FindBestDestination(
                    sourceIndex,
                    x,
                    y,
                    sourceDistance,
                    neighbors,
                    unprocessedOccupancy: null
                );

                _plannedDestinations[bestDestination] = i;
                result[i] = (bestDestination % _mapWidth, bestDestination / _mapWidth);
            }
            return result;
        }

        var ordered = new int[sources.Count];
        var sourceIndices = new int[sources.Count];
        var sourceDistances = new double[sources.Count];
        var unprocessedOccupancy = new int[_mapWidth * _mapHeight];

        for (var i = 0; i < sources.Count; i++)
        {
            ordered[i] = i;

            var (x, y) = sources[i];
            if (!TryGetSourceState((x, y), out var sourceIndex, out var sourceDistance))
            {
                sourceIndices[i] = -1;
                sourceDistances[i] = double.PositiveInfinity;
                continue;
            }

            sourceIndices[i] = sourceIndex;
            unprocessedOccupancy[sourceIndex]++;
            sourceDistances[i] = sourceDistance;
        }

        Array.Sort(
            ordered,
            (a, b) =>
            {
                var cmp = sourceDistances[a].CompareTo(sourceDistances[b]);
                return cmp != 0 ? cmp : a.CompareTo(b);
            }
        );

        foreach (var sourceOrderIndex in ordered)
        {
            var sourceIndex = sourceIndices[sourceOrderIndex];
            if (sourceIndex < 0)
                continue;

            unprocessedOccupancy[sourceIndex]--;

            var sourceDistance = sourceDistances[sourceOrderIndex];
            if (double.IsPositiveInfinity(sourceDistance))
            {
                if (_plannedDestinations[sourceIndex] < 0)
                    _plannedDestinations[sourceIndex] = sourceOrderIndex;
                continue;
            }

            var (sx, sy) = sources[sourceOrderIndex];
            var bestDestination = FindBestDestination(
                sourceIndex,
                sx,
                sy,
                sourceDistance,
                neighbors,
                unprocessedOccupancy
            );

            if (_plannedDestinations[bestDestination] >= 0)
                continue;

            _plannedDestinations[bestDestination] = sourceOrderIndex;
            result[sourceOrderIndex] = (bestDestination % _mapWidth, bestDestination / _mapWidth);
        }

        return result;
    }
}
