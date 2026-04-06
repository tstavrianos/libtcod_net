using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Load a BDF font from a file path.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Tileset* TCOD_load_bdf([NativeTypeName("const char *")] sbyte* path);
        // Managed wrapper for TCOD_load_bdf
        public static TCOD_Tileset* TCOD_load_bdf(
            string path
        )
        {
            var pathPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(path);
            try
            {
                return TCOD_load_bdf((sbyte*)pathPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pathPtr);
            }
        }


        /// <summary>
        /// Load a BDF font from memory.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Tileset* TCOD_load_bdf_memory(int size, [NativeTypeName("const unsigned char *")] byte* buffer);
    }
}

