using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a tileset resource.
/// </summary>
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

    /// <summary>
    /// Loads a tileset from a file. The file must be in PNG format, and the tileset must be organized in a grid of <paramref name="columns"/> by <paramref name="rows"/>. The <paramref name="charMap"/> parameter is an array of integers that maps each tile in the tileset to a specific character code. The length of the <paramref name="charMap"/> array must be equal to the total number of tiles in the tileset (columns * rows). Each integer in the <paramref name="charMap"/> array represents the character code that corresponds to the tile at that position in the grid. For example, if the first tile in the grid corresponds to the character 'A', then the first integer in the <paramref name="charMap"/> array should be the ASCII code for 'A' (65). This mapping allows you to use the tileset with specific character codes when rendering text or graphics in your application.
    /// </summary>
    /// <param name="filename">The path to the tileset file.</param>
    /// <param name="columns">The number of columns in the tileset.</param>
    /// <param name="rows">The number of rows in the tileset.</param>
    /// <param name="charMap">An array mapping each tile to a character code.</param>
    /// <returns>A new Tileset instance.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
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

    /// <summary>
    /// Loads a tileset from a memory buffer. The buffer must contain a PNG image, and the tileset must be organized in a grid of <paramref name="columns"/> by <paramref name="rows"/>. The <paramref name="charMap"/> parameter is an array of integers that maps each tile in the tileset to a specific character code. The length of the <paramref name="charMap"/> array must be equal to the total number of tiles in the tileset (columns * rows). Each integer in the <paramref name="charMap"/> array represents the character code that corresponds to the tile at that position in the grid. For example, if the first tile in the grid corresponds to the character 'A', then the first integer in the <paramref name="charMap"/> array should be the ASCII code for 'A' (65). This mapping allows you to use the tileset with specific character codes when rendering text or graphics in your application.
    /// </summary>
    /// <param name="buffer">The memory buffer containing the PNG image.</param>
    /// <param name="columns">The number of columns in the tileset.</param>
    /// <param name="rows">The number of rows in the tileset.</param>
    /// <param name="charMap">An array mapping each tile to a character code.</param>
    /// <returns>A new Tileset instance.</returns>
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

    /// <summary>
    /// Loads a tileset from a BDF (Bitmap Distribution Format) file.
    /// </summary>
    /// <param name="filename">The path to the BDF file.</param>
    /// <returns>A new Tileset instance.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public static Tileset LoadFromBdf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_load_bdf(filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    /// <summary>
    /// Loads a tileset from a BDF (Bitmap Distribution Format) file in memory.
    /// </summary>
    /// <param name="buffer">The memory buffer containing the BDF file.</param>
    /// <returns>A new Tileset instance.</returns>
    public static Tileset LoadFromBdf(ReadOnlySpan<byte> buffer)
    {
        fixed (byte* b = buffer)
        {
            var ret = TCOD_load_bdf_memory(buffer.Length, b);
            ErrorHelper.CheckAndThrow(ret);
            return new Tileset(ret);
        }
    }

    /// <summary>
    /// Loads a tileset from a TrueType font (TTF) file. The <paramref name="tileWidth"/> and <paramref name="tileHeight"/> parameters specify the dimensions of each tile in the tileset. The TTF file will be rendered into a grid of tiles based on these dimensions, and each tile will correspond to a specific character code. This allows you to use the TTF font as a tileset for rendering text or graphics in your application.
    /// </summary>
    /// <param name="filename">The path to the TTF file.</param>
    /// <param name="tileWidth">The width of each tile in the tileset.</param>
    /// <param name="tileHeight">The height of each tile in the tileset.</param>
    /// <returns>A new Tileset instance.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public static Tileset LoadFromTTF(string filename, int tileWidth, int tileHeight)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_load_truetype_font_(filenamePtr.CStr, tileWidth, tileHeight);
        ErrorHelper.CheckAndThrow(ret);
        return new Tileset(ret);
    }

    /// <summary>
    /// Loads a fallback font as a tileset. The <paramref name="tileWidth"/> and <paramref name="tileHeight"/> parameters specify the dimensions of each tile in the tileset. The fallback font is a built-in font that can be used when a specific font cannot be loaded. It provides a basic set of characters and is designed to be compatible with a wide range of systems and configurations. This method allows you to use the fallback font as a tileset for rendering text or graphics in your application when other fonts are unavailable.
    /// </summary>
    /// <param name="tileWidth">The width of each tile in the tileset.</param>
    /// <param name="tileHeight">The height of each tile in the tileset.</param>
    /// <returns>A new Tileset instance.</returns>
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
