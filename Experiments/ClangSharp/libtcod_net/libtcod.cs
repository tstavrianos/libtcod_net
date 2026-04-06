#if false
using System.Runtime.InteropServices;
using System.Text;

namespace libtcod_net;

public static unsafe partial class libtcod
{
    public static int TCOD_printn_rgb(
        TCOD_Console* console,
        TCOD_PrintParamsRGB @params,
        string str
    )
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(str);
        try
        {
            return TCOD_printn_rgb(
                console,
                @params,
                Encoding.UTF8.GetByteCount(str),
                (sbyte*)strPtr.ToPointer()
            );
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static void TCOD_console_put_rgb(
        TCOD_Console* console,
        int x,
        int y,
        int ch,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag
    )
    {
        var fg_ = fg.GetValueOrDefault();
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fg_ : null;
        var bg_ = bg.GetValueOrDefault();
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bg_ : null;
        TCOD_console_put_rgb(console, x, y, ch, fgPtr, bgPtr, flag);
    }

    public static int TCOD_console_printn_rect(
        TCOD_Console* console,
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
        var fg_ = fg.GetValueOrDefault();
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fg_ : null;
        var bg_ = bg.GetValueOrDefault();
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bg_ : null;
        var strPtr = Marshal.StringToCoTaskMemUTF8(str);
        try
        {
            return TCOD_console_printn_rect(
                console,
                x,
                y,
                width,
                height,
                (nuint)Encoding.UTF8.GetByteCount(str),
                (sbyte*)strPtr.ToPointer(),
                fgPtr,
                bgPtr,
                flag,
                alignment
            );
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static TCOD_Error TCOD_console_draw_rect_rgb(
        TCOD_Console* console,
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
        var fg_ = fg.GetValueOrDefault();
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fg_ : null;
        var bg_ = bg.GetValueOrDefault();
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bg_ : null;
        return TCOD_console_draw_rect_rgb(console, x, y, width, height, ch, fgPtr, bgPtr, flag);
    }

    public static TCOD_Error TCOD_console_draw_frame_rgb(
        TCOD_Console* con,
        int x,
        int y,
        int width,
        int height,
        int* decoration,
        TCOD_ColorRGB? fg,
        TCOD_ColorRGB? bg,
        TCOD_bkgnd_flag_t flag,
        byte clear
    )
    {
        var fg_ = fg.GetValueOrDefault();
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fg_ : null;
        var bg_ = bg.GetValueOrDefault();
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bg_ : null;
        return TCOD_console_draw_frame_rgb(
            con,
            x,
            y,
            width,
            height,
            decoration,
            fgPtr,
            bgPtr,
            flag,
            clear
        );
    }

    public static TCOD_Image* TCOD_image_load(string filename)
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(filename);
        try
        {
            return TCOD_image_load((sbyte*)strPtr.ToPointer());
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static int TCOD_load_xp(string path, int n, TCOD_Console** @out)
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(path);
        try
        {
            return TCOD_load_xp((sbyte*)strPtr.ToPointer(), n, @out);
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static TCOD_Error TCOD_save_xp(
        int n,
        TCOD_Console** consoles,
        string path,
        int compress_level
    )
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(path);
        try
        {
            return TCOD_save_xp(n, consoles, (sbyte*)strPtr.ToPointer(), compress_level);
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static TCOD_Tileset* TCOD_tileset_load(
        string filename,
        int columns,
        int rows,
        int n,
        int* charmap
    )
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(filename);
        try
        {
            return TCOD_tileset_load((sbyte*)strPtr.ToPointer(), columns, rows, n, charmap);
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }

    public static TCOD_Tileset* TCOD_load_bdf(string path)
    {
        var strPtr = Marshal.StringToCoTaskMemUTF8(path);
        try
        {
            return TCOD_load_bdf((sbyte*)strPtr.ToPointer());
        }
        finally
        {
            Marshal.FreeCoTaskMem(strPtr);
        }
    }
}
#endif
