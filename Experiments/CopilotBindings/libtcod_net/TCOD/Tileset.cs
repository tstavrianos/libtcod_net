using System;

namespace libtcod_net.TCOD;

public sealed class Tileset : TCODResource
{
    private Tileset(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Tileset with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
    }

    public static Tileset LoadFromFile(
        string filename,
        int columns,
        int rows,
        ReadOnlySpan<int> charMap
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_tileset_load(filename, columns, rows, charMap);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFromMemory(
        ReadOnlySpan<byte> buffer,
        int columns,
        int rows,
        ReadOnlySpan<int> charMap
    )
    {
        var ret = libtcod.TCOD_tileset_load_mem(buffer, columns, rows, charMap);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFromBdf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_load_bdf(filename);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFromBdf(ReadOnlySpan<byte> buffer)
    {
        var ret = libtcod.TCOD_load_bdf_memory(buffer);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFromTTF(string filename, int tileWidth, int tileHeight)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_load_truetype_font_(filename, tileWidth, tileHeight);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFallbackFont(int tileWidth, int tileHeight)
    {
        var ret = libtcod.TCOD_tileset_load_fallback_font_(tileWidth, tileHeight);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_tileset_delete(Pointer);
    }
}
