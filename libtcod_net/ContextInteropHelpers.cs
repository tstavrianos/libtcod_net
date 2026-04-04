using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

public sealed class ContextParamsScope : IDisposable
{
    private nint _windowTitleUtf8;
    private bool _disposed;

    public TCOD_ContextParams Value;

    public ContextParamsScope()
    {
        Value = new TCOD_ContextParams { tcod_version = 0, vsync = 1 };
    }

    public void SetWindowTitle(string? title)
    {
        ThrowIfDisposed();
        FreeWindowTitle();

        _windowTitleUtf8 = title is null ? nint.Zero : Marshal.StringToCoTaskMemUTF8(title);
        Value.window_title = _windowTitleUtf8;
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        FreeWindowTitle();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    ~ContextParamsScope()
    {
        Dispose();
    }

    private void FreeWindowTitle()
    {
        if (_windowTitleUtf8 == nint.Zero)
        {
            return;
        }

        Marshal.FreeCoTaskMem(_windowTitleUtf8);
        _windowTitleUtf8 = nint.Zero;
        Value.window_title = nint.Zero;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(ContextParamsScope));
        }
    }
}

public static class ContextInteropHelpers
{
    public static ContextParamsScope CreateDefaultParams(
        int columns = 80,
        int rows = 50,
        string? windowTitle = null,
        int pixelWidth = 0,
        int pixelHeight = 0,
        nint tileset = default
    )
    {
        var scope = new ContextParamsScope();
        scope.Value.columns = columns;
        scope.Value.rows = rows;
        scope.Value.pixel_width = pixelWidth;
        scope.Value.pixel_height = pixelHeight;
        scope.Value.tileset = tileset;
        scope.SetWindowTitle(windowTitle);
        return scope;
    }

    public static int CreateContext(in TCOD_ContextParams parameters, out nint context)
    {
        return NativeMethods.TCOD_context_new(in parameters, out context);
    }
}
