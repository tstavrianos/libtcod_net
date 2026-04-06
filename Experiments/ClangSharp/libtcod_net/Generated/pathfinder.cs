using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_ArrayData
    {
        [NativeTypeName("int8_t")]
        public sbyte ndim;

        public int int_type;

        [NativeTypeName("size_t[5]")]
        public _shape_e__FixedBuffer shape;

        [NativeTypeName("size_t[5]")]
        public _strides_e__FixedBuffer strides;

        [NativeTypeName("unsigned char *")]
        public byte* data;

        [InlineArray(5)]
        public partial struct _shape_e__FixedBuffer
        {
            public nuint e0;
        }

        [InlineArray(5)]
        public partial struct _strides_e__FixedBuffer
        {
            public nuint e0;
        }
    }

    public partial struct TCOD_BasicGraph2D
    {
        [NativeTypeName("struct TCOD_ArrayData")]
        public TCOD_ArrayData cost;

        public int cardinal;

        public int diagonal;
    }

    public partial struct TCOD_Pathfinder
    {
        [NativeTypeName("int8_t")]
        public sbyte ndim;

        [NativeTypeName("size_t[4]")]
        public _shape_e__FixedBuffer shape;

        [NativeTypeName("_Bool")]
        public byte owns_distance;

        [NativeTypeName("_Bool")]
        public byte owns_graph;

        [NativeTypeName("_Bool")]
        public byte owns_traversal;

        [NativeTypeName("struct TCOD_ArrayData")]
        public TCOD_ArrayData distance;

        [NativeTypeName("struct TCOD_BasicGraph2D")]
        public TCOD_BasicGraph2D graph;

        [NativeTypeName("struct TCOD_ArrayData")]
        public TCOD_ArrayData traversal;

        [NativeTypeName("struct TCOD_Heap")]
        public TCOD_Heap heap;

        [InlineArray(4)]
        public partial struct _shape_e__FixedBuffer
        {
            public nuint e0;
        }
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct TCOD_Pathfinder *")]
        public static extern TCOD_Pathfinder* TCOD_pf_new(int ndim, [NativeTypeName("const size_t *")] nuint* shape);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_pf_delete([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_pf_set_distance_pointer([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path, void* data, int int_type, [NativeTypeName("const size_t *")] nuint* strides);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_pf_set_graph2d_pointer([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path, void* data, int int_type, [NativeTypeName("const size_t *")] nuint* strides, int cardinal, int diagonal);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_pf_set_traversal_pointer([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path, void* data, int int_type, [NativeTypeName("const size_t *")] nuint* strides);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_pf_recompile([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_pf_compute([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_pf_compute_step([NativeTypeName("struct TCOD_Pathfinder *")] TCOD_Pathfinder* path);
    }
}

