using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern nint TCOD_console_from_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_load_xp(
        nint console,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool TCOD_console_save_xp(
        nint console,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        int compress_level
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_load_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int n,
        [Out] nint[] @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_load_xp(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int n,
        nint @out
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_save_xp(
        int n,
        [In] nint[] consoles,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int compress_level
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_save_xp(
        int n,
        nint consoles,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path,
        int compress_level
    );
}
