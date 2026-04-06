using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_Heap
    {
        [NativeTypeName("unsigned char *restrict")]
        public byte* heap;

        public int size;

        public int capacity;

        [NativeTypeName("size_t")]
        public nuint node_size;

        [NativeTypeName("size_t")]
        public nuint data_size;

        [NativeTypeName("size_t")]
        public nuint data_offset;

        public int priority_type;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_heap_init([NativeTypeName("struct TCOD_Heap *")] TCOD_Heap* heap, [NativeTypeName("size_t")] nuint data_size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heap_uninit([NativeTypeName("struct TCOD_Heap *")] TCOD_Heap* heap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_heap_clear([NativeTypeName("struct TCOD_Heap *")] TCOD_Heap* heap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_minheap_push([NativeTypeName("struct TCOD_Heap *restrict")] TCOD_Heap* minheap, int priority, [NativeTypeName("const void *restrict")] void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_minheap_pop([NativeTypeName("struct TCOD_Heap *restrict")] TCOD_Heap* minheap, [NativeTypeName("void *restrict")] void* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_minheap_heapify([NativeTypeName("struct TCOD_Heap *")] TCOD_Heap* minheap);
    }
}

