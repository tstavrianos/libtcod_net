using System.Runtime.InteropServices;
using System.Text;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_console_new(int w, int h);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_get_width(nint con);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_get_height(nint con);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_set_key_color(nint con, TCOD_ColorRGB col);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_blit(
        nint src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        nint dst,
        int xDst,
        int yDst,
        float foreground_alpha,
        float background_alpha
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_blit_key_color(
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
        nint key_color
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_delete(nint console);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_clear(nint con);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_ColorRGB TCOD_console_get_char_background(nint con, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_ColorRGB TCOD_console_get_char_foreground(nint con, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_get_char(nint con, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_put_rgb(
        nint console,
        int x,
        int y,
        int ch,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_draw_rect_rgb(
        nint console,
        int x,
        int y,
        int width,
        int height,
        int ch,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        nint decoration,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        [MarshalAs(UnmanagedType.I1)] bool clear
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_draw_frame_rgb(
        nint con,
        int x,
        int y,
        int width,
        int height,
        [In] int[] decoration,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        [MarshalAs(UnmanagedType.I1)] bool clear
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_console_set_color_control(
        TCOD_colctrl_t con,
        TCOD_ColorRGB fore,
        TCOD_ColorRGB back
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_printn(
        nint console,
        int x,
        int y,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_printn_rect(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str,
        nint fg,
        nint bg,
        TCOD_bkgnd_flag_t flag,
        TCOD_alignment_t alignment
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_get_height_rect_n(
        nint console,
        int x,
        int y,
        int width,
        int height,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_console_get_height_rect_wn(
        int width,
        nuint n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_printn_rgb(
        nint console,
        TCOD_PrintParamsRGB @params,
        int n,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_flush_ex(nint console, nint viewport);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_console_flush();

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_console_from_file(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_asc(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_apf(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_asc(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_apf(
        nint con,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_credits_render_ex(
        nint console,
        int x,
        int y,
        [MarshalAs(UnmanagedType.I1)] bool alpha,
        float delta_time
    );

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
}
