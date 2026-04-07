using System;
using System.Collections.Generic;
using libtcod_net.TCOD;

namespace SampleTCOD;

/// <summary>
/// Dijkstra distance field that supports dynamic "soft" obstacles that can be added, removed, or moved without needing to recompute the entire field.
/// </summary>
public sealed class AdaptiveGoalMap
{
    private const double Epsilon = 1e-9;

    private readonly record struct Neighbor(int X, int Y, double StepCost, int IndexAdjustment);

    private readonly double _cardinalCost;
    private readonly double _diagonalCost;
    private readonly double _softObstacleCost;
    private readonly int _mapWidth;
    private readonly int _mapHeight;
    private readonly bool[] _softObstacles;

    private readonly double[] _distance;
    private readonly bool[] _queued;
    private readonly bool[] _blocked;
    private readonly Queue<(int X, int Y)> _repairQueue = new();
    private readonly PriorityQueue<(int X, int Y), double> _frontier = new();

    private bool _hasComputed;
    private int _softObstacleCount;
    private int _targetX;
    private int _targetY;

    /// <summary>
    /// Initializes a new instance of the <see cref="AdaptiveGoalMap"/> class.
    /// </summary>
    /// <param name="map">The map to use for pathfinding.</param>
    /// <param name="cardinalCost">The cost of moving in cardinal directions.</param>
    /// <param name="diagonalCost">The cost of moving in diagonal directions.</param>
    /// <param name="softObstacleCost">The additional cost for moving through soft obstacles.</param>
    /// <exception cref="ArgumentNullException">Thrown when the map is null.</exception>
    public AdaptiveGoalMap(
        Map map,
        double cardinalCost = 1,
        double diagonalCost = 1.4142135623730951,
        double softObstacleCost = 10
    )
    {
        ArgumentNullException.ThrowIfNull(map);
        ValidateCosts(cardinalCost, diagonalCost, softObstacleCost);

        _mapWidth = map.Width;
        _mapHeight = map.Height;
        _cardinalCost = cardinalCost;
        _diagonalCost = diagonalCost;
        _softObstacleCost = softObstacleCost;

        _distance = new double[_mapWidth * _mapHeight];
        _queued = new bool[_mapWidth * _mapHeight];
        _blocked = new bool[_mapWidth * _mapHeight];
        _softObstacles = new bool[_mapWidth * _mapHeight];
        RebuildBlockedCells(map.IsWalkable);
        ResetDistances();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AdaptiveGoalMap"/> class.
    /// </summary>
    /// <param name="mapWidth">The width of the map.</param>
    /// <param name="mapHeight">The height of the map.</param>
    /// <param name="isWalkable">A function that determines if a cell is walkable.</param>
    /// <param name="cardinalCost">The cost of moving in cardinal directions.</param>
    /// <param name="diagonalCost">The cost of moving in diagonal directions.</param>
    /// <param name="softObstacleCost">The additional cost for moving through soft obstacles.</param>
    /// <exception cref="ArgumentNullException">Thrown when the isWalkable function is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the map size is not positive.</exception>
    public AdaptiveGoalMap(
        int mapWidth,
        int mapHeight,
        Func<int, int, bool> isWalkable,
        double cardinalCost = 1,
        double diagonalCost = 1.4142135623730951,
        double softObstacleCost = 10
    )
    {
        ArgumentNullException.ThrowIfNull(isWalkable);
        ValidateCosts(cardinalCost, diagonalCost, softObstacleCost);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(mapWidth);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(mapHeight);

        _mapWidth = mapWidth;
        _mapHeight = mapHeight;
        _cardinalCost = cardinalCost;
        _diagonalCost = diagonalCost;
        _softObstacleCost = softObstacleCost;

        _distance = new double[_mapWidth * _mapHeight];
        _queued = new bool[_mapWidth * _mapHeight];
        _blocked = new bool[_mapWidth * _mapHeight];
        _softObstacles = new bool[_mapWidth * _mapHeight];
        RebuildBlockedCells(isWalkable);
        ResetDistances();
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

    private static void ValidateCosts(
        double cardinalCost,
        double diagonalCost,
        double softObstacleCost
    )
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cardinalCost);
        ArgumentOutOfRangeException.ThrowIfNegative(diagonalCost);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(softObstacleCost);
    }

    private bool IsWalkable(int x, int y)
    {
        return !_blocked[x + y * _mapWidth];
    }

    private bool InBounds(int x, int y) => x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight;

    private double CellMultiplier(int index) => _softObstacles[index] ? _softObstacleCost : 1.0;

