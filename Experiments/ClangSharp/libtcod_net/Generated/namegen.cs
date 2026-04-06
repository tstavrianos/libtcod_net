using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_NameGen
    {
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_namegen_parse([NativeTypeName("const char *")] sbyte* filename, TCOD_Random* random);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_namegen_generate([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("_Bool")] byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_namegen_generate_custom([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* rule, [NativeTypeName("_Bool")] byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_list_t")]
        public static extern TCOD_List* TCOD_namegen_get_sets();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_namegen_destroy();
    }
}

