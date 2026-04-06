using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_Error
    {
        TCOD_E_OK = 0,
        TCOD_E_ERROR = -1,
        TCOD_E_INVALID_ARGUMENT = -2,
        TCOD_E_OUT_OF_MEMORY = -3,
        TCOD_E_REQUIRES_ATTENTION = -4,
        TCOD_E_WARN = 1,
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_get_error();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_set_error([NativeTypeName("const char *")] sbyte* msg);

        /// <summary>
        /// Set an error message and return TCOD_E_ERROR.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_set_errorf([NativeTypeName("const char *")] sbyte* fmt, __arglist);

        /// <summary>
        /// Clear a current existing error message.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_clear_error();
    }
}

