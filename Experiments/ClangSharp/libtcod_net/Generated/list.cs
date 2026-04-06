using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_List
    {
        /// A pointer to an array of void pointers. Internal.
        public void** array;

        /// The current count of items in the array. Internal.
        public int fillSize;

        /// The maximum number of items that array can currently hold. Internal.
        public int allocSize;
    }

    public static unsafe partial class libtcod
    {

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_List* TCOD_list_allocate(int nb_elements);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_List* TCOD_list_duplicate(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_delete(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_push(TCOD_List* l, [NativeTypeName("const void *")] void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* TCOD_list_pop(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* TCOD_list_peek(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_add_all(TCOD_List* l, TCOD_List* l2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* TCOD_list_get(TCOD_List* l, int idx);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_set(TCOD_List* l, [NativeTypeName("const void *")] void* elt, int idx);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** TCOD_list_begin(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** TCOD_list_end(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_reverse(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** TCOD_list_remove_iterator(TCOD_List* l, void** elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_remove(TCOD_List* l, [NativeTypeName("const void *")] void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** TCOD_list_remove_iterator_fast(TCOD_List* l, void** elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_remove_fast(TCOD_List* l, [NativeTypeName("const void *")] void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_list_contains(TCOD_List* l, [NativeTypeName("const void *")] void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_clear(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_list_clear_and_delete(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_list_size(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void** TCOD_list_insert_before(TCOD_List* l, [NativeTypeName("const void *")] void* elt, int before);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_list_is_empty(TCOD_List* l);
    }
}

