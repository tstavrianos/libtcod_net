using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_tileset_load(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_tileset_load_mem(
        nuint buffer_length,
        nint buffer,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_tileset_load_raw(
        int width,
        int height,
        nint pixels,
        int columns,
        int rows,
        int n,
        nint charmap
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_tileset_delete(nint tileset);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_load_bdf([MarshalAs(UnmanagedType.LPUTF8Str)] string bdf);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_load_bdf_memory(int size, nint buffer);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_load_truetype_font_(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int tile_width,
        int tile_height
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_tileset_load_fallback_font_(int tile_width, int tile_height);

    public static unsafe nint TCOD_tileset_load(
        string filename,
        int columns,
        int rows,
        ReadOnlySpan<int> charmap
    )
    {
        fixed (int* c = charmap)
        {
            return TCOD_tileset_load(filename, columns, rows, charmap.Length, (nint)c);
        }
    }

    public static nint TCOD_tileset_load(string filename, int columns, int rows, int[] charmap)
    {
        return TCOD_tileset_load(filename, columns, rows, charmap.AsSpan());
    }

    public static unsafe nint TCOD_tileset_load_mem(
        ReadOnlySpan<byte> buffer,
        int columns,
        int rows,
        ReadOnlySpan<int> charmap
    )
    {
        fixed (byte* b = buffer)
        fixed (int* c = charmap)
            return TCOD_tileset_load_mem(
                (nuint)buffer.Length,
                (nint)b,
                columns,
                rows,
                charmap.Length,
                (nint)c
            );
    }

    public static nint TCOD_tileset_load_mem(byte[] buffer, int columns, int rows, int[] charmap)
    {
        return TCOD_tileset_load_mem(buffer.AsSpan(), columns, rows, charmap.AsSpan());
    }

    public static unsafe nint TCOD_tileset_load_raw(
        int width,
        int height,
        ReadOnlySpan<TCOD_ColorRGBA> pixels,
        int columns,
        int rows,
        ReadOnlySpan<int> charmap
    )
    {
        fixed (TCOD_ColorRGBA* p = pixels)
        fixed (int* c = charmap)
            return TCOD_tileset_load_raw(
                width,
                height,
                (nint)p,
                columns,
                rows,
                charmap.Length,
                (nint)c
            );
    }

    public static nint TCOD_tileset_load_raw(
        int width,
        int height,
        TCOD_ColorRGBA[] pixels,
        int columns,
        int rows,
        int[] charmap
    )
    {
        return TCOD_tileset_load_raw(
            width,
            height,
            pixels.AsSpan(),
            columns,
            rows,
            charmap.AsSpan()
        );
    }

    public static unsafe nint TCOD_load_bdf_memory(ReadOnlySpan<byte> buffer)
    {
        fixed (byte* b = buffer)
            return TCOD_load_bdf_memory(buffer.Length, (nint)b);
    }

    public static nint TCOD_load_bdf_memory(byte[] buffer)
    {
        return TCOD_load_bdf_memory(buffer.AsSpan());
    }
}