    private void ResetDistances()
    {
        Array.Fill(_distance, double.PositiveInfinity);
        Array.Fill(_queued, false);

        _repairQueue.Clear();
    }

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

    private static bool SameDistance(double a, double b)
    {
        if (double.IsPositiveInfinity(a) && double.IsPositiveInfinity(b))
            return true;
        return Math.Abs(a - b) <= Epsilon;
    }

    private void EnqueueForRepair(int x, int y)
    {
        if (!InBounds(x, y) || _queued[x + y * _mapWidth])
            return;
        _queued[x + y * _mapWidth] = true;
        _repairQueue.Enqueue((x, y));
    }

    private void EnqueueCellAndNeighbors(int x, int y)
    {
        EnqueueForRepair(x, y);

        Span<Neighbor> neighbors = stackalloc Neighbor[8];
        var neighborCount = FillNeighbors(x, y, neighbors);
        for (var i = 0; i < neighborCount; i++)
        {
            var neighbor = neighbors[i];
            EnqueueForRepair(neighbor.X, neighbor.Y);
        }
    }

    private double ComputeDistanceForCell(int x, int y)
    {
        if (!InBounds(x, y) || !IsWalkable(x, y))
            return double.PositiveInfinity;
        if (x == _targetX && y == _targetY)
            return 0.0;

        var best = double.PositiveInfinity;
        var index = x + y * _mapWidth;
        Span<Neighbor> neighbors = stackalloc Neighbor[8];
        var neighborCount = FillNeighbors(x, y, neighbors);
        for (var i = 0; i < neighborCount; i++)
        {
            var neighbor = neighbors[i];
            if (!IsWalkable(neighbor.X, neighbor.Y))
                continue;

            var neighborIndex = index + neighbor.IndexAdjustment;
            var nd = _distance[neighborIndex];
            if (double.IsPositiveInfinity(nd))
                continue;

            var candidate = nd + (neighbor.StepCost * CellMultiplier(neighborIndex));
            if (candidate < best)
                best = candidate;
        }

        return best;
    }

    private void RepairFromCostChanges(int x, int y, bool recalc = true)
    {
        if (!_hasComputed)
            return;

        EnqueueCellAndNeighbors(x, y);
        Span<Neighbor> neighbors = stackalloc Neighbor[8];

        if (recalc)
            while (_repairQueue.Count > 0)
            {
                var (ix, iy) = _repairQueue.Dequeue();
                var index = ix + iy * _mapWidth;
                _queued[index] = false;

                var oldValue = _distance[index];
                var newValue = ComputeDistanceForCell(ix, iy);
                if (SameDistance(oldValue, newValue))
                    continue;

                _distance[index] = newValue;
                var neighborCount = FillNeighbors(ix, iy, neighbors);
                for (var i = 0; i < neighborCount; i++)
                {
                    var neighbor = neighbors[i];
                    EnqueueForRepair(neighbor.X, neighbor.Y);
                }
            }
    }

    /// <summary>
    /// Adds a soft obstacle at the specified coordinates.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if the soft obstacle was added; otherwise, false.</returns>
    public bool AddSoftObstacle(int x, int y)
    {
        if (!InBounds(x, y) || !IsWalkable(x, y))
            return false;
        var index = x + y * _mapWidth;
        if (_softObstacles[index])
            return false;
        _softObstacles[index] = true;
        _softObstacleCount++;
        RepairFromCostChanges(x, y);
        return true;
    }

    /// <summary>
    /// Removes a soft obstacle at the specified coordinates.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if the soft obstacle was removed; otherwise, false.</returns>
    public bool RemoveSoftObstacle(int x, int y)
    {
        if (!InBounds(x, y) || !IsWalkable(x, y))
            return false;
        var index = x + y * _mapWidth;
        if (!_softObstacles[index])
            return false;
        _softObstacles[index] = false;
        _softObstacleCount--;
        RepairFromCostChanges(x, y);
        return true;
    }

    /// <summary>
    /// Moves a soft obstacle from one set of coordinates to another.
    /// </summary>
    /// <param name="xFrom">The x-coordinate of the source cell.</param>
    /// <param name="yFrom">The y-coordinate of the source cell.</param>
    /// <param name="xTo">The x-coordinate of the destination cell.</param>
    /// <param name="yTo">The y-coordinate of the destination cell.</param>
    /// <returns>True if the soft obstacle was moved; otherwise, false.</returns>
    public bool MoveSoftObstacle(int xFrom, int yFrom, int xTo, int yTo)
    {
        if (!InBounds(xFrom, yFrom) || !IsWalkable(xFrom, yFrom))
            return false;

        if (!InBounds(xTo, yTo) || !IsWalkable(xTo, yTo))
            return false;

        var fromIndex = xFrom + yFrom * _mapWidth;
        var toIndex = xTo + yTo * _mapWidth;
        if (!_softObstacles[fromIndex] || _softObstacles[toIndex])
            return false;

        if (xFrom == xTo && yFrom == yTo)
            return false;

        _softObstacles[fromIndex] = false;
        _softObstacleCount--;

        _softObstacles[toIndex] = true;
        _softObstacleCount++;

        RepairFromCostChanges(xFrom, yFrom, false);
        RepairFromCostChanges(xTo, yTo);
        return true;
    }

