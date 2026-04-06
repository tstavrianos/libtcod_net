using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_Zip
    {
    }

    public static unsafe partial class libtcod
    {

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_delete([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_char([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("char")] sbyte val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_int([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, int val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_float([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, float val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_string([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const char *")] sbyte* val);
        // Managed wrapper for TCOD_zip_put_string
        public static void TCOD_zip_put_string(
            [NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip,
            string val
        )
        {
            var valPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(val);
            try
            {
                TCOD_zip_put_string(zip, (sbyte*)valPtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(valPtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_color([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const TCOD_color_t")] TCOD_ColorRGB val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_image([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const TCOD_Image *")] TCOD_Image* val);


        /// <summary>
        /// Write a TCOD_Random* object.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_random([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const TCOD_Random *")] TCOD_Random* val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_put_data([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, int nbBytes, [NativeTypeName("const void *")] void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint TCOD_zip_get_current_bytes([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_zip_save_to_file([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_zip_save_to_file
        public static int TCOD_zip_save_to_file(
            [NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_zip_save_to_file(zip, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_zip_load_from_file([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_zip_load_from_file
        public static int TCOD_zip_load_from_file(
            [NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_zip_load_from_file(zip, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char")]
        public static extern sbyte TCOD_zip_get_char([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_zip_get_int([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_zip_get_float([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_zip_get_string([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_zip_get_color([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Image* TCOD_zip_get_image([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_console_t")]
        public static extern TCOD_Console* TCOD_zip_get_console([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        /// <summary>
        /// Read a TCOD_Random* object.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Random* TCOD_zip_get_random([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_zip_get_data([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, int nbBytes, void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint TCOD_zip_get_remaining_bytes([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_zip_skip_bytes([NativeTypeName("TCOD_zip_t")] TCOD_Zip* zip, [NativeTypeName("uint32_t")] uint nbBytes);
    }
}

