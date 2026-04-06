using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_new();

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_new_with_size(int x, int y, int w, int h);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_bsp_delete(nint node);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_left(nint node);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_right(nint node);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_father(nint node);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_is_leaf(nint node);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_pre_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_in_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_post_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_traverse_inverted_level_order(
        nint node,
        TCOD_bsp_callback_t listener,
        nint userData
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_bsp_contains(nint node, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_bsp_find_node(nint node, int x, int y);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_bsp_resize(nint node, int x, int y, int w, int h);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_bsp_split_once(
        nint node,
        [MarshalAs(UnmanagedType.I1)] bool horizontal,
        int position
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_bsp_split_recursive(
        nint node,
        nint randomizer,
        int nb,
        int minHSize,
        int minVSize,
        float maxHRatio,
        float maxVRatio
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_bsp_remove_sons(nint node);
}
