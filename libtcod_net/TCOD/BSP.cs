using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

public sealed unsafe class BSP : TCODResource<TCOD_bsp_t>
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Position { get; private set; }
    public byte Level { get; }
    public bool Horizontal { get; private set; }

    private BSP(TCOD_bsp_t* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct BSP with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        OwnsNativeResource = false;
        Pointer = pointer;
        X = pointer->x;
        Y = pointer->y;
        Width = pointer->w;
        Height = pointer->h;
        Position = pointer->position;
        Level = pointer->level;
        Horizontal = pointer->horizontal;
    }

    public static BSP Create()
    {
        var pointer = TCOD_bsp_new();
        ErrorHelper.CheckAndThrow(pointer);
        var bsp = new BSP(pointer) { OwnsNativeResource = true };
        return bsp;
    }

    public static BSP CreateWithSize(int x, int y, int width, int height)
    {
        var pointer = TCOD_bsp_new_with_size(x, y, width, height);
        ErrorHelper.CheckAndThrow(pointer);
        var bsp = new BSP(pointer)
        {
            OwnsNativeResource = true,
            X = x,
            Y = y,
            Width = width,
            Height = height,
        };
        return bsp;
    }

    public BSP? Left()
    {
        var ret = TCOD_bsp_left(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    public BSP? Right()
    {
        var ret = TCOD_bsp_right(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    public BSP? Father()
    {
        var ret = TCOD_bsp_father(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    public bool IsLeaf => TCOD_bsp_is_leaf(Pointer);

    public bool Contains(int x, int y)
    {
        return TCOD_bsp_contains(Pointer, x, y);
    }

    public BSP? FindNode(int x, int y)
    {
        var ret = TCOD_bsp_find_node(Pointer, x, y);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    public void Resize(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        TCOD_bsp_resize(Pointer, x, y, width, height);
    }

    public void SplitOnce(bool horizontal, int position)
    {
        TCOD_bsp_split_once(Pointer, horizontal, position);
        Position = position;
        Horizontal = horizontal;
    }

    public void SplitRecursive(
        Random random,
        int n,
        int minHSize,
        int minVSize,
        float maxHRatio,
        float maxVRatio
    )
    {
        ArgumentNullException.ThrowIfNull(random);
        TCOD_bsp_split_recursive(
            Pointer,
            random.Pointer,
            n,
            minHSize,
            minVSize,
            maxHRatio,
            maxVRatio
        );
        Position = Pointer->position;
        Horizontal = Pointer->horizontal;
    }

    public void RemoveSons()
    {
        TCOD_bsp_remove_sons(Pointer);
    }

    public void TraversePreOrder<T>(Func<BSP, T?, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        TCOD_bsp_traverse_pre_order(
            Pointer,
            new TCOD_bsp_callback_t(&Traverse),
            handle.Ptr.ToPointer()
        );
    }

    public void TraverseInOrder<T>(Func<BSP, T?, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        TCOD_bsp_traverse_in_order(
            Pointer,
            new TCOD_bsp_callback_t(&Traverse),
            handle.Ptr.ToPointer()
        );
    }

    public void TraversePostOrder<T>(Func<BSP, T?, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        TCOD_bsp_traverse_post_order(
            Pointer,
            new TCOD_bsp_callback_t(&Traverse),
            handle.Ptr.ToPointer()
        );
    }

    public void TraverseLevelOrder<T>(Func<BSP, T?, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        TCOD_bsp_traverse_level_order(
            Pointer,
            new TCOD_bsp_callback_t(&Traverse),
            handle.Ptr.ToPointer()
        );
    }

    public void TraverseInvertedLevelOrder<T>(Func<BSP, T?, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        TCOD_bsp_traverse_inverted_level_order(
            Pointer,
            new TCOD_bsp_callback_t(&Traverse),
            handle.Ptr.ToPointer()
        );
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static CBool Traverse(TCOD_bsp_t* node, void* data)
    {
        var state = (TraversalStateBase)GCHandle.FromIntPtr((nint)data).Target!;
        var managedNode = new BSP(node);
        return state.InvokeCallback(managedNode);
    }

    private abstract class TraversalStateBase
    {
        public abstract bool InvokeCallback(BSP node);
    }

    private sealed class TraversalState<T>(Func<BSP, T?, bool> callback, T? userData)
        : TraversalStateBase
        where T : notnull
    {
        public override bool InvokeCallback(BSP node) => callback(node, UserData);

        public T? UserData { get; } = userData;
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_bsp_delete(Pointer);
    }
}
