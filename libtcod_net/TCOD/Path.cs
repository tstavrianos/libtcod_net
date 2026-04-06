using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public delegate float PathCost<in T>(int xFrom, int yFrom, int xTo, int yTo, T? userData)
    where T : notnull;

internal abstract class PathCostStateBase
{
    public abstract float Invoke(int xFrom, int yFrom, int xTo, int yTo);
}

internal sealed class PathCostState<T>(PathCost<T> callback, T? userData) : PathCostStateBase
    where T : notnull
{
    public override float Invoke(int xFrom, int yFrom, int xTo, int yTo) =>
        callback(xFrom, yFrom, xTo, yTo, userData);
}

internal static class PathCostBridge
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe float Invoke(int xFrom, int yFrom, int xTo, int yTo, void* userData)
    {
        var state = (PathCostStateBase)GCHandle.FromIntPtr((nint)userData).Target!;
        return state.Invoke(xFrom, yFrom, xTo, yTo);
    }
}

public sealed unsafe class Path : TCODResource<TCOD_Path>
{
    private GCHandle _pathCostStateHandle;
    private bool _hasPathCostState;

    private Path(TCOD_Path* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Path with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
    }

    public static Path Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = TCOD_path_new_using_map(map.Pointer, diagonalCost);
        ErrorHelper.CheckAndThrow(p.Data);
        return new Path(p.Data);
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
        try
        {
            var p = TCOD_path_new_using_function(
                mapWidth,
                mapHeight,
                new TCOD_path_func_t(&PathCostBridge.Invoke),
                GCHandle.ToIntPtr(stateHandle).ToPointer(),
                diagonalCost
            );
            ErrorHelper.CheckAndThrow(p.Data);

            var path = new Path(p.Data)
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

    public bool Compute(int xOrigin, int yOrigin, int xDestination, int yDestination)
    {
        return TCOD_path_compute(Pointer, xOrigin, yOrigin, xDestination, yDestination);
    }

    public bool IsEmpty => TCOD_path_is_empty(Pointer);
    public int StepCount => TCOD_path_size(Pointer);

    public void Reverse()
    {
        TCOD_path_reverse(Pointer);
    }

    public (int X, int Y) GetStep(int index)
    {
        int x,
            y;
        TCOD_path_get(Pointer, index, &x, &y);
        return (x, y);
    }

    public (int X, int Y) GetOrigin()
    {
        int x,
            y;
        TCOD_path_get_origin(Pointer, &x, &y);
        return (x, y);
    }

    public (int X, int Y) GetDestination()
    {
        int x,
            y;
        TCOD_path_get_destination(Pointer, &x, &y);
        return (x, y);
    }

    public bool TryWalk(ref int x, ref int y, bool recalculateWhenNeeded)
    {
        var x_ = x;
        var y_ = y;
        var ret = TCOD_path_walk(Pointer, &x_, &y_, recalculateWhenNeeded);
        x = x_;
        y = y_;
        return ret;
    }

    protected override void ReleaseUnmanagedResources()
    {
        if (_hasPathCostState)
        {
            if (_pathCostStateHandle.IsAllocated)
                _pathCostStateHandle.Free();
            _hasPathCostState = false;
        }

        TCOD_path_delete(Pointer);
    }
}
