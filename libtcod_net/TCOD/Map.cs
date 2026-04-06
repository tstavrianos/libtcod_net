using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class Map : TCODResource<TCOD_Map>
{
    public int Width { get; }
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

    public static Map Create(int width, int height)
    {
        var p = TCOD_map_new(width, height);
        ErrorHelper.CheckAndThrow(p);
        return new Map(p);
    }

    public void Clear(bool transparent = false, bool walkable = false)
    {
        TCOD_map_clear(Pointer, transparent, walkable);
    }

    public void SetProperties(int x, int y, bool isTransparent, bool isWalkable)
    {
        TCOD_map_set_properties(Pointer, x, y, isTransparent, isWalkable);
    }

    public bool IsTransparent(int x, int y)
    {
        return TCOD_map_is_transparent(Pointer, x, y);
    }

    public bool IsWalkable(int x, int y)
    {
        return TCOD_map_is_walkable(Pointer, x, y);
    }

    public void SetInFov(int x, int y, bool inFov)
    {
        TCOD_map_set_in_fov(Pointer, x, y, inFov);
    }

    public bool IsInFov(int x, int y)
    {
        return TCOD_map_is_in_fov(Pointer, x, y);
    }

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
