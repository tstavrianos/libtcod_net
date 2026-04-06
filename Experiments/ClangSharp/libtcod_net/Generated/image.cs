using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_mipmap_
    {
        public int width;

        public int height;

        public float fwidth;

        public float fheight;

        public TCOD_ColorRGB* buf;

        [NativeTypeName("_Bool")]
        public byte dirty;
    }

    public unsafe partial struct TCOD_Image
    {
        public int nb_mipmaps;

        [NativeTypeName("struct TCOD_mipmap_ *restrict")]
        public TCOD_mipmap_* mipmaps;

        public TCOD_ColorRGB key_color;

        [NativeTypeName("_Bool")]
        public byte has_key_color;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Image* TCOD_image_new(int width, int height);

        /// <summary>
        /// Return a new image rendered from a console.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Image* TCOD_image_from_console([NativeTypeName("const TCOD_Console *")] TCOD_Console* console);

        /// <summary>
        /// Same as TCOD_image_from_console, but with an existing image.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_refresh_console(TCOD_Image* image, [NativeTypeName("const TCOD_Console *")] TCOD_Console* console);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_clear(TCOD_Image* image, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_invert(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_hflip(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_rotate90(TCOD_Image* image, int numRotations);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_vflip(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_scale(TCOD_Image* image, int new_w, int new_h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Image* TCOD_image_load([NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_image_load
        public static TCOD_Image* TCOD_image_load(
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_image_load((sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        /// <summary>
        /// Save an image to a PNG or BMP file.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_image_save([NativeTypeName("const TCOD_Image *")] TCOD_Image* image, [NativeTypeName("const char *")] sbyte* filename);
        // Managed wrapper for TCOD_image_save
        public static TCOD_Error TCOD_image_save(
            [NativeTypeName("const TCOD_Image *")] TCOD_Image* image,
            string filename
        )
        {
            var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
            try
            {
                return TCOD_image_save(image, (sbyte*)filenamePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_get_size([NativeTypeName("const TCOD_Image *")] TCOD_Image* image, int* w, int* h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_image_get_pixel([NativeTypeName("const TCOD_Image *")] TCOD_Image* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_image_get_alpha([NativeTypeName("const TCOD_Image *")] TCOD_Image* image, int x, int y);

        /// <summary>
        /// Return a mipmapped pixel of image.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_image_get_mipmap_pixel(TCOD_Image* image, float x0, float y0, float x1, float y1);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_put_pixel(TCOD_Image* image, int x, int y, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_blit(TCOD_Image* image, [NativeTypeName("TCOD_console_t")] TCOD_Console* console, float x, float y, TCOD_bkgnd_flag_t bkgnd_flag, float scale_x, float scale_y, float angle);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_blit_rect(TCOD_Image* image, [NativeTypeName("TCOD_console_t")] TCOD_Console* console, int x, int y, int w, int h, TCOD_bkgnd_flag_t bkgnd_flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_blit_2x([NativeTypeName("const TCOD_Image *restrict")] TCOD_Image* image, TCOD_Console* dest, int dx, int dy, int sx, int sy, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_delete(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_image_set_key_color(TCOD_Image* image, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB key_color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_image_is_pixel_transparent([NativeTypeName("const TCOD_Image *")] TCOD_Image* image, int x, int y);
    }
}

