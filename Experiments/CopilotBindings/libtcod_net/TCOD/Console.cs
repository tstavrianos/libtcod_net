using System;
using System.Collections.Generic;
using System.Linq;

namespace libtcod_net.TCOD;

public sealed class Console : TCODResource
{
    public int Width { get; }
    public int Height { get; }

    private Console(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Console with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        Width = libtcod.TCOD_console_get_width(pointer);
        Height = libtcod.TCOD_console_get_height(pointer);
    }

    public static Console Create(int width, int height)
    {
        var pointer = libtcod.TCOD_console_new(width, height);
        ErrorHelper.CheckAndThrow(pointer);
        var console = new Console(pointer);
        return console;
    }

    public void Clear()
    {
        libtcod.TCOD_console_clear(Pointer);
    }

    public libtcod.TCOD_ColorRGB GetCharBackground(int x, int y)
    {
        return libtcod.TCOD_console_get_char_background(Pointer, x, y);
    }

    public libtcod.TCOD_ColorRGB GetCharForeground(int x, int y)
    {
        return libtcod.TCOD_console_get_char_foreground(Pointer, x, y);
    }

    public int GetChar(int x, int y)
    {
        return libtcod.TCOD_console_get_char(Pointer, x, y);
    }

    public void Put(
        int x,
        int y,
        int ch,
        libtcod.TCOD_ColorRGB? fg = null,
        libtcod.TCOD_ColorRGB? bg = null,
        libtcod.TCOD_bkgnd_flag_t flag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        libtcod.TCOD_console_put_rgb(Pointer, x, y, ch, fg, bg, flag);
    }

    public void DrawRect(
        int x,
        int y,
        int width,
        int height,
        int ch,
        libtcod.TCOD_ColorRGB? fg = null,
        libtcod.TCOD_ColorRGB? bg = null,
        libtcod.TCOD_bkgnd_flag_t flag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        var ret = libtcod.TCOD_console_draw_rect_rgb(
            Pointer,
            x,
            y,
            width,
            height,
            ch,
            fg,
            bg,
            flag
        );
        ErrorHelper.CheckAndThrow(ret);
    }

    public void DrawFrame(
        int x,
        int y,
        int width,
        int height,
        int[]? decoration = null,
        libtcod.TCOD_ColorRGB? fg = null,
        libtcod.TCOD_ColorRGB? bg = null,
        libtcod.TCOD_bkgnd_flag_t flag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        bool clear = true
    )
    {
        libtcod.TCOD_Error ret;
        if (decoration is not null)
            ret = libtcod.TCOD_console_draw_frame_rgb(
                Pointer,
                x,
                y,
                width,
                height,
                decoration,
                fg,
                bg,
                flag,
                clear
            );
        else
            ret = libtcod.TCOD_console_draw_frame_rgb(
                Pointer,
                x,
                y,
                width,
                height,
                nint.Zero,
                fg,
                bg,
                flag,
                clear
            );

        ErrorHelper.CheckAndThrow(ret);
    }

    public void Print(
        int x,
        int y,
        string text,
        libtcod.TCOD_ColorRGB? fg = null,
        libtcod.TCOD_ColorRGB? bg = null,
        libtcod.TCOD_bkgnd_flag_t flag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        libtcod.TCOD_alignment_t alignment = libtcod.TCOD_alignment_t.TCOD_LEFT
    )
    {
        ArgumentNullException.ThrowIfNull(text);
        var ret = libtcod.TCOD_console_printn(Pointer, x, y, text, fg, bg, flag, alignment);
        ErrorHelper.CheckAndThrow(ret);
    }

    public int PrintRect(
        int x,
        int y,
        int width,
        int height,
        string text,
        libtcod.TCOD_ColorRGB? fg = null,
        libtcod.TCOD_ColorRGB? bg = null,
        libtcod.TCOD_bkgnd_flag_t flag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        libtcod.TCOD_alignment_t alignment = libtcod.TCOD_alignment_t.TCOD_LEFT
    )
    {
        ArgumentNullException.ThrowIfNull(text);
        var ret = libtcod.TCOD_console_printn_rect(
            Pointer,
            x,
            y,
            width,
            height,
            text,
            fg,
            bg,
            flag,
            alignment
        );
        ErrorHelper.CheckAndThrow(ret);

        return ret;
    }

    public int GetHeightRect(int x, int y, int width, int height, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        var ret = libtcod.TCOD_console_get_height_rect_n(Pointer, x, y, width, height, text);
        ErrorHelper.CheckAndThrow(ret);

        return ret;
    }

    public void Flush(Viewport viewport)
    {
        ArgumentNullException.ThrowIfNull(viewport);
        var ret = libtcod.TCOD_console_flush_ex(Pointer, viewport.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void SetKeyColor(libtcod.TCOD_ColorRGB color)
    {
        libtcod.TCOD_console_set_key_color(Pointer, color);
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
        libtcod.TCOD_console_blit(
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
        libtcod.TCOD_ColorRGB keyColor
    )
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        libtcod.TCOD_console_blit_key_color(
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
            keyColor
        );
    }

    public static Console LoadFromFile(string filename, bool xp = false)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        nint ret;
        if (xp)
            ret = libtcod.TCOD_console_from_xp(filename);
        else
            ret = libtcod.TCOD_console_from_file(filename);
        ErrorHelper.CheckAndThrow(ret);
        return new Console(ret);
    }

    public bool TryUpdateFromXp(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        return libtcod.TCOD_console_load_xp(Pointer, filename);
    }

    public bool TryUpdateFromApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        return libtcod.TCOD_console_load_apf(Pointer, filename);
    }

    public bool TryUpdateFromAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        return libtcod.TCOD_console_load_asc(Pointer, filename);
    }

    public bool TrySaveToXp(string filename, int compressionLevel)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_console_save_xp(Pointer, filename, compressionLevel);
        return ret;
    }

    public bool TrySaveToAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        return libtcod.TCOD_console_save_asc(Pointer, filename);
    }

    public bool TrySaveToApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        return libtcod.TCOD_console_save_apf(Pointer, filename);
    }

    public static Console[] LoadConsolesFromXp(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_load_xp(filename, 0, nint.Zero);
        if (ret <= 0)
        {
            var message = libtcod.TCOD_get_error();
            throw new TCODException(message, libtcod.TCOD_Error.TCOD_E_ERROR);
        }

        var arr = new nint[ret];
        var ret2 = libtcod.TCOD_load_xp(filename, ret, arr);
        if (ret2 <= 0 || ret2 != ret)
        {
            var message = libtcod.TCOD_get_error();
            throw new TCODException(message, libtcod.TCOD_Error.TCOD_E_ERROR);
        }

        return arr.Select(x => new Console(x)).ToArray();
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
        var arr = consoles.Select(x => x.Pointer).ToArray();
        var ret = libtcod.TCOD_save_xp(arr.Length, arr, filename, compressionLevel);
        ErrorHelper.CheckAndThrow(ret);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_console_delete(Pointer);
    }
}
