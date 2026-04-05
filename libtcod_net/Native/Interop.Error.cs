using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(
        NativeLib,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true,
        EntryPoint = "TCOD_get_error"
    )]
    private static extern nint TCOD_get_error_();

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern TCOD_Error TCOD_set_error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_clear_error();

    public static string TCOD_get_error()
    {
        var ptr = TCOD_get_error_();
        return ptr == nint.Zero ? string.Empty : Marshal.PtrToStringUTF8(ptr) ?? string.Empty;
    }
}
