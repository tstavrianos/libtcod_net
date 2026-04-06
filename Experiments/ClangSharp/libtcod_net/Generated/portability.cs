using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Allocate and return a duplicate of string s.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_strdup([NativeTypeName("const char *")] sbyte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_strcasecmp([NativeTypeName("const char *")] sbyte* s1, [NativeTypeName("const char *")] sbyte* s2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_strncasecmp([NativeTypeName("const char *")] sbyte* s1, [NativeTypeName("const char *")] sbyte* s2, [NativeTypeName("size_t")] nuint n);
    }
}

