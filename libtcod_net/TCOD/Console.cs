using System;
using System.Collections.Generic;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class Console : TCODResource<TCOD_Console>
{
    public int Width { get; }
    public int Height { get; }

    private Console(TCOD_Console* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Console with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        Width = TCOD_console_get_width(pointer);
        Height = TCOD_console_get_height(pointer);
    }

    public static Console Create(int width, int height)
    {
        var pointer = TCOD_console_new(width, height);
        ErrorHelper.CheckAndThrow(pointer);
        var console = new Console(pointer);
        return console;
    }

    public void Clear()
    {
        TCOD_console_clear(Pointer);
    }

    public TCOD_ColorRGB GetCharBackground(int x, int y)
    {
        return TCOD_console_get_char_background(Pointer, x, y);
    }

    public TCOD_ColorRGB GetCharForeground(int x, int y)
    {
        return TCOD_console_get_char_foreground(Pointer, x, y);
    }

    public int GetChar(int x, int y)
    {
        return TCOD_console_get_char(Pointer, x, y);
    }

    public void Put(
        int x,
        int y,
        int ch,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        var fgValue = fg.HasValue ? fg.Value : default;
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fgValue : null;
        var bgValue = bg.HasValue ? bg.Value : default;
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bgValue : null;
        TCOD_console_put_rgb(Pointer, x, y, ch, fgPtr, bgPtr, flag);
    }

    public void DrawRect(
        int x,
        int y,
        int width,
        int height,
        int ch,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        var fgValue = fg.HasValue ? fg.Value : default;
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fgValue : null;
        var bgValue = bg.HasValue ? bg.Value : default;
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bgValue : null;
        var ret = TCOD_console_draw_rect_rgb(Pointer, x, y, width, height, ch, fgPtr, bgPtr, flag);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void DrawFrame(
        int x,
        int y,
        int width,
        int height,
        int[]? decoration = null,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        bool clear = true
    )
    {
        var fgValue = fg.HasValue ? fg.Value : default;
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fgValue : null;
        var bgValue = bg.HasValue ? bg.Value : default;
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bgValue : null;
        TCOD_Error ret;
        if (decoration is not null && decoration.Length > 0)
            fixed (int* d = &decoration[0])
                ret = TCOD_console_draw_frame_rgb(
                    Pointer,
                    x,
                    y,
                    width,
                    height,
                    d,
                    fgPtr,
                    bgPtr,
                    flag,
                    clear
                );
        else
            ret = TCOD_console_draw_frame_rgb(
                Pointer,
                x,
                y,
                width,
                height,
                null,
                fgPtr,
                bgPtr,
                flag,
                clear
            );

        ErrorHelper.CheckAndThrow(ret);
    }

    public void Print(
        int x,
        int y,
        string text,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        TCOD_alignment_t alignment = TCOD_alignment_t.TCOD_LEFT
    )
    {
        ArgumentNullException.ThrowIfNull(text);
        var fgValue = fg.HasValue ? fg.Value : default;
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fgValue : null;
        var bgValue = bg.HasValue ? bg.Value : default;
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bgValue : null;
        using var textPtr = new StringMarshal(text);
        var ret = TCOD_console_printn(
            Pointer,
            x,
            y,
            (ulong)textPtr.Length,
            textPtr.CStr,
            fgPtr,
            bgPtr,
            flag,
            alignment
        );
        ErrorHelper.CheckAndThrow(ret);
    }

    public int PrintRect(
        int x,
        int y,
        int width,
        int height,
        string text,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        TCOD_alignment_t alignment = TCOD_alignment_t.TCOD_LEFT
    )
    {
        ArgumentNullException.ThrowIfNull(text);
        var fgValue = fg.HasValue ? fg.Value : default;
        TCOD_ColorRGB* fgPtr = fg.HasValue ? &fgValue : null;
        var bgValue = bg.HasValue ? bg.Value : default;
        TCOD_ColorRGB* bgPtr = bg.HasValue ? &bgValue : null;
        using var textPtr = new StringMarshal(text);
        var ret = TCOD_console_printn_rect(
            Pointer,
            x,
            y,
            width,
            height,
            (ulong)textPtr.Length,
            textPtr.CStr,
            fgPtr,
            bgPtr,
            flag,
            alignment
        );
        ErrorHelper.CheckAndThrow(ret);

        return ret;
    }

    public int GetHeightRect(int x, int y, int width, int height, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        using var textPtr = new StringMarshal(text);
        var ret = TCOD_console_get_height_rect_n(
            Pointer,
            x,
            y,
            width,
            height,
            (ulong)textPtr.Length,
            textPtr.CStr
        );
        ErrorHelper.CheckAndThrow(ret);

        return ret;
    }

    public void Flush(Viewport viewport)
    {
        ArgumentNullException.ThrowIfNull(viewport);
        var ret = TCOD_console_flush_ex(Pointer, viewport.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void SetKeyColor(TCOD_ColorRGB color)
    {
        TCOD_console_set_key_color(Pointer, color);
    }

    public static void Blit(
        Console src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        Console dst,
        int xDst,
        int yDst,
        float foregroundAlpha,
        float backgroundAlpha
    )
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        TCOD_console_blit(
            src.Pointer,
            xSrc,
            ySrc,
            wSrc,
            hSrc,
            dst.Pointer,
            xDst,
            yDst,
            foregroundAlpha,
            backgroundAlpha
        );
    }

    public static void Blit(
        Console src,
        int xSrc,
        int ySrc,
        int wSrc,
        int hSrc,
        Console dst,
        int xDst,
        int yDst,
        float foregroundAlpha,
        float backgroundAlpha,
        TCOD_ColorRGB keyColor
    )
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        TCOD_console_blit_key_color(
            src.Pointer,
            xSrc,
            ySrc,
            wSrc,
            hSrc,
            dst.Pointer,
            xDst,
            yDst,
            foregroundAlpha,
            backgroundAlpha,
            &keyColor
        );
    }

    public static Console LoadFromFile(string filename, bool xp = false)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        TCOD_Console* ret;
        using var filenamePtr = new StringMarshal(filename);
        if (xp)
            ret = TCOD_console_from_xp(filenamePtr.CStr);
        else
            ret = TCOD_console_from_file(filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
        return new Console(ret);
    }

    public bool TryUpdateFromXp(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_xp(Pointer, filenamePtr.CStr);
    }

    public bool TryUpdateFromApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_apf(Pointer, filenamePtr.CStr);
    }

    public bool TryUpdateFromAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_asc(Pointer, filenamePtr.CStr);
    }

    public bool TrySaveToXp(string filename, int compressionLevel)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_xp(Pointer, filenamePtr.CStr, compressionLevel);
    }

    public bool TrySaveToAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_asc(Pointer, filenamePtr.CStr);
    }

    public bool TrySaveToApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_apf(Pointer, filenamePtr.CStr);
    }

    public static IReadOnlyList<Console> LoadConsolesFromXp(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_load_xp(filenamePtr.CStr, 0, null);
        if (ret <= 0)
        {
            var message = TCOD_get_error();
            string messageStr = CString.ToString(message);
            throw new TCODException(messageStr, TCOD_Error.TCOD_E_ERROR);
        }

        var arr = new TCOD_Console*[ret];
        fixed (TCOD_Console** a = &arr[0])
        {
            var ret2 = TCOD_load_xp(filenamePtr.CStr, ret, a);

            if (ret2 <= 0 || ret2 != ret)
            {
                var message = TCOD_get_error();
                string messageStr = CString.ToString(message);
                throw new TCODException(messageStr, TCOD_Error.TCOD_E_ERROR);
            }
        }

        var r = new Console[arr.Length];
        for (var i = 0; i < r.Length; i++)
        {
            r[i] = new Console(arr[i]);
        }

        return r;
    }

    public static void SaveConsolesToXp(
        string filename,
        int compressionLevel,
        IReadOnlyList<Console> consoles
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        ArgumentNullException.ThrowIfNull(consoles);
        ArgumentOutOfRangeException.ThrowIfZero(consoles.Count);
        var arr = new TCOD_Console*[consoles.Count];
        for (var i = 0; i < arr.Length; i++)
            arr[i] = consoles[i].Pointer;
        using var filenamePtr = new StringMarshal(filename);
        fixed (TCOD_Console** a = &arr[0])
        {
            var ret = TCOD_save_xp(arr.Length, a, filenamePtr.CStr, compressionLevel);
            ErrorHelper.CheckAndThrow(ret);
        }
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_console_delete(Pointer);
    }
}
