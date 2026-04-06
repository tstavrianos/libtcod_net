using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a map for pathfinding and field of view calculations.
/// </summary>
public sealed unsafe class Map : TCODResource<TCOD_Map>
{
    /// <summary>
    /// Gets the width of the map.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the map.
    /// </summary>
    public int Height { get; }

    private Map(TCOD_Map* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Map with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
        Width = pointer->width;
        Height = pointer->height;
    }

    /// <summary>
    /// Creates a new map with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the map.</param>
    /// <param name="height">The height of the map.</param>
    /// <returns>A new Map instance.</returns>
    public static Map Create(int width, int height)
    {
        var p = TCOD_map_new(width, height);
        ErrorHelper.CheckAndThrow(p);
        return new Map(p);
    }

    /// <summary>
    /// Clears the map, setting all cells to the specified transparency and walkability.
    /// </summary>
    /// <param name="transparent">Whether the cells should be transparent.</param>
    /// <param name="walkable">Whether the cells should be walkable.</param>
    public void Clear(bool transparent = false, bool walkable = false)
    {
        TCOD_map_clear(Pointer, transparent, walkable);
    }

    /// <summary>
    /// Sets the properties of a specific cell in the map.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <param name="isTransparent">Whether the cell should be transparent.</param>
    /// <param name="isWalkable">Whether the cell should be walkable.</param>
    public void SetProperties(int x, int y, bool isTransparent, bool isWalkable)
    {
        TCOD_map_set_properties(Pointer, x, y, isTransparent, isWalkable);
    }

    /// <summary>
    /// Checks if a specific cell is transparent.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if the cell is transparent, otherwise false.</returns>
    public bool IsTransparent(int x, int y)
    {
        return TCOD_map_is_transparent(Pointer, x, y);
    }

    /// <summary>
    /// Checks if a specific cell is walkable.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if the cell is walkable, otherwise false.</returns>
    public bool IsWalkable(int x, int y)
    {
        return TCOD_map_is_walkable(Pointer, x, y);
    }

    /// <summary>
    /// Sets whether a specific cell is in the field of view.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <param name="inFov">Whether the cell is in the field of view.</param>
    public void SetInFov(int x, int y, bool inFov)
    {
        TCOD_map_set_in_fov(Pointer, x, y, inFov);
    }

    /// <summary>
    /// Checks if a specific cell is in the field of view.
    /// </summary>
    /// <param name="x">The x-coordinate of the cell.</param>
    /// <param name="y">The y-coordinate of the cell.</param>
    /// <returns>True if the cell is in the field of view, otherwise false.</returns>
    public bool IsInFov(int x, int y)
    {
        return TCOD_map_is_in_fov(Pointer, x, y);
    }

    /// <summary>
    /// Computes the field of view for the map.
    /// </summary>
    /// <param name="x">The x-coordinate of the starting point.</param>
    /// <param name="y">The y-coordinate of the starting point.</param>
    /// <param name="radius">The radius of the field of view.</param>
    /// <param name="lightWalls">Whether to light walls.</param>
    /// <param name="algorithm">The algorithm to use for field of view calculation.</param>
    public void ComputeFov(
        int x,
        int y,
        int radius,
        bool lightWalls = true,
        TCOD_fov_algorithm_t algorithm = TCOD_fov_algorithm_t.FOV_BASIC
    )
    {
        var ret = TCOD_map_compute_fov(Pointer, x, y, radius, lightWalls, algorithm);
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// Copies the properties of another map into this map.
    /// </summary>
    /// <param name="map">The map to copy from.</param>
    public void Copy(Map map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var ret = TCOD_map_copy(Pointer, map.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_map_delete(Pointer);
    }
}
