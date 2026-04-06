using System;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a Dijkstra map, which can be used for pathfinding and distance calculations on a grid-based map.
/// </summary>
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

    /// <summary>
    /// Creates a new Dijkstra map using the specified map and diagonal cost.
    /// </summary>
    /// <param name="map">The map to use for the Dijkstra map.</param>
    /// <param name="diagonalCost">The cost of moving diagonally.</param>
    /// <returns>A new Dijkstra map instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the map is null.</exception>
    public static Dijkstra Create(Map map, float diagonalCost)
    {
        ArgumentNullException.ThrowIfNull(map);
        var p = TCOD_dijkstra_new(map.Pointer, diagonalCost);
        ErrorHelper.CheckAndThrow(p);
        return new Dijkstra(p);
    }

    /// <summary>
    /// Creates a new Dijkstra map using a custom path cost function.
    /// </summary>
    /// <param name="mapWidth">The width of the map.</param>
    /// <param name="mapHeight">The height of the map.</param>
    /// <param name="callback">The callback function to determine the cost of moving through each cell.</param>
    /// <param name="userData">User-defined data to pass to the callback function.</param>
    /// <param name="diagonalCost">The cost of moving diagonally. Can be set to 0 for no diagonal movement.</param>
    /// <typeparam name="T">The type of the user-defined data.</typeparam>
    /// <returns>A new Dijkstra map instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the callback is null.</exception>
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

    /// <summary>
    /// Computes the Dijkstra map from the specified root position.
    /// </summary>
    /// <param name="xRoot">The x-coordinate of the root position.</param>
    /// <param name="yRoot">The y-coordinate of the root position.</param>
    public void Compute(int xRoot, int yRoot)
    {
        TCOD_dijkstra_compute(Pointer, xRoot, yRoot);
    }

    /// <summary>
    /// Gets the distance from the root position to the specified cell.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>The distance from the root position to the specified cell. If the cell is unreachable, it will return -1.0f</returns>
    public float GetDistance(int x, int y)
    {
        return TCOD_dijkstra_get_distance(Pointer, x, y);
    }

    /// <summary>
    /// Attempts to create a path from the root position to the specified cell. If a path exists, it will be stored internally and can be walked using the <see cref="TryWalk"/> method.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if a path is set to the specified cell; otherwise, false.</returns>
    public bool TryCreatePath(int x, int y)
    {
        return TCOD_dijkstra_path_set(Pointer, x, y);
    }

    /// <summary>
    /// Walks one step along the currently set path. The x and y parameters will be updated to the new coordinates after the step. If there are no more steps to walk, this method will return false.
    /// </summary>
    /// <param name="x">This value will be updated to the new x-coordinate after the step.</param>
    /// <param name="y">This value will be updated to the new y-coordinate after the step.</param>
    /// <returns>True if the step was successful; otherwise, false.</returns>
    public bool TryWalk(ref int x, ref int y)
    {
        var x_ = x;
        var y_ = y;
        var ret = TCOD_dijkstra_path_walk(Pointer, &x_, &y_);
        x = x_;
        y = y_;
        return ret;
    }

    /// <summary>
    /// Determines whether the currently set path is empty.
    /// </summary>
    public bool IsEmpty => TCOD_dijkstra_is_empty(Pointer);

    /// <summary>
    /// Gets the number of steps in the currently set path. If there is no path set or the path has been fully walked, this will return 0.
    /// </summary>
    /// <remarks>This gets updated each time a step is walked using the <see cref="TryWalk"/> method.</remarks>
    public int StepCount => TCOD_dijkstra_size(Pointer);

    /// <summary>
    /// Gets the coordinates of the step at the specified index in the currently set path. The index is zero-based, so the first step is at index 0. If the index is out of range (less than 0 or greater than or equal to <see cref="StepCount"/>), this method will throw an <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <remarks>Refer to StepCount for the allowable range of indices.</remarks>
    /// <param name="index"></param>
    /// <returns></returns>
    public (int X, int Y) GetStep(int index)
    {
        int x,
            y;
        TCOD_dijkstra_get(Pointer, index, &x, &y);
        return (x, y);
    }

    /// <summary>
    /// Reverses the currently set path. After calling this method, the path will be walked in the opposite direction.
    /// </summary>
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