    /// <summary>
    /// Clears all soft obstacles from the map.
    /// </summary>
    public void ClearSoftObstacles()
    {
        if (_softObstacleCount == 0)
            return;

        Array.Fill(_softObstacles, false);
        _softObstacleCount = 0;

        if (_hasComputed)
        {
            Compute(_targetX, _targetY);
        }
    }

    /// <summary>
    /// Computes the distance field from the specified target coordinates.
    /// </summary>
    /// <param name="xTarget">The x-coordinate of the target cell.</param>
    /// <param name="yTarget">The y-coordinate of the target cell.</param>
    public void Compute(int xTarget, int yTarget)
    {
        if (!InBounds(xTarget, yTarget) || !IsWalkable(xTarget, yTarget))
        {
            _hasComputed = false;
            ResetDistances();
            return;
        }

        _targetX = xTarget;
        _targetY = yTarget;
        _hasComputed = true;

        ResetDistances();
        _distance[xTarget + yTarget * _mapWidth] = 0.0;

        _frontier.Clear();
        _frontier.Enqueue((xTarget, yTarget), 0.0);
        Span<Neighbor> neighbors = stackalloc Neighbor[8];

        while (_frontier.TryDequeue(out var current, out var currentDistance))
        {
            var index = current.X + current.Y * _mapWidth;
            if (currentDistance > _distance[index] + Epsilon)
                continue;

            var neighborCount = FillNeighbors(current.X, current.Y, neighbors);
            for (var i = 0; i < neighborCount; i++)
            {
                var neighbor = neighbors[i];
                if (!IsWalkable(neighbor.X, neighbor.Y))
                    continue;

                var neighborIndex = index + neighbor.IndexAdjustment;
                var candidate =
                    currentDistance + (neighbor.StepCost * CellMultiplier(neighborIndex));
                if (candidate + Epsilon >= _distance[neighborIndex])
                    continue;

                _distance[neighborIndex] = candidate;
                _frontier.Enqueue((neighbor.X, neighbor.Y), candidate);
            }
        }
    }

    /// <summary>
    /// Attempts to get the next step towards the target from the current coordinates.
    /// </summary>
    /// <param name="xCurrent">The x-coordinate of the current cell.</param>
    /// <param name="yCurrent">The y-coordinate of the current cell.</param>
    /// <param name="nextStep">The coordinates of the next step towards the target.</param>
    /// <returns>True if a valid next step was found; otherwise, false.</returns>
    public bool TryGetNextStep(int xCurrent, int yCurrent, out (int X, int Y) nextStep)
    {
        nextStep = (xCurrent, yCurrent);

        if (!_hasComputed)
            return false;
        if (!InBounds(xCurrent, yCurrent) || !IsWalkable(xCurrent, yCurrent))
            return false;
        if (xCurrent == _targetX && yCurrent == _targetY)
            return false;

        var index = xCurrent + yCurrent * _mapWidth;
        var currentDistance = _distance[index];
        if (double.IsPositiveInfinity(currentDistance))
            return false;

        var bestNeighbor = (X: xCurrent, Y: yCurrent);
        var bestTotal = double.PositiveInfinity;

        Span<Neighbor> neighbors = stackalloc Neighbor[8];
        var neighborCount = FillNeighbors(xCurrent, yCurrent, neighbors);
        for (var i = 0; i < neighborCount; i++)
        {
            var neighbor = neighbors[i];
            if (!IsWalkable(neighbor.X, neighbor.Y))
                continue;

            var neighborIndex = index + neighbor.IndexAdjustment;
            var neighborDistance = _distance[neighborIndex];
            if (double.IsPositiveInfinity(neighborDistance))
                continue;

            var total = neighborDistance + (neighbor.StepCost * CellMultiplier(neighborIndex));
            if (total + Epsilon >= bestTotal)
                continue;

            bestTotal = total;
            bestNeighbor = (neighbor.X, neighbor.Y);
        }

        if (bestTotal + Epsilon >= currentDistance)
            return false;

        nextStep = bestNeighbor;
        return true;
    }
}
