using System.Runtime.InteropServices;
using System.Text;

namespace libtcod.Interop;

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
            marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            if (fg.HasValue)
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            if (bg.HasValue)
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
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
            marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            if (fg.HasValue)
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            if (bg.HasValue)
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
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
            marshalFg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            marshalBg = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
            if (fg.HasValue)
                Marshal.StructureToPtr((object)fg.Value, marshalFg, false);
            if (bg.HasValue)
                Marshal.StructureToPtr((object)bg.Value, marshalBg, false);
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
}
