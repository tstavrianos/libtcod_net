using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

public static class ViewportInteropHelpers
{
    public static nint CreateViewport(in TCOD_ViewportOptions options)
    {
        var viewport = NativeMethods.TCOD_viewport_new();
        if (viewport == nint.Zero)
        {
            throw new InvalidOperationException("TCOD_viewport_new returned NULL.");
        }

        SetViewportOptions(viewport, in options);
        return viewport;
    }

    public static TCOD_ViewportOptions GetViewportOptions(nint viewport)
    {
        if (viewport == nint.Zero)
        {
            throw new ArgumentException("Viewport pointer must be non-null.", nameof(viewport));
        }

        return Marshal.PtrToStructure<TCOD_ViewportOptions>(viewport);
    }

    public static void SetViewportOptions(nint viewport, in TCOD_ViewportOptions options)
    {
        if (viewport == nint.Zero)
        {
            throw new ArgumentException("Viewport pointer must be non-null.", nameof(viewport));
        }

        Marshal.StructureToPtr(options, viewport, false);
    }

    public static void DeleteViewport(nint viewport)
    {
        if (viewport == nint.Zero)
        {
            return;
        }

        NativeMethods.TCOD_viewport_delete(viewport);
    }
}
