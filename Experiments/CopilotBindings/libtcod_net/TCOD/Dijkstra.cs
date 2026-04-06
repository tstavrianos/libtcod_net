using System;
using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

public class Dijkstra : TCODResource
{
    private libtcod.TCOD_path_func_t? _pathCostThunk;
    private GCHandle _pathCostStateHandle;
    private bool _hasPathCostState;

    private Dijkstra(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Dijkstra with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
    }

    public static Dijkstra Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = libtcod.TCOD_dijkstra_new(map.Pointer, diagonalCost);
        ErrorHelper.CheckAndThrow(p);
        return new Dijkstra(p);
    }

    public static Dijkstra Create<T>(
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
            var p = libtcod.TCOD_dijkstra_new_using_function(
                mapWidth,
                mapHeight,
                pathCallback,
                GCHandle.ToIntPtr(stateHandle),
                diagonalCost
            );
            ErrorHelper.CheckAndThrow(p);

            var path = new Dijkstra(p)
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

    public void Compute(int xRoot, int yRoot)
    {
        libtcod.TCOD_dijkstra_compute(Pointer, xRoot, yRoot);
    }

    public float GetDistance(int x, int y)
    {
        return libtcod.TCOD_dijkstra_get_distance(Pointer, x, y);
    }

    public bool IsPathSet(int x, int y)
    {
        return libtcod.TCOD_dijkstra_path_set(Pointer, x, y);
    }

    public bool TryWalk(ref int x, ref int y)
    {
        return libtcod.TCOD_dijkstra_path_walk(Pointer, ref x, ref y);
    }

    public bool IsEmpty => libtcod.TCOD_dijkstra_is_empty(Pointer);
    public int StepCount => libtcod.TCOD_dijkstra_size(Pointer);

    public (int X, int Y) GetStep(int index)
    {
        libtcod.TCOD_dijkstra_get(Pointer, index, out var x, out var y);
        return (x, y);
    }

    public void Reverse()
    {
        libtcod.TCOD_dijkstra_reverse(Pointer);
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

        libtcod.TCOD_dijkstra_delete(Pointer);
    }
}
