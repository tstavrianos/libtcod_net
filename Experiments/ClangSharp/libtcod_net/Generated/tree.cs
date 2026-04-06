using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_tree_t
    {
        [NativeTypeName("struct TCOD_tree_t *")]
        public TCOD_tree_t* next;

        [NativeTypeName("struct TCOD_tree_t *")]
        public TCOD_tree_t* father;

        [NativeTypeName("struct TCOD_tree_t *")]
        public TCOD_tree_t* sons;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_tree_t* TCOD_tree_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_tree_add_son(TCOD_tree_t* node, TCOD_tree_t* son);
    }
}

