using System;
using System.Collections.Generic;

namespace libtcod_net.TCOD;

// Not currently is use. Meant as an experiment to translate the python-tcod pathfinder into C#.
// In its current form, its a dijkstra distance field with a downhill walker. Not ideal to run per-tick and per-monster.
// SimplePathfinder is using the same idea but applying it to the A* implementation in libtcod, which is more efficient
// for single pathfinding operations.
public sealed class Pathfinder
{
    // cost = 0, means impassable, cost = 1 means normal movement, cost > 1 means more difficult terrain
    private readonly double[,] _costMap;
    private readonly double _cardinalCost;
    private readonly double _diagonalCost;
    private readonly double[,] _grid;
    private readonly List<(int X, int Y)> _path = new();
    private int _pathIndex;
    private bool _hasDistanceField;
    private int _rootX;
    private int _rootY;

    public Pathfinder(
        double[,] costMap,
        double cardinalCost = 1.0,
        double diagonalCost = 1.4142135623730951
    )
    {
        _costMap = new double[costMap.GetLength(0), costMap.GetLength(1)];
        Array.Copy(costMap, _costMap, costMap.Length);
        _cardinalCost = cardinalCost;
        _diagonalCost = diagonalCost;
        _grid = new double[costMap.GetLength(0), costMap.GetLength(1)];
    }

    public void Calculate(int xRoot, int yRoot)
    {
        if (
            xRoot < 0
            || xRoot >= _costMap.GetLength(0)
            || yRoot < 0
            || yRoot >= _costMap.GetLength(1)
        )
        {
            throw new ArgumentOutOfRangeException(
                nameof(xRoot),
                "Root coordinates must be within the bounds of the cost map."
            );
        }

        if (_costMap[xRoot, yRoot] <= 0)
        {
            throw new ArgumentException(
                "Root coordinates must be on a passable cell.",
                nameof(xRoot)
            );
        }

        var width = _costMap.GetLength(0);
        var height = _costMap.GetLength(1);

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                _grid[x, y] = double.PositiveInfinity;
            }
        }

        _path.Clear();
        _pathIndex = 0;
        _grid[xRoot, yRoot] = 0.0;
        _rootX = xRoot;
        _rootY = yRoot;

        var frontier = new PriorityQueue<(int X, int Y), double>();
        frontier.Enqueue((xRoot, yRoot), 0.0);

        var neighbors = new (int Dx, int Dy, double BaseCost)[]
        {
            (-1, 0, _cardinalCost),
            (1, 0, _cardinalCost),
            (0, -1, _cardinalCost),
            (0, 1, _cardinalCost),
            (-1, -1, _diagonalCost),
            (-1, 1, _diagonalCost),
            (1, -1, _diagonalCost),
            (1, 1, _diagonalCost),
        };

        while (frontier.TryDequeue(out var current, out var currentDistance))
        {
            if (currentDistance > _grid[current.X, current.Y])
            {
                continue;
            }

            foreach (var (dx, dy, baseCost) in neighbors)
            {
                if (baseCost <= 0)
                {
                    continue;
                }

                var nx = current.X + dx;
                var ny = current.Y + dy;

                if (nx < 0 || nx >= width || ny < 0 || ny >= height)
                {
                    continue;
                }

                var cellCost = _costMap[nx, ny];
                if (cellCost <= 0)
                {
                    continue;
                }

                var nextDistance = currentDistance + (baseCost * cellCost);
                if (nextDistance >= _grid[nx, ny])
                {
                    continue;
                }

                _grid[nx, ny] = nextDistance;
                frontier.Enqueue((nx, ny), nextDistance);
            }
        }

        _hasDistanceField = true;
    }

    public void SetPath(int xTarget, int yTarget)
    {
        if (
            xTarget < 0
            || xTarget >= _costMap.GetLength(0)
            || yTarget < 0
            || yTarget >= _costMap.GetLength(1)
        )
        {
            throw new ArgumentOutOfRangeException(
                nameof(xTarget),
                "Target coordinates must be within the bounds of the cost map."
            );
        }

        if (!_hasDistanceField)
        {
            throw new InvalidOperationException("Calculate must be called before SetPath.");
        }

        _path.Clear();
        _pathIndex = 0;

        if (double.IsPositiveInfinity(_grid[xTarget, yTarget]))
        {
            return;
        }

        if (xTarget == _rootX && yTarget == _rootY)
        {
            return;
        }

        var width = _costMap.GetLength(0);
        var height = _costMap.GetLength(1);
        const double epsilon = 1e-9;

        var neighbors = new (int Dx, int Dy, double BaseCost)[]
        {
            (-1, 0, _cardinalCost),
            (1, 0, _cardinalCost),
            (0, -1, _cardinalCost),
            (0, 1, _cardinalCost),
            (-1, -1, _diagonalCost),
            (-1, 1, _diagonalCost),
            (1, -1, _diagonalCost),
            (1, 1, _diagonalCost),
        };

        var reversePath = new List<(int X, int Y)>();
        var currentX = xTarget;
        var currentY = yTarget;

        while (currentX != _rootX || currentY != _rootY)
        {
            var foundStep = false;
            var bestX = 0;
            var bestY = 0;
            var bestDistance = double.PositiveInfinity;

            foreach (var (dx, dy, baseCost) in neighbors)
            {
                if (baseCost <= 0)
                {
                    continue;
                }

                var nx = currentX + dx;
                var ny = currentY + dy;

                if (nx < 0 || nx >= width || ny < 0 || ny >= height)
                {
                    continue;
                }

                var neighborDistance = _grid[nx, ny];
                if (double.IsPositiveInfinity(neighborDistance))
                {
                    continue;
                }

                var expected = neighborDistance + (baseCost * _costMap[currentX, currentY]);
                if (Math.Abs(expected - _grid[currentX, currentY]) > epsilon)
                {
                    continue;
                }

                if (neighborDistance >= bestDistance)
                {
                    continue;
                }

                bestDistance = neighborDistance;
                bestX = nx;
                bestY = ny;
                foundStep = true;
            }

            if (!foundStep)
            {
                _path.Clear();
                return;
            }

            reversePath.Add((currentX, currentY));
            currentX = bestX;
            currentY = bestY;
        }

        for (var i = reversePath.Count - 1; i >= 0; i--)
        {
            _path.Add(reversePath[i]);
        }
    }

    public bool IsEmpty()
    {
        return _pathIndex >= _path.Count;
    }

    public int StepCount()
    {
        return _path.Count - _pathIndex;
    }

    public bool TryWalk(ref int x, ref int y)
    {
        if (_pathIndex >= _path.Count)
        {
            return false;
        }

        (x, y) = _path[_pathIndex++];
        return true;
    }

    public void Reverse()
    {
        var remaining = _path.Count - _pathIndex;
        if (remaining <= 1)
        {
            return;
        }
        _path.Reverse(_pathIndex, remaining);
    }

    public (int X, int Y) GetStep(int index)
    {
        var absolute = _pathIndex + index;
        if (index < 0 || absolute >= _path.Count)
        {
            return (-1, -1);
        }

        return _path[absolute];
    }
}
