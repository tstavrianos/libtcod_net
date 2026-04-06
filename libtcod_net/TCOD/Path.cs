using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a callback function for calculating the cost of moving from one point to another in a pathfinding algorithm.
/// </summary>
/// <typeparam name="T">The type of user data associated with the pathfinding.</typeparam>
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

/// <summary>
/// A* pathfinding algorithm implementation that can be used to compute paths on a map. It supports both map-based and function-based cost calculations, allowing for flexible pathfinding scenarios. The class manages the lifecycle of the underlying TCOD_Path resource and ensures proper cleanup of any associated state.
/// </summary>
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

    /// <summary>
    /// Creates a new pathfinding instance using a map. The diagonalCost parameter specifies the cost of moving diagonally, which can be used to influence the pathfinding algorithm's behavior. A higher diagonal cost will make the algorithm prefer orthogonal movements, while a lower diagonal cost will allow for more diagonal movements. This method is suitable for scenarios where the pathfinding needs to consider the layout of a map, such as in grid-based games.
    /// </summary>
    /// <param name="map">The map to use for pathfinding.</param>
    /// <param name="diagonalCost">The cost of moving diagonally. Set to 0.0f if you don't want to allow diagonal movement.</param>
    /// <returns>A new Path instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if map is null.</exception>
    public static Path Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = TCOD_path_new_using_map(map.Pointer, diagonalCost);
        ErrorHelper.CheckAndThrow(p.Data);
        return new Path(p.Data);
    }

    /// <summary>
    /// Creates a new pathfinding instance using a custom cost function. This method allows for more flexible pathfinding scenarios, where the cost of moving from one point to another can be dynamically calculated based on user-defined logic.
    /// </summary>
    /// <param name="mapWidth">The width of the map.</param>
    /// <param name="mapHeight">The height of the map.</param>
    /// <param name="callback">The callback function to calculate the cost of moving from one point to another.</param>
    /// <param name="userData">The user data to pass to the callback function.</param>
    /// <param name="diagonalCost">The cost of moving diagonally. Set to 0.0f if you don't want to allow diagonal movement.</param>
    /// <typeparam name="T">The type of user data associated with the pathfinding.</typeparam>
    /// <returns>A new Path instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if callback is null.</exception>
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

    /// <summary>
    /// Computes a path from the origin to the destination. The method returns true if a path was successfully computed, and false otherwise. The computed path can then be accessed using the GetStep, GetOrigin, and GetDestination methods. This method should be called after creating a Path instance and before attempting to walk the path or access its steps.
    /// </summary>
    /// <param name="xOrigin">The x-coordinate of the origin.</param>
    /// <param name="yOrigin">The y-coordinate of the origin.</param>
    /// <param name="xDestination">The x-coordinate of the destination.</param>
    /// <param name="yDestination">The y-coordinate of the destination.</param>
    /// <returns>True if a path was successfully computed, false otherwise.</returns>
    public bool Compute(int xOrigin, int yOrigin, int xDestination, int yDestination)
    {
        return TCOD_path_compute(Pointer, xOrigin, yOrigin, xDestination, yDestination);
    }

    /// <summary>
    /// Returns if either <see cref="Compute"/> was not called yet, no path exists from the current origin to the destination or the path has been fully walked.
    /// </summary>
    public bool IsEmpty => TCOD_path_is_empty(Pointer);

    /// <summary>
    /// Gets the number of steps required to reach the destination from the current origin.
    /// </summary>
    /// <remarks>The step count decreases as the path is walked.</remarks>
    public int StepCount => TCOD_path_size(Pointer);

    /// <summary>
    /// Reverses the path.
    /// </summary>
    public void Reverse()
    {
        TCOD_path_reverse(Pointer);
    }

    /// <summary>
    /// Get the coordinates at a specific step in the path. Check StepCount to determine the valid range of indices.
    /// </summary>
    /// <param name="index">The index of the step to retrieve.</param>
    /// <returns>A tuple containing the x and y coordinates of the specified step. If the index is out of range, the tuple will contain (-1, -1).</returns>
    public (int X, int Y) GetStep(int index)
    {
        int x = -1,
            y = -1;
        TCOD_path_get(Pointer, index, &x, &y);
        return (x, y);
    }

    /// <summary>
    /// Gets the coordinates of the current origin of the path.
    /// </summary>
    /// <remarks>The origin changes as the path is walked.</remarks>
    /// <returns>A tuple containing the x and y coordinates of the origin. If the origin is not set, the tuple will contain (-1, -1).</returns>
    public (int X, int Y) GetOrigin()
    {
        int x = -1,
            y = -1;
        TCOD_path_get_origin(Pointer, &x, &y);
        return (x, y);
    }

    /// <summary>
    /// Gets the coordinates of the destination of the path.
    /// </summary>
    /// <returns>A tuple containing the x and y coordinates of the destination. If the destination is not set, the tuple will contain (-1, -1).</returns>
    public (int X, int Y) GetDestination()
    {
        int x = -1,
            y = -1;
        TCOD_path_get_destination(Pointer, &x, &y);
        return (x, y);
    }

    /// <summary>
    /// Attempts to walk along the path and go to the next step.
    /// </summary>
    /// <remarks>Walking the path consumes one step (and decreases the path size by one). The function returns false if recalculateWhenNeeded is false and the next cell on the path is no longer walkable, or if recalculateWhenNeeded is true, the next cell on the path is no longer walkable and no other path has been found.</remarks>
    /// <param name="x">The current x coordinate, which will be updated to the next step.</param>
    /// <param name="y">The current y coordinate, which will be updated to the next step.</param>
    /// <param name="recalculateWhenNeeded">Indicates whether the path should be recalculated if necessary.</param>
    /// <returns>True if the walk was successful, false otherwise.</returns>
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
