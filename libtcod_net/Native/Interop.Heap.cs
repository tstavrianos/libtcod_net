using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_heap_init(ref TCOD_Heap heap, nuint data_size);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heap_uninit(ref TCOD_Heap heap);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_heap_clear(ref TCOD_Heap heap);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_minheap_push(ref TCOD_Heap minheap, int priority, nint data);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int TCOD_minheap_push(
        ref TCOD_Heap minheap,
        int priority,
        [In] byte[] data
    );

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_minheap_pop(ref TCOD_Heap minheap, nint @out);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_minheap_pop(ref TCOD_Heap minheap, [Out] byte[] @out);

    [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TCOD_minheap_heapify(ref TCOD_Heap minheap);
}
