using System;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class Dijkstra : TCODResource<TCOD_Dijkstra>
{
    private GCHandle _pathCostStateHandle;
    private bool _hasPathCostState;

    private Dijkstra(TCOD_Dijkstra* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Dijkstra with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
    }

    public static Dijkstra Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = TCOD_dijkstra_new(map.Pointer, diagonalCost);
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
        try
        {
            var p = TCOD_dijkstra_new_using_function(
                mapWidth,
                mapHeight,
                new TCOD_path_func_t(&PathCostBridge.Invoke),
                GCHandle.ToIntPtr(stateHandle).ToPointer(),
                diagonalCost
            );
            ErrorHelper.CheckAndThrow(p);

            var path = new Dijkstra(p)
            {
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

    public void Compute(int xRoot, int yRoot)
    {
        TCOD_dijkstra_compute(Pointer, xRoot, yRoot);
    }

    public float GetDistance(int x, int y)
    {
        return TCOD_dijkstra_get_distance(Pointer, x, y);
    }

    public bool IsPathSet(int x, int y)
    {
        return TCOD_dijkstra_path_set(Pointer, x, y);
    }

    public bool TryWalk(ref int x, ref int y)
    {
        var x_ = x;
        var y_ = y;
        var ret = TCOD_dijkstra_path_walk(Pointer, &x_, &y_);
        x = x_;
        y = y_;
        return ret;
    }

    public bool IsEmpty => TCOD_dijkstra_is_empty(Pointer);
    public int StepCount => TCOD_dijkstra_size(Pointer);

    public (int X, int Y) GetStep(int index)
    {
        int x,
            y;
        TCOD_dijkstra_get(Pointer, index, &x, &y);
        return (x, y);
    }

    public void Reverse()
    {
        TCOD_dijkstra_reverse(Pointer);
    }

    protected override void ReleaseUnmanagedResources()
    {
        if (_hasPathCostState)
        {
            if (_pathCostStateHandle.IsAllocated)
                _pathCostStateHandle.Free();
            _hasPathCostState = false;
        }

        TCOD_dijkstra_delete(Pointer);
    }
}
