using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Return a new console loaded from a REXPaint .xp file.
        /// </summary>
        /// <param name="filename">A path to the REXPaint file.</param>
        /// <returns>A new TCOD_Console* object. New consoles will need to be deleted with a call to TCOD_console_delete. Returns NULL on an error.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Console* TCOD_console_from_xp([NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_from_xp
        public static TCOD_Console* TCOD_console_from_xp(
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_from_xp((sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        /// <summary>
        /// Update a console from a REXPaint .xp file.
        /// </summary>
        /// <param name="con">A console instance to update from the REXPaint file.</param>
        /// <param name="filename">A path to the REXPaint file.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_load_xp(TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_console_load_xp
        public static byte TCOD_console_load_xp(
            TCOD_Console* con,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_load_xp(con, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        /// <summary>
        /// Save a console as a REXPaint .xp file.
        /// </summary>
        /// <param name="con">The console instance to save.</param>
        /// <param name="filename">The filepath to save to.</param>
        /// <param name="compress_level">A zlib compression level, from 0 to 9. 1=fast, 6=balanced, 9=slowest, 0=uncompressed.</param>
        /// <returns>true when the file is saved successfully, or false when an issue is detected.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_console_save_xp([NativeTypeName("const TCOD_Console *")] TCOD_Console* con, [NativeTypeName("const char *")] sbyte* filename, int compress_level);
        // Managed wrapper for TCOD_console_save_xp
        public static byte TCOD_console_save_xp(
            [NativeTypeName("const TCOD_Console *")] TCOD_Console* con,
            string filename,
            int compress_level
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_console_save_xp(con, (sbyte*)filenamePtr.ToPointer(), compress_level);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }




        /// <summary>
        /// Load an array of consoles from a REXPaint file in memory.
        /// </summary>
        /// <param name="n_data">The length of the input data buffer.</param>
        /// <param name="data">The buffer where the REXPaint file is held.</param>
        /// <param name="n_out">The length of the output console out array. Can be zero.</param>
        /// <param name="out">The array to fill with loaded consoles.</param>
        /// <returns>Returns the number of consoles held by the file. Returns a negative error code on error.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_load_xp_from_memory(int n_data, [NativeTypeName("const unsigned char *")] byte* data, int n_out, TCOD_Console** @out);

        /// <summary>
        /// Save an array of consoles to a REXPaint file in memory.
        /// </summary>
        /// <param name="n_consoles">The length of the input consoles array.</param>
        /// <param name="consoles">An array of tcod consoles, can not be NULL.</param>
        /// <param name="n_out">The size of the out buffer, if this is zero then upper bound to be returned.</param>
        /// <param name="out">A pointer to an output buffer, can be NULL.</param>
        /// <param name="compression_level">A compression level for the zlib library.</param>
        /// <returns>If out=NULL then returns the upper bound of the buffer size needed. Otherwise this returns the number of bytes actually filled. On an error a negative error code is returned.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_save_xp_to_memory(int n_consoles, [NativeTypeName("const TCOD_Console *const *")] TCOD_Console** consoles, int n_out, [NativeTypeName("unsigned char *")] byte* @out, int compression_level);

        /// <summary>
        /// Load an array of consoles from a REXPaint file.
        /// </summary>
        /// <param name="path">The path to the REXPaint file, can not be NULL.</param>
        /// <param name="n">The size of the out array. Can be zero.</param>
        /// <param name="out">The array to fill with loaded consoles.</param>
        /// <returns>Returns the number of consoles held by the file. Returns a negative error code on error.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_load_xp([NativeTypeName("const char *")] sbyte* path, int n, TCOD_Console** @out);
        // Managed wrapper for TCOD_load_xp
        public static int TCOD_load_xp(
            string path,
            int n,
            TCOD_Console** @out
        )
        {
            var pathPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(path);
            try
            {
                return TCOD_load_xp((sbyte*)pathPtr.ToPointer(), n, @out);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pathPtr);
            }
        }


        /// <summary>
        /// Save an array of consoles to a REXPaint file.
        /// </summary>
        /// <param name="n">The number of consoles in the consoles array.</param>
        /// <param name="consoles">An array of consoles.</param>
        /// <param name="path">The path write the REXPaint file, can not be NULL.</param>
        /// <param name="compress_level">A compression level for the zlib library.</param>
        /// <returns>Returns an error code on failure.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_save_xp(int n, [NativeTypeName("const TCOD_Console *const *")] TCOD_Console** consoles, [NativeTypeName("const char *")] sbyte* path, int compress_level);
        // Managed wrapper for TCOD_save_xp
        public static TCOD_Error TCOD_save_xp(
            int n,
            [NativeTypeName("const TCOD_Console *const *")] TCOD_Console** consoles,
            string path,
            int compress_level
        )
        {
            var pathPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(path);
            try
            {
                return TCOD_save_xp(n, consoles, (sbyte*)pathPtr.ToPointer(), compress_level);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(pathPtr);
            }
        }

    }
}

