using System;
using System.Runtime.InteropServices;
using System.Text;
using libtcod_net.TCOD;

namespace libtcod_net;

public static partial class libtcod
{
    public static string TCOD_get_error()
    {
        var ptr = TCOD_get_error_();
        return ptr == nint.Zero ? string.Empty : Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }

    public static TCOD_Error TCOD_console_printn(
        nint console,
        int x,
        int y,
        string str,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }

            return TCOD_console_printn(
                console,
                x,
                y,
                (nuint)Encoding.UTF8.GetByteCount(str),
                str,
                marshalFg,
                marshalBg,
                flag,
                alignment
            );
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static int TCOD_console_printn_rect(
        nint console,
        int x,
        int y,
        int width,
        int height,
        string str,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }
            return TCOD_console_printn_rect(
                console,
                x,
                y,
                width,
                height,
                (nuint)Encoding.UTF8.GetByteCount(str),
                str,
                marshalFg,
                marshalBg,
                flag,
                alignment
            );
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static int TCOD_printn_rgb(
        nint console,
        int x,
        int y,
        int width,
        int height,
        string str,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }
            var p = new TCOD_PrintParamsRGB()
            {
                x = x,
                y = y,
                width = width,
                height = height,
                fg = marshalFg,
                bg = marshalBg,
                flag = flag,
                alignment = alignment,
            };
            return TCOD_printn_rgb(console, p, Encoding.UTF8.GetByteCount(str), str);
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static int TCOD_console_get_height_rect_n(
        nint console,
        int x,
        int y,
        int width,
        int height,
        string str
    )
    {
        return TCOD_console_get_height_rect_n(
            console,
            x,
            y,
            width,
            height,
            (nuint)Encoding.UTF8.GetByteCount(str),
            str
        );
    }

    public static int TCOD_console_get_height_rect_wn(int width, string str)
    {
        return TCOD_console_get_height_rect_wn(width, (nuint)Encoding.UTF8.GetByteCount(str), str);
    }

    public static void TCOD_console_blit_key_color(
        nint src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        nint dst,
        int xDst,
        int yDst,
        float foreground_alpha,
        float background_alpha,
        TCOD_ColorRGB? key_color
    )
    {
        nint marshal = nint.Zero;
        try
        {
            if (key_color.HasValue)
            {
                marshal = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)key_color.Value, marshal, false);
            }
            TCOD_console_blit_key_color(
                src,
                xSrc,
                ySrc,
                wSrc,
                hSrc,
                dst,
                xDst,
                yDst,
                foreground_alpha,
                background_alpha,
                marshal
            );
        }
        finally
        {
            if (marshal != nint.Zero)
                Marshal.FreeHGlobal(marshal);
        }
    }

    public static void TCOD_console_put_rgb(
        nint console,
        int x,
        int y,
        int ch,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }

            TCOD_console_put_rgb(console, x, y, ch, marshalFg, marshalBg, flag);
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static TCOD_Error TCOD_console_draw_rect_rgb(
        nint console,
        int x,
        int y,
        int width,
        int height,
        int ch,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }

            return TCOD_console_draw_rect_rgb(
                console,
                x,
                y,
                width,
                height,
                ch,
                marshalFg,
                marshalBg,
                flag
            );
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        nint decoration,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        bool clear
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }

            return TCOD_console_draw_frame_rgb(
                con,
                x,
                y,
                width,
                height,
                decoration,
                marshalFg,
                marshalBg,
                flag,
                clear
            );
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

    public static TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        int[] decoration,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        bool clear
    )
    {
        nint marshalFg = nint.Zero,
            marshalBg = nint.Zero;
        try
        {
            if (fg.HasValue)
            {
                marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            }
            if (bg.HasValue)
            {
                marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
            }

            return TCOD_console_draw_frame_rgb(
                con,
                x,
                y,
                width,
                height,
                decoration,
                marshalFg,
                marshalBg,
                flag,
                clear
            );
        }
        finally
        {
            if (marshalFg != nint.Zero)
                Marshal.FreeHGlobal(marshalFg);
            if (marshalBg != nint.Zero)
                Marshal.FreeHGlobal(marshalBg);
        }
    }

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

    public static unsafe void TCOD_heightmap_dig_bezier(
        nint hm,
        ReadOnlySpan<int> px,
        ReadOnlySpan<int> py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    )
    {
        if (px.Length < 4 || py.Length < 4)
            throw new TCODException(
                "px and py should contain at least 4 elements each",
                TCOD_Error.TCOD_E_ERROR
            );
        fixed (int* x = px)
        fixed (int* y = py)
            TCOD_heightmap_dig_bezier(
                hm,
                (nint)x,
                (nint)y,
                startRadius,
                startDepth,
                endRadius,
                endDepth
            );
    }

    public static void TCOD_heightmap_dig_bezier(
        nint hm,
        int[] px,
        int[] py,
        float startRadius,
        float startDepth,
        float endRadius,
        float endDepth
    )
    {
        TCOD_heightmap_dig_bezier(
            hm,
            px.AsSpan(),
            py.AsSpan(),
            startRadius,
            startDepth,
            endRadius,
            endDepth
        );
    }

    public static unsafe void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        ReadOnlySpan<int> dx,
        ReadOnlySpan<int> dy,
        ReadOnlySpan<float> weight,
        float minLevel,
        float maxLevel
    )
    {
        if (dx.Length < kernel_size)
            throw new TCODException(
                $"dx should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        if (dy.Length < kernel_size)
            throw new TCODException(
                $"dy should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        if (weight.Length < kernel_size)
            throw new TCODException(
                $"weight should contain at least {kernel_size} elements",
                TCOD_Error.TCOD_E_ERROR
            );
        fixed (int* x = dx)
        fixed (int* y = dy)
        fixed (float* w = weight)
            TCOD_heightmap_kernel_transform(
                hm,
                kernel_size,
                (nint)x,
                (nint)y,
                (nint)w,
                minLevel,
                maxLevel
            );
    }

    public static void TCOD_heightmap_kernel_transform(
        nint hm,
        int kernel_size,
        int[] dx,
        int[] dy,
        float[] weight,
        float minLevel,
        float maxLevel
    )
    {
        TCOD_heightmap_kernel_transform(
            hm,
            kernel_size,
            dx.AsSpan(),
            dy.AsSpan(),
            weight.AsSpan(),
            minLevel,
            maxLevel
        );
    }
}
