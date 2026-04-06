using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_LogLevel
    {
        TCOD_LOG_DEBUG = 10,
        TCOD_LOG_INFO = 20,
        TCOD_LOG_WARNING = 30,
        TCOD_LOG_ERROR = 40,
        TCOD_LOG_CRITICAL = 50,
    }

    public unsafe partial struct TCOD_LogMessage
    {
        [NativeTypeName("const char *")]
        public sbyte* message;

        public int level;

        [NativeTypeName("const char *")]
        public sbyte* source;

        public int lineno;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_set_log_level(int level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_set_log_callback([NativeTypeName("TCOD_LoggingCallback")] delegate* unmanaged[Cdecl]<TCOD_LogMessage*, void*, void> callback, void* userdata);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_log_verbose_([NativeTypeName("const char *")] sbyte* msg, int level, [NativeTypeName("const char *")] sbyte* source, int line);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_log_verbose_fmt_(int level, [NativeTypeName("const char *")] sbyte* source, int line, [NativeTypeName("const char *")] sbyte* fmt, __arglist);
    }
}

