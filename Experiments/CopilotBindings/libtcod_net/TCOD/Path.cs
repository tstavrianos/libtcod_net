using System;
using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

public delegate float PathCost<in T>(int xFrom, int yFrom, int xTo, int yTo, T? userData)
    where T : notnull;

internal sealed class PathCostState<T>(PathCost<T> callback, T? userData)
    where T : notnull
{
    public PathCost<T> Callback { get; } = callback;
    public T? UserData { get; } = userData;
}

public class Path : TCODResource
{
    private libtcod.TCOD_path_func_t? _pathCostThunk;
    private GCHandle _pathCostStateHandle;
    private bool _hasPathCostState;

    private Path(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Path with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
    }

    public static Path Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = libtcod.TCOD_path_new_using_map(map.Pointer, diagonalCost);
        ErrorHelper.CheckAndThrow(p);
        return new Path(p);
    }

    public static Path Create<T>(
        int mapWidth,
        int mapHeight,
        PathCost<T> callback,
        T? userData,
        float diagonalCost
    )
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new PathCostState<T>(callback, userData);
        var stateHandle = GCHandle.Alloc(state);
        libtcod.TCOD_path_func_t pathCallback = BridgePathCost<T>;
        try
        {
            var p = libtcod.TCOD_path_new_using_function(
                mapWidth,
                mapHeight,
                pathCallback,
                GCHandle.ToIntPtr(stateHandle),
                diagonalCost
            );
            ErrorHelper.CheckAndThrow(p);

            var path = new Path(p)
            {
                _pathCostThunk = pathCallback,
                _pathCostStateHandle = stateHandle,
                _hasPathCostState = true,
            };

            return path;
        }
        catch
        {
            if (stateHandle.IsAllocated)
                stateHandle.Free();
            throw;
        }
    }

    private static float BridgePathCost<T>(int xFrom, int yFrom, int xTo, int yTo, nint userData)
        where T : notnull
    {
        var state = (PathCostState<T>)GCHandle.FromIntPtr(userData).Target!;
        return state.Callback(xFrom, yFrom, xTo, yTo, state.UserData);
    }

    public bool Compute(int xOrigin, int yOrigin, int xDestination, int yDestination)
    {
        return libtcod.TCOD_path_compute(Pointer, xOrigin, yOrigin, xDestination, yDestination);
    }

    public bool IsEmpty => libtcod.TCOD_path_is_empty(Pointer);
    public int StepCount => libtcod.TCOD_path_size(Pointer);

    public void Reverse()
    {
        libtcod.TCOD_path_reverse(Pointer);
    }

    public (int X, int Y) GetStep(int index)
    {
        libtcod.TCOD_path_get(Pointer, index, out var x, out var y);
        return (x, y);
    }

    public (int X, int Y) GetOrigin()
    {
        libtcod.TCOD_path_get_origin(Pointer, out var x, out var y);
        return (x, y);
    }

    public (int X, int Y) GetDestination()
    {
        libtcod.TCOD_path_get_destination(Pointer, out var x, out var y);
        return (x, y);
    }

    public bool TryWalk(ref int x, ref int y, bool recalculateWhenNeeded)
    {
        return libtcod.TCOD_path_walk(Pointer, ref x, ref y, recalculateWhenNeeded);
    }

    protected override void ReleaseUnmanagedResources()
    {
        if (_hasPathCostState)
        {
            GC.KeepAlive(_pathCostThunk);
            _pathCostThunk = null;
            if (_pathCostStateHandle.IsAllocated)
                _pathCostStateHandle.Free();
            _hasPathCostState = false;
        }

        libtcod.TCOD_path_delete(Pointer);
    }
}
