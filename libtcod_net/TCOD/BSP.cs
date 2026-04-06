using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents a Binary Space Partitioning (BSP) node.
/// </summary>
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

    /// <summary>
    /// Creates a new BSP node.
    /// </summary>
    /// <returns>A new BSP instance.</returns>
    public static BSP Create()
    {
        var pointer = TCOD_bsp_new();
        ErrorHelper.CheckAndThrow(pointer);
        var bsp = new BSP(pointer) { OwnsNativeResource = true };
        return bsp;
    }

    /// <summary>
    /// Creates a new BSP node with the specified size and position.
    /// </summary>
    /// <param name="x">The x-coordinate of the BSP node.</param>
    /// <param name="y">The y-coordinate of the BSP node.</param>
    /// <param name="width">The width of the BSP node.</param>
    /// <param name="height">The height of the BSP node.</param>
    /// <returns>A new BSP instance with the specified size and position.</returns>
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

    /// <summary>
    /// Gets the left child of the BSP node.
    /// </summary>
    /// <returns>The left child BSP node, or null if it does not exist.</returns>
    public BSP? Left()
    {
        var ret = TCOD_bsp_left(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    /// <summary>
    /// Gets the right child of the BSP node.
    /// </summary>
    /// <returns>The right child BSP node, or null if it does not exist.</returns>
    public BSP? Right()
    {
        var ret = TCOD_bsp_right(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    /// <summary>
    /// Gets the parent of the BSP node.
    /// </summary>
    /// <returns>The parent BSP node, or null if it does not exist.</returns>
    public BSP? Father()
    {
        var ret = TCOD_bsp_father(Pointer);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    /// <summary>
    /// Determines whether the BSP node is a leaf.
    /// </summary>
    /// <returns>True if the BSP node is a leaf; otherwise, false.</returns>
    public bool IsLeaf => TCOD_bsp_is_leaf(Pointer);

    /// <summary>
    /// Determines whether the BSP node contains the specified point.
    /// </summary>
    /// <param name="x">The x-coordinate of the point.</param>
    /// <param name="y">The y-coordinate of the point.</param>
    /// <returns>True if the BSP node contains the point; otherwise, false.</returns>
    public bool Contains(int x, int y)
    {
        return TCOD_bsp_contains(Pointer, x, y);
    }

    /// <summary>
    /// Finds the BSP node that contains the specified point.
    /// </summary>
    /// <param name="x">The x-coordinate of the point.</param>
    /// <param name="y">The y-coordinate of the point.</param>
    /// <returns>The BSP node that contains the point, or null if it does not exist.</returns>
    public BSP? FindNode(int x, int y)
    {
        var ret = TCOD_bsp_find_node(Pointer, x, y);
        if (ret == null)
            return null;
        return new BSP(ret);
    }

    /// <summary>
    /// Resizes the BSP node to the specified size and position.
    /// </summary>
    /// <param name="x">The new x-coordinate of the BSP node.</param>
    /// <param name="y">The new y-coordinate of the BSP node.</param>
    /// <param name="width">The new width of the BSP node.</param>
    /// <param name="height">The new height of the BSP node.</param>
    public void Resize(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        TCOD_bsp_resize(Pointer, x, y, width, height);
    }

    /// <summary>
    /// Splits the BSP node once at the specified position.
    /// </summary>
    /// <param name="horizontal">True to split horizontally; false to split vertically.</param>
    /// <param name="position">The position at which to split the BSP node.</param>
    public void SplitOnce(bool horizontal, int position)
    {
        TCOD_bsp_split_once(Pointer, horizontal, position);
        Position = position;
        Horizontal = horizontal;
    }

    /// <summary>
    /// Recursively splits the BSP node.
    /// </summary>
    /// <param name="random">The random number generator to use for splitting.</param>
    /// <param name="n">The number of times to split the BSP node.</param>
    /// <param name="minHSize">The minimum horizontal size of the BSP node.</param>
    /// <param name="minVSize">The minimum vertical size of the BSP node.</param>
    /// <param name="maxHRatio">The maximum horizontal ratio for splitting.</param>
    /// <param name="maxVRatio">The maximum vertical ratio for splitting.</param>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Removes all child nodes of the BSP node.
    /// </summary>
    public void RemoveSons()
    {
        TCOD_bsp_remove_sons(Pointer);
    }

    /// <summary>
    /// Traverses the BSP tree in pre-order and invokes the specified callback for each node.
    /// </summary>
    /// <param name="callback">The callback to invoke for each node.</param>
    /// <param name="userData">The user data to pass to the callback.</param>
    /// <typeparam name="T">The type of the user data.</typeparam>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Traverses the BSP tree in in-order and invokes the specified callback for each node.
    /// </summary>
    /// <param name="callback">The callback to invoke for each node.</param>
    /// <param name="userData">The user data to pass to the callback.</param>
    /// <typeparam name="T">The type of the user data.</typeparam>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Traverses the BSP tree in post-order and invokes the specified callback for each node.
    /// </summary>
    /// <param name="callback">The callback to invoke for each node.</param>
    /// <param name="userData">The user data to pass to the callback.</param>
    /// <typeparam name="T">The type of the user data.</typeparam>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Traverses the BSP tree in level-order and invokes the specified callback for each node.
    /// </summary>
    /// <param name="callback">The callback to invoke for each node.</param>
    /// <param name="userData">The user data to pass to the callback.</param>
    /// <typeparam name="T">The type of the user data.</typeparam>
    /// <exception cref="ArgumentNullException"></exception>
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

    /// <summary>
    /// Traverses the BSP tree in inverted level-order and invokes the specified callback for each node.
    /// </summary>
    /// <param name="callback">The callback to invoke for each node.</param>
    /// <param name="userData">The user data to pass to the callback.</param>
    /// <typeparam name="T">The type of the user data.</typeparam>
    /// <exception cref="ArgumentNullException"></exception>
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
