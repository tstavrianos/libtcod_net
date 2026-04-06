using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_Frontier
    {
        [NativeTypeName("int8_t")]
        public sbyte ndim;

        public int active_dist;

        [NativeTypeName("int[4]")]
        public _active_index_e__FixedBuffer active_index;

        [NativeTypeName("struct TCOD_Heap")]
        public TCOD_Heap heap;

        [InlineArray(4)]
        public partial struct _active_index_e__FixedBuffer
        {
            public int e0;
        }
    }

    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Create a new pathfinder frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct TCOD_Frontier *")]
        public static extern TCOD_Frontier* TCOD_frontier_new(int ndim);

        /// <summary>
        /// Delete a pathfinder frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_frontier_delete([NativeTypeName("struct TCOD_Frontier *")] TCOD_Frontier* frontier);

        /// <summary>
        /// Pop the next node from this frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_frontier_pop([NativeTypeName("struct TCOD_Frontier *")] TCOD_Frontier* frontier);

        /// <summary>
        /// Add a node to this frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_frontier_push([NativeTypeName("struct TCOD_Frontier *restrict")] TCOD_Frontier* frontier, [NativeTypeName("const int *restrict")] int* index, int dist, int heuristic);

        /// <summary>
        /// Return the current number of nodes in this frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_frontier_size([NativeTypeName("const struct TCOD_Frontier *")] TCOD_Frontier* frontier);

        /// <summary>
        /// Remove all nodes from this frontier.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_frontier_clear([NativeTypeName("struct TCOD_Frontier *")] TCOD_Frontier* frontier);
    }
}

