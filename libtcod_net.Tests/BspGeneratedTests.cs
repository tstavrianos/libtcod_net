using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class BspGeneratedTests
{
    [Fact]
    public void BspTraversal_PreOrderMatchesExpectedStructure()
    {
        var root = TCOD_bsp_new();
        Assert.False(root == null);

        try
        {
            TCOD_bsp_split_once(root, false, 0);
            var left = TCOD_bsp_left(root);
            Assert.False(left == null);

            TCOD_bsp_split_once(left, false, 0);

            var leftLeft = TCOD_bsp_left(left);
            var leftRight = TCOD_bsp_right(left);
            var right = TCOD_bsp_right(root);

            Assert.False(leftLeft == null);
            Assert.False(leftRight == null);
            Assert.False(right == null);

            var visited = new List<TCOD_bsp_t>();
            using var scope = new CallbackScope(visited);

            var preOrderOk = TCOD_bsp_traverse_pre_order(
                root,
                new TCOD_bsp_callback_t(&CollectNodePointers),
                scope.Handle.ToPointer()
            );

            Assert.True(preOrderOk != false);
            Assert.Equal(5, visited.Count);
            Assert.True(visited[0].tree.father == null);
            Assert.True(visited[1].tree.father == root);
            Assert.True(visited[2].tree.father == left);
            Assert.True(visited[3].tree.father == left);
            Assert.True(visited[4].tree.father == root);

            Assert.True(visited[2].tree.sons == null || visited[2].tree.sons == leftLeft);
            Assert.True(visited[3].tree.sons == null || visited[3].tree.sons == leftRight);
            Assert.True(visited[4].tree.sons == null || visited[4].tree.sons == right);

            Assert.True(
                TCOD_bsp_traverse_in_order(root, new TCOD_bsp_callback_t(&AlwaysContinue), null)
                    != false
            );
            Assert.True(
                TCOD_bsp_traverse_post_order(root, new TCOD_bsp_callback_t(&AlwaysContinue), null)
                    != false
            );
            Assert.True(
                TCOD_bsp_traverse_level_order(root, new TCOD_bsp_callback_t(&AlwaysContinue), null)
                    != false
            );
            Assert.True(
                TCOD_bsp_traverse_inverted_level_order(
                    root,
                    new TCOD_bsp_callback_t(&AlwaysContinue),
                    null
                ) != false
            );
        }
        finally
        {
            TCOD_bsp_delete(root);
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static CBool AlwaysContinue(TCOD_bsp_t* node, void* userData)
    {
        return true;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static CBool CollectNodePointers(TCOD_bsp_t* node, void* userData)
    {
        var handle = GCHandle.FromIntPtr(new nint(userData));
        var list = (List<TCOD_bsp_t>)handle.Target!;
        list.Add(*node);
        return true;
    }

    private sealed class CallbackScope : IDisposable
    {
        private GCHandle _handle;

        public CallbackScope(List<TCOD_bsp_t> output)
        {
            _handle = GCHandle.Alloc(output);
        }

        public nint Handle => GCHandle.ToIntPtr(_handle);

        public void Dispose()
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
        }
    }
}
