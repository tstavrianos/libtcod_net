using System;
using System.Runtime.InteropServices;

namespace libtcod.Interop;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_ViewportOptions
    {
        public int tcod_version;

        [MarshalAs(UnmanagedType.I1)]
        public bool keep_aspect;

        [MarshalAs(UnmanagedType.I1)]
        public bool integer_scaling;
        public TCOD_ColorRGBA clear_color;
        public float align_x;
        public float align_y;

        public void ApplyToPointer(nint viewport)
        {
            if (viewport == nint.Zero)
            {
                throw new InvalidOperationException("viewport is NULL.");
            }
            Marshal.StructureToPtr(this, viewport, false);
        }

        public static TCOD_ViewportOptions RetrieveFromPointer(nint viewport)
        {
            if (viewport == nint.Zero)
            {
                throw new InvalidOperationException("viewport is NULL.");
            }
            return Marshal.PtrToStructure<TCOD_ViewportOptions>(viewport);
        }
    }
}
