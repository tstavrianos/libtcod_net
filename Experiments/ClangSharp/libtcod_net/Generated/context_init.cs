using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Create a new context with the given parameters.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_context_new([NativeTypeName("const TCOD_ContextParams *")] TCOD_ContextParams* @params, TCOD_Context** @out);
    }
}

