using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_bsp_t
    {
        public TCOD_tree_t tree;

        public int x;

        public int y;

        public int w;

        public int h;

        public int position;

        [NativeTypeName("uint8_t")]
        public byte level;

        [NativeTypeName("_Bool")]
        public byte horizontal;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_new_with_size(int x, int y, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_bsp_delete(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_left(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_right(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_father(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_is_leaf(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_traverse_pre_order(TCOD_bsp_t* node, [NativeTypeName("TCOD_bsp_callback_t")] delegate* unmanaged[Cdecl]<TCOD_bsp_t*, void*, byte> listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_traverse_in_order(TCOD_bsp_t* node, [NativeTypeName("TCOD_bsp_callback_t")] delegate* unmanaged[Cdecl]<TCOD_bsp_t*, void*, byte> listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_traverse_post_order(TCOD_bsp_t* node, [NativeTypeName("TCOD_bsp_callback_t")] delegate* unmanaged[Cdecl]<TCOD_bsp_t*, void*, byte> listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_traverse_level_order(TCOD_bsp_t* node, [NativeTypeName("TCOD_bsp_callback_t")] delegate* unmanaged[Cdecl]<TCOD_bsp_t*, void*, byte> listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_traverse_inverted_level_order(TCOD_bsp_t* node, [NativeTypeName("TCOD_bsp_callback_t")] delegate* unmanaged[Cdecl]<TCOD_bsp_t*, void*, byte> listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_bsp_contains(TCOD_bsp_t* node, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_bsp_t* TCOD_bsp_find_node(TCOD_bsp_t* node, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_bsp_resize(TCOD_bsp_t* node, int x, int y, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_bsp_split_once(TCOD_bsp_t* node, [NativeTypeName("_Bool")] byte horizontal, int position);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_bsp_split_recursive(TCOD_bsp_t* node, TCOD_Random* randomizer, int nb, int minHSize, int minVSize, float maxHRatio, float maxVRatio);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_bsp_remove_sons(TCOD_bsp_t* node);
    }
}

