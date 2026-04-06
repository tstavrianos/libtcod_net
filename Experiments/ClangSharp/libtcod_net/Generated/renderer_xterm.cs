using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Context* TCOD_renderer_init_xterm(int window_x, int window_y, int pixel_width, int pixel_height, int columns, int rows, [NativeTypeName("const char *")] sbyte* window_title);
        // Managed wrapper for TCOD_renderer_init_xterm
        public static TCOD_Context* TCOD_renderer_init_xterm(
            int window_x,
            int window_y,
            int pixel_width,
            int pixel_height,
            int columns,
            int rows,
            string window_title
        )
        {
            var window_titlePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(window_title);
            try
            {
                return TCOD_renderer_init_xterm(window_x, window_y, pixel_width, pixel_height, columns, rows, (sbyte*)window_titlePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(window_titlePtr);
            }
        }

    }
}

