using System;
using System.Collections.Generic;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a console for rendering text and graphics.
/// </summary>
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

    /// <summary>
    /// Creates a new console with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the console.</param>
    /// <param name="height">The height of the console.</param>
    /// <returns>A new Console instance.</returns>
    public static Console Create(int width, int height)
    {
        var pointer = TCOD_console_new(width, height);
        ErrorHelper.CheckAndThrow(pointer);
        var console = new Console(pointer);
        return console;
    }

    /// <summary>
    /// Clears the console.
    /// </summary>
    public void Clear()
    {
        TCOD_console_clear(Pointer);
    }

    /// <summary>
    /// Gets the background color of the character at the specified position.
    /// </summary>
    /// <param name="x">The x-coordinate of the character.</param>
    /// <param name="y">The y-coordinate of the character.</param>
    /// <returns>The background color of the character.</returns>
    public TCOD_ColorRGB GetCharBackground(int x, int y)
    {
        return TCOD_console_get_char_background(Pointer, x, y);
    }

    /// <summary>
    /// Gets the foreground color of the character at the specified position.
    /// </summary>
    /// <param name="x">The x-coordinate of the character.</param>
    /// <param name="y">The y-coordinate of the character.</param>
    /// <returns>The foreground color of the character.</returns>
    public TCOD_ColorRGB GetCharForeground(int x, int y)
    {
        return TCOD_console_get_char_foreground(Pointer, x, y);
    }

    /// <summary>
    /// Gets the character at the specified position.
    /// </summary>
    /// <param name="x">The x-coordinate of the character.</param>
    /// <param name="y">The y-coordinate of the character.</param>
    /// <returns>The character at the specified position.</returns>
    public int GetChar(int x, int y)
    {
        return TCOD_console_get_char(Pointer, x, y);
    }

    /// <summary>
    /// Puts a character at the specified position with optional foreground and background colors.
    /// </summary>
    /// <param name="x">The x-coordinate of the character.</param>
    /// <param name="y">The y-coordinate of the character.</param>
    /// <param name="ch">The character to put.</param>
    /// <param name="fg">The foreground color of the character.</param>
    /// <param name="bg">The background color of the character.</param>
    /// <param name="flag">The background flag.</param>
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

    /// <summary>
    /// Draws a rectangle at the specified position with optional foreground and background colors.
    /// </summary>
    /// <param name="x">The x-coordinate of the rectangle.</param>
    /// <param name="y">The y-coordinate of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    /// <param name="ch">The character to use for the rectangle.</param>
    /// <param name="fg">The foreground color of the rectangle.</param>
    /// <param name="bg">The background color of the rectangle.</param>
    /// <param name="flag">The background flag.</param>
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

    /// <summary>
    /// Draws a frame at the specified position with optional decoration, foreground, and background colors.
    /// </summary>
    /// <param name="x">The x-coordinate of the frame.</param>
    /// <param name="y">The y-coordinate of the frame.</param>
    /// <param name="width">The width of the frame.</param>
    /// <param name="height">The height of the frame.</param>
    /// <param name="decoration">The decoration characters for the frame.</param>
    /// <param name="fg">The foreground color of the frame.</param>
    /// <param name="bg">The background color of the frame.</param>
    /// <param name="flag">The background flag.</param>
    /// <param name="clear">Whether to clear the area inside the frame.</param>
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

    /// <summary>
    /// Prints text at the specified position with optional foreground and background colors, background flag, and alignment.
    /// </summary>
    /// <param name="x">The x-coordinate of the text.</param>
    /// <param name="y">The y-coordinate of the text.</param>
    /// <param name="text">The text to print.</param>
    /// <param name="fg">The foreground color of the text.</param>
    /// <param name="bg">The background color of the text.</param>
    /// <param name="flag">The background flag.</param>
    /// <param name="alignment">The text alignment.</param>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Prints text within a rectangular area with optional foreground and background colors, background flag, and alignment.
    /// </summary>
    /// <param name="x">The x-coordinate of the rectangle.</param>
    /// <param name="y">The y-coordinate of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    /// <param name="text">The text to print within the rectangle.</param>
    /// <param name="fg">The foreground color of the text.</param>
    /// <param name="bg">The background color of the text.</param>
    /// <param name="flag">The background flag.</param>
    /// <param name="alignment">The text alignment.</param>
    /// <returns>The number of lines printed.</returns>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Gets the height of the text within a rectangular area.
    /// </summary>
    /// <param name="x">The x-coordinate of the rectangle.</param>
    /// <param name="y">The y-coordinate of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    /// <param name="text">The text to measure.</param>
    /// <returns>The height of the text within the rectangle.</returns>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Flushes the console to the specified viewport.
    /// </summary>
    /// <param name="viewport">The viewport to flush the console to.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Flush(Viewport viewport)
    {
        ArgumentNullException.ThrowIfNull(viewport);
        var ret = TCOD_console_flush_ex(Pointer, viewport.Pointer);
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// Sets the key color for the console.
    /// </summary>
    /// <param name="color">The key color to set.</param>
    public void SetKeyColor(TCOD_ColorRGB color)
    {
        TCOD_console_set_key_color(Pointer, color);
    }

    /// <summary>
    /// Blits a portion of the source console to the destination console.
    /// </summary>
    /// <param name="src">The source console.</param>
    /// <param name="xSrc">The x-coordinate of the source rectangle.</param>
    /// <param name="ySrc">The y-coordinate of the source rectangle.</param>
    /// <param name="wSrc">The width of the source rectangle.</param>
    /// <param name="hSrc">The height of the source rectangle.</param>
    /// <param name="dst">The destination console.</param>
    /// <param name="xDst">The x-coordinate of the destination rectangle.</param>
    /// <param name="yDst">The y-coordinate of the destination rectangle.</param>
    /// <param name="foregroundAlpha">The alpha value for the foreground.</param>
    /// <param name="backgroundAlpha">The alpha value for the background.</param>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Blits a portion of the source console to the destination console with a key color.
    /// </summary>
    /// <param name="src">The source console.</param>
    /// <param name="xSrc">The x-coordinate of the source rectangle.</param>
    /// <param name="ySrc">The y-coordinate of the source rectangle.</param>
    /// <param name="wSrc">The width of the source rectangle.</param>
    /// <param name="hSrc">The height of the source rectangle.</param>
    /// <param name="dst">The destination console.</param>
    /// <param name="xDst">The x-coordinate of the destination rectangle.</param>
    /// <param name="yDst">The y-coordinate of the destination rectangle.</param>
    /// <param name="foregroundAlpha">The alpha value for the foreground.</param>
    /// <param name="backgroundAlpha">The alpha value for the background.</param>
    /// <param name="keyColor">The key color to use for transparency.</param>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Loads a console from a file. The file can be in either XP, ASC or APF format, depending on the file extension.
    /// </summary>
    /// <param name="filename">The path to the file.</param>
    /// <returns>The loaded console.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public static Console LoadFromFile(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_console_from_xp(filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
        return new Console(ret);
    }

    /// <summary>
    /// Updates the console from an XP file.
    /// </summary>
    /// <param name="filename">The path to the XP file.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TryUpdateFromXp(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_xp(Pointer, filenamePtr.CStr);
    }

    /// <summary>
    /// Updates the console from an APF file.
    /// </summary>
    /// <param name="filename">The path to the APF file.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TryUpdateFromApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_apf(Pointer, filenamePtr.CStr);
    }

    /// <summary>
    /// Updates the console from an ASC file.
    /// </summary>
    /// <param name="filename">The path to the ASC file.</param>
    /// <returns>True if the update was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TryUpdateFromAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_load_asc(Pointer, filenamePtr.CStr);
    }

    /// <summary>
    /// Saves the console to an XP file.
    /// </summary>
    /// <param name="filename">The path to the XP file.</param>
    /// <param name="compressionLevel">The compression level to use.</param>
    /// <returns>True if the save was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TrySaveToXp(string filename, int compressionLevel)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_xp(Pointer, filenamePtr.CStr, compressionLevel);
    }

    /// <summary>
    /// Saves the console to an ASC file.
    /// </summary>
    /// <param name="filename">The path to the ASC file.</param>
    /// <returns>True if the save was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TrySaveToAsc(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_asc(Pointer, filenamePtr.CStr);
    }

    /// <summary>
    /// Saves the console to an APF file.
    /// </summary>
    /// <param name="filename">The path to the APF file.</param>
    /// <returns>True if the save was successful; otherwise, false.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public bool TrySaveToApf(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        return TCOD_console_save_apf(Pointer, filenamePtr.CStr);
    }

    /// <summary>
    /// Loads consoles from an XP file.
    /// </summary>
    /// <param name="filename">The path to the XP file.</param>
    /// <returns>A read-only list of consoles loaded from the XP file.</returns>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    /// <exception cref="TCODException">Thrown if there is an error loading the XP file.</exception>
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

    /// <summary>
    /// Saves multiple consoles to an XP file.
    /// </summary>
    /// <param name="filename">The path to the XP file.</param>
    /// <param name="compressionLevel">The compression level to use.</param>
    /// <param name="consoles">The list of consoles to save.</param>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown if the consoles list is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the consoles list is empty.</exception>
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
