using System;
using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

public class BSP : TCODResource
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Position { get; private set; }
    public byte Level { get; }
    public bool Horizontal { get; private set; }

    private BSP(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct BSP with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        OwnsNativeResource = false;
        Pointer = pointer;
        var s = Marshal.PtrToStructure<libtcod.TCOD_bsp_t>(pointer);
        X = s.x;
        Y = s.y;
        Width = s.w;
        Height = s.h;
        Position = s.position;
        Level = s.level;
        Horizontal = s.horizontal;
    }

    public static BSP Create()
    {
        var pointer = libtcod.TCOD_bsp_new();
        ErrorHelper.CheckAndThrow(pointer);
        var bsp = new BSP(pointer) { OwnsNativeResource = true };
        return bsp;
    }

    public static BSP CreateWithSize(int x, int y, int width, int height)
    {
        var pointer = libtcod.TCOD_bsp_new_with_size(x, y, width, height);
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
        var ret = libtcod.TCOD_bsp_left(Pointer);
        if (ret == nint.Zero)
            return null;
        return new BSP(ret);
    }

    public BSP? Right()
    {
        var ret = libtcod.TCOD_bsp_right(Pointer);
        if (ret == nint.Zero)
            return null;
        return new BSP(ret);
    }

    public BSP? Father()
    {
        var ret = libtcod.TCOD_bsp_father(Pointer);
        if (ret == nint.Zero)
            return null;
        return new BSP(ret);
    }

    public bool IsLeaf => libtcod.TCOD_bsp_is_leaf(Pointer);

    public bool Contains(int x, int y)
    {
        return libtcod.TCOD_bsp_contains(Pointer, x, y);
    }

    public BSP? FindNode(int x, int y)
    {
        var ret = libtcod.TCOD_bsp_find_node(Pointer, x, y);
        if (ret == nint.Zero)
            return null;
        return new BSP(ret);
    }

    public void Resize(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        libtcod.TCOD_bsp_resize(Pointer, x, y, width, height);
    }

    public void SplitOnce(bool horizontal, int position)
    {
        libtcod.TCOD_bsp_split_once(Pointer, horizontal, position);
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
        libtcod.TCOD_bsp_split_recursive(
            Pointer,
            random.Pointer,
            n,
            minHSize,
            minVSize,
            maxHRatio,
            maxVRatio
        );
        var s = Marshal.PtrToStructure<libtcod.TCOD_bsp_t>(Pointer);
        Position = s.position;
        Horizontal = s.horizontal;
    }

    public void RemoveSons()
    {
        libtcod.TCOD_bsp_remove_sons(Pointer);
    }

    public void TraversePreOrder<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        libtcod.TCOD_bsp_traverse_pre_order(Pointer, Traverse<T>, handle.Ptr);
        KeepAlive(state.UserData);
    }

    public void TraverseInOrder<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        libtcod.TCOD_bsp_traverse_in_order(Pointer, Traverse<T>, handle.Ptr);
        KeepAlive(state.UserData);
    }

    public void TraversePostOrder<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        libtcod.TCOD_bsp_traverse_post_order(Pointer, Traverse<T>, handle.Ptr);
        KeepAlive(state.UserData);
    }

    public void TraverseLevelOrder<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        libtcod.TCOD_bsp_traverse_level_order(Pointer, Traverse<T>, handle.Ptr);
        KeepAlive(state.UserData);
    }

    public void TraverseInvertedLevelOrder<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(callback);

        var state = new TraversalState<T>(callback, userData);
        using var handle = new GCHandleScope(state);
        libtcod.TCOD_bsp_traverse_inverted_level_order(Pointer, Traverse<T>, handle.Ptr);
        KeepAlive(state.UserData);
    }

    private static unsafe bool Traverse<T>(ref libtcod.TCOD_bsp_t node, nint data)
        where T : notnull
    {
        var state = (TraversalState<T>)GCHandle.FromIntPtr(data).Target!;
        fixed (libtcod.TCOD_bsp_t* nodePtr = &node)
        {
            var nodePointer = (nint)nodePtr;
            if (nodePointer == nint.Zero)
                return false;

            var managedNode = new BSP(nodePointer);
            return state.Callback(managedNode);
        }
    }

    private static void KeepAlive<T>(T? value)
        where T : notnull
    {
        GC.KeepAlive(value);
    }

    private sealed class TraversalState<T>(Func<BSP, bool> callback, T? userData)
        where T : notnull
    {
        public Func<BSP, bool> Callback { get; } = callback;
        public T? UserData { get; } = userData;
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_bsp_delete(Pointer);
    }
}
