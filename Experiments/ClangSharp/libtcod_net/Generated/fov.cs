using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public static unsafe partial class libtcod
    {
        /// <summary>
        /// Return a new TCOD_Map with width and height.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Map* TCOD_map_new(int width, int height);

        /// <summary>
        /// Set all cell values on map to the given parameters.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_map_clear(TCOD_Map* map, [NativeTypeName("_Bool")] byte transparent, [NativeTypeName("_Bool")] byte walkable);

        /// <summary>
        /// Clone map data from source to dest.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_copy([NativeTypeName("const TCOD_Map *restrict")] TCOD_Map* source, TCOD_Map* dest);

        /// <summary>
        /// Change the properties of a single cell.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_map_set_properties(TCOD_Map* map, int x, int y, [NativeTypeName("_Bool")] byte is_transparent, [NativeTypeName("_Bool")] byte is_walkable);

        /// <summary>
        /// Free a TCOD_Map object.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_map_delete(TCOD_Map* map);

        /// <summary>
        /// Calculate the field-of-view.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Error TCOD_map_compute_fov(TCOD_Map* map, int pov_x, int pov_y, int max_radius, [NativeTypeName("_Bool")] byte light_walls, TCOD_fov_algorithm_t algo);

        /// <summary>
        /// Return true if this cell was touched by the current field-of-view.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_map_is_in_fov([NativeTypeName("const TCOD_Map *")] TCOD_Map* map, int x, int y);

        /// <summary>
        /// Set the fov flag on a specific cell.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_map_set_in_fov(TCOD_Map* map, int x, int y, [NativeTypeName("_Bool")] byte fov);

        /// <summary>
        /// Return true if this cell is transparent.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_map_is_transparent([NativeTypeName("const TCOD_Map *")] TCOD_Map* map, int x, int y);

        /// <summary>
        /// Return true if this cell is walkable.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_map_is_walkable(TCOD_Map* map, int x, int y);

        /// <summary>
        /// Return the width of map.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_map_get_width([NativeTypeName("const TCOD_Map *")] TCOD_Map* map);

        /// <summary>
        /// Return the height of map.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_map_get_height([NativeTypeName("const TCOD_Map *")] TCOD_Map* map);

        /// <summary>
        /// Return the total number of cells in map.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_map_get_nb_cells([NativeTypeName("const TCOD_Map *")] TCOD_Map* map);
    }
}

