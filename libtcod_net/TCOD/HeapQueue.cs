using System;
using System.Runtime.InteropServices;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class HeapQueue<T> : TCODResource<TCOD_Heap>
    where T : unmanaged
{
    private HeapQueue(TCOD_Heap* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct HeapQueue with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );

        Pointer = pointer;
    }

    public static HeapQueue<T> Create()
    {
        var queue = (TCOD_Heap*)NativeMemory.Alloc((nuint)sizeof(TCOD_Heap));
        *queue = default;

        var ret = TCOD_heap_init(queue, (ulong)sizeof(T));
        if (ret < 0)
        {
            NativeMemory.Free(queue);
            throw new TCODException("Failed to initialize HeapQueue", (TCOD_Error)ret);
        }

        return new HeapQueue<T>(queue);
    }

    public void Clear()
    {
        TCOD_heap_clear(Pointer);
    }

    public void Push(ref T item, int priority)
    {
        fixed (T* itemPtr = &item)
        {
            var ret = TCOD_minheap_push(Pointer, priority, itemPtr);
            if (ret < 0)
                throw new TCODException("Failed to push item onto HeapQueue", (TCOD_Error)ret);
        }
    }

    public void Pop(out T item)
    {
        if (Pointer->size == 0)
            throw new InvalidOperationException("Cannot pop from an empty HeapQueue.");

        item = default;
        fixed (T* itemPtr = &item)
        {
            TCOD_minheap_pop(Pointer, itemPtr);
        }
    }

    public void Heapify()
    {
        TCOD_minheap_heapify(Pointer);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_heap_uninit(Pointer);
        NativeMemory.Free(Pointer);
    }
}
