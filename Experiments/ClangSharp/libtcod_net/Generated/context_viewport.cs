using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    /// <summary>
    /// Viewport options for the rendering context.
    /// </summary>
    public partial struct TCOD_ViewportOptions
    {
        /// Must be set to TCOD_COMPILEDVERSION.
        public int tcod_version;

        /// If true then the aspect ratio will be kept square when the console is scaled.
        [NativeTypeName("_Bool")]
        public byte keep_aspect;

        /// If true then console scaling will be fixed to integer increments.
        [NativeTypeName("_Bool")]
        public byte integer_scaling;

        /// The color to clear the screen with before rendering the console.
        public TCOD_ColorRGBA clear_color;

        /// Alignment of the console when it is letter-boxed: 0.0f renders the console in the upper-left corner, and 1.0f in the lower-right.
        public float align_x;

        public float align_y;
    }

    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Allocate a new viewport options struct.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_ViewportOptions* TCOD_viewport_new();

        /// <summary>
        /// Delete a viewport.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_viewport_delete(TCOD_ViewportOptions* viewport);
    }
}

