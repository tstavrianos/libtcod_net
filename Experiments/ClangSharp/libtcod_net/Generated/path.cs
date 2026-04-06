using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_Path
    {
    }

    /// <summary>
    /// Dijkstra data structure.
    /// </summary>
    public unsafe partial struct TCOD_Dijkstra
    {
        public int diagonal_cost;

        public int width;

        public int height;

        public int nodes_max;

        public TCOD_Map* map;

        [NativeTypeName("TCOD_path_func_t")]
        public delegate* unmanaged[Cdecl]<int, int, int, int, void*, float> func;

        public void* user_data;

        [NativeTypeName("unsigned int *")]
        public uint* distances;

        [NativeTypeName("unsigned int *")]
        public uint* nodes;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* path;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_path_t")]
        public static extern TCOD_Path* TCOD_path_new_using_map(TCOD_Map* map, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_path_t")]
        public static extern TCOD_Path* TCOD_path_new_using_function(int map_width, int map_height, [NativeTypeName("TCOD_path_func_t")] delegate* unmanaged[Cdecl]<int, int, int, int, void*, float> func, void* user_data, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_path_compute([NativeTypeName("TCOD_path_t")] TCOD_Path* path, int ox, int oy, int dx, int dy);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_path_walk([NativeTypeName("TCOD_path_t")] TCOD_Path* path, int* x, int* y, [NativeTypeName("_Bool")] byte recalculate_when_needed);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_path_is_empty([NativeTypeName("TCOD_path_t")] TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_path_size([NativeTypeName("TCOD_path_t")] TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_path_reverse([NativeTypeName("TCOD_path_t")] TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_path_get([NativeTypeName("TCOD_path_t")] TCOD_Path* path, int index, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_path_get_origin([NativeTypeName("TCOD_path_t")] TCOD_Path* path, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_path_get_destination([NativeTypeName("TCOD_path_t")] TCOD_Path* path, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_path_delete([NativeTypeName("TCOD_path_t")] TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Dijkstra* TCOD_dijkstra_new(TCOD_Map* map, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Dijkstra* TCOD_dijkstra_new_using_function(int map_width, int map_height, [NativeTypeName("TCOD_path_func_t")] delegate* unmanaged[Cdecl]<int, int, int, int, void*, float> func, void* user_data, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_dijkstra_compute(TCOD_Dijkstra* dijkstra, int root_x, int root_y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_dijkstra_get_distance(TCOD_Dijkstra* dijkstra, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_dijkstra_path_set(TCOD_Dijkstra* dijkstra, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_dijkstra_is_empty(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_dijkstra_size(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_dijkstra_reverse(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_dijkstra_get(TCOD_Dijkstra* path, int index, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_dijkstra_path_walk(TCOD_Dijkstra* dijkstra, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_dijkstra_delete(TCOD_Dijkstra* dijkstra);
    }
}

