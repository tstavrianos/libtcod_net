using System;
using System.Runtime.InteropServices;
using System.Text;

namespace libtcod_net;

public sealed class PrintParamsScope : IDisposable
{
    private nint _fg;
    private nint _bg;
    private bool _disposed;

    public TCOD_PrintParamsRGB Value;

    public PrintParamsScope()
    {
        Value = new TCOD_PrintParamsRGB
        {
            flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
            alignment = TCOD_alignment_t.TCOD_LEFT,
        };
    }

    public void SetForeground(TCOD_ColorRGB? color)
    {
        ThrowIfDisposed();
        SetColorPointer(ref _fg, ref Value.fg, color);
    }

    public void SetBackground(TCOD_ColorRGB? color)
    {
        ThrowIfDisposed();
        SetColorPointer(ref _bg, ref Value.bg, color);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        FreeColorPointer(ref _fg, ref Value.fg);
        FreeColorPointer(ref _bg, ref Value.bg);
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    ~PrintParamsScope()
    {
        Dispose();
    }

    private static void SetColorPointer(
        ref nint storage,
        ref nint destination,
        TCOD_ColorRGB? color
    )
    {
        FreeColorPointer(ref storage, ref destination);

        if (color is null)
        {
            return;
        }

        storage = Marshal.AllocHGlobal(Marshal.SizeOf<TCOD_ColorRGB>());
        Marshal.StructureToPtr(color.Value, storage, false);
        destination = storage;
    }

    private static void FreeColorPointer(ref nint storage, ref nint destination)
    {
        if (storage == nint.Zero)
        {
            destination = nint.Zero;
            return;
        }

        Marshal.FreeHGlobal(storage);
        storage = nint.Zero;
        destination = nint.Zero;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(PrintParamsScope));
        }
    }
}

public static class PrintInteropHelpers
{
    public static PrintParamsScope CreatePrintParams(
        int x = 0,
        int y = 0,
        int width = 0,
        int height = 0,
        TCOD_ColorRGB? fg = null,
        TCOD_ColorRGB? bg = null,
        TCOD_bkgnd_flag_t flag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        TCOD_alignment_t alignment = TCOD_alignment_t.TCOD_LEFT
    )
    {
        var scope = new PrintParamsScope();
        scope.Value.x = x;
        scope.Value.y = y;
        scope.Value.width = width;
        scope.Value.height = height;
        scope.Value.flag = flag;
        scope.Value.alignment = alignment;
        scope.SetForeground(fg);
        scope.SetBackground(bg);
        return scope;
    }

    public static int PrintnRgb(nint console, in TCOD_PrintParamsRGB parameters, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return NativeMethods.TCOD_printn_rgb(
            console,
            parameters,
            Encoding.UTF8.GetByteCount(text),
            text
        );
    }

    public static int ConsolePrintn(
        nint console,
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

        using var scope = CreatePrintParams(
            x: x,
            y: y,
            fg: fg,
            bg: bg,
            flag: flag,
            alignment: alignment
        );
        return NativeMethods.TCOD_console_printn(
            console,
            x,
            y,
            (nuint)Encoding.UTF8.GetByteCount(text),
            text,
            scope.Value.fg,
            scope.Value.bg,
            flag,
            alignment
        );
    }

    public static int ConsolePrintnRect(
        nint console,
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

        using var scope = CreatePrintParams(
            x: x,
            y: y,
            width: width,
            height: height,
            fg: fg,
            bg: bg,
            flag: flag,
            alignment: alignment
        );
        return NativeMethods.TCOD_console_printn_rect(
            console,
            x,
            y,
            width,
            height,
            (nuint)Encoding.UTF8.GetByteCount(text),
            text,
            scope.Value.fg,
            scope.Value.bg,
            flag,
            alignment
        );
    }

    public static int GetHeightRect(nint console, int x, int y, int width, int height, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return NativeMethods.TCOD_console_get_height_rect_n(
            console,
            x,
            y,
            width,
            height,
            (nuint)Encoding.UTF8.GetByteCount(text),
            text
        );
    }

    public static int GetHeightRect(int width, string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        return NativeMethods.TCOD_console_get_height_rect_wn(
            width,
            (nuint)Encoding.UTF8.GetByteCount(text),
            text
        );
    }
}
