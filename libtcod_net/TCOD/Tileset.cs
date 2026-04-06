using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class Tileset : TCODResource<TCOD_Tileset>
{
    private Tileset(TCOD_Tileset* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Tileset with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
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
        using var filenamePtr = new StringMarshal(filename);
        fixed (int* c = charMap)
        {
            var ret = TCOD_tileset_load(filenamePtr.CStr, columns, rows, charMap.Length, c);

            ErrorHelper.CheckAndThrow(ret);
            return new Tileset(ret);
        }
    }

    public static Tileset LoadFromMemory(
        ReadOnlySpan<byte> buffer,
        int columns,
        int rows,
        ReadOnlySpan<int> charMap
    )
    {
        fixed (byte* b = buffer)
        fixed (int* c = charMap)
        {
            var ret = TCOD_tileset_load_mem(
                (ulong)buffer.Length,
                b,
                columns,
                rows,
                charMap.Length,
                c
            );
            ErrorHelper.CheckAndThrow(ret);
            return new Tileset(ret);
        }
    }

    public static Tileset LoadFromBdf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_load_bdf(filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFromBdf(ReadOnlySpan<byte> buffer)
    {
        fixed (byte* b = buffer)
        {
            var ret = TCOD_load_bdf_memory(buffer.Length, b);
            ErrorHelper.CheckAndThrow(ret);
            return new Tileset(ret);
        }
    }

    public static Tileset LoadFromTTF(string filename, int tileWidth, int tileHeight)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_load_truetype_font_(filenamePtr.CStr, tileWidth, tileHeight);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    public static Tileset LoadFallbackFont(int tileWidth, int tileHeight)
    {
        var ret = TCOD_tileset_load_fallback_font_(tileWidth, tileHeight);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_tileset_delete(Pointer);
    }
}
