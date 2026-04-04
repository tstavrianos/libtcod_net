using System.Runtime.InteropServices;
using static libtcod.Interop.libtcod;

namespace libtcod_net.Tests;

public class BspGeneratedTests
{
    [Fact]
    public void BspTraversal_PreOrderMatchesExpectedStructure()
    {
        var root = TCOD_bsp_new();
        Assert.NotEqual(nint.Zero, root);

        try
        {
            TCOD_bsp_split_once(root, false, 0);
            var left = TCOD_bsp_left(root);
            Assert.NotEqual(nint.Zero, left);

            TCOD_bsp_split_once(left, false, 0);

            var leftLeft = TCOD_bsp_left(left);
            var leftRight = TCOD_bsp_right(left);
            var right = TCOD_bsp_right(root);

            Assert.NotEqual(nint.Zero, leftLeft);
            Assert.NotEqual(nint.Zero, leftRight);
            Assert.NotEqual(nint.Zero, right);

            var visited = new List<TCOD_bsp_t>();
            using var scope = new CallbackScope(visited);

            var preOrderOk = TCOD_bsp_traverse_pre_order(root, CollectNodePointers, scope.Handle);

            Assert.True(preOrderOk);
            Assert.Equal(5, visited.Count);
            Assert.Equal(nint.Zero, visited[0].tree.father);
            Assert.Equal(root, visited[1].tree.father);
            Assert.Equal(left, visited[2].tree.father);
            Assert.Equal(left, visited[3].tree.father);
            Assert.Equal(root, visited[4].tree.father);

            Assert.True(visited[2].tree.sons == nint.Zero || visited[2].tree.sons == leftLeft);
            Assert.True(visited[3].tree.sons == nint.Zero || visited[3].tree.sons == leftRight);
            Assert.True(visited[4].tree.sons == nint.Zero || visited[4].tree.sons == right);

            Assert.True(TCOD_bsp_traverse_in_order(root, AlwaysContinue, nint.Zero));
            Assert.True(TCOD_bsp_traverse_post_order(root, AlwaysContinue, nint.Zero));
            Assert.True(TCOD_bsp_traverse_level_order(root, AlwaysContinue, nint.Zero));
            Assert.True(TCOD_bsp_traverse_inverted_level_order(root, AlwaysContinue, nint.Zero));
        }
        finally
        {
            TCOD_bsp_delete(root);
        }
    }

    private static bool AlwaysContinue(ref TCOD_bsp_t node, nint userData)
    {
        return true;
    }

    private static bool CollectNodePointers(ref TCOD_bsp_t node, nint userData)
    {
        var handle = GCHandle.FromIntPtr(userData);
        var list = (List<TCOD_bsp_t>)handle.Target!;
        list.Add(node);
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
