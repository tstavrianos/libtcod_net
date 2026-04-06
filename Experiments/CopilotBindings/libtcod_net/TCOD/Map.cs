using System;
using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

public class Map : TCODResource
{
    public int Width { get; }
    public int Height { get; }

    private Map(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Map with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
        var s = Marshal.PtrToStructure<libtcod.TCOD_Map>(pointer);
        Width = s.width;
        Height = s.height;
    }

    public static Map Create(int width, int height)
    {
        var p = libtcod.TCOD_map_new(width, height);
        ErrorHelper.CheckAndThrow(p);
        return new Map(p);
    }

    public void Clear(bool transparent = false, bool walkable = false)
    {
        libtcod.TCOD_map_clear(Pointer, transparent, walkable);
    }

    public void SetProperties(int x, int y, bool isTransparent, bool isWalkable)
    {
        libtcod.TCOD_map_set_properties(Pointer, x, y, isTransparent, isWalkable);
    }

    public bool IsTransparent(int x, int y)
    {
        return libtcod.TCOD_map_is_transparent(Pointer, x, y);
    }

    public bool IsWalkable(int x, int y)
    {
        return libtcod.TCOD_map_is_walkable(Pointer, x, y);
    }

    public void SetInFov(int x, int y, bool inFov)
    {
        libtcod.TCOD_map_set_in_fov(Pointer, x, y, inFov);
    }

    public bool IsInFov(int x, int y)
    {
        return libtcod.TCOD_map_is_in_fov(Pointer, x, y);
    }

    public void ComputeFov(
        int x,
        int y,
        int radius,
        bool lightWalls = true,
        libtcod.TCOD_fov_algorithm_t algorithm = libtcod.TCOD_fov_algorithm_t.FOV_BASIC
    )
    {
        var ret = libtcod.TCOD_map_compute_fov(Pointer, x, y, radius, lightWalls, algorithm);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void Copy(Map map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var ret = libtcod.TCOD_map_copy(Pointer, map.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_map_delete(Pointer);
    }
}
