using System.Runtime.InteropServices.Marshalling;

namespace libtcod_net
{
    /// <summary>
    /// Private map cell struct.
    /// </summary>
    public partial struct TCOD_MapCell
    {
        [NativeTypeName("_Bool")]
        public byte transparent;

        [NativeTypeName("_Bool")]
        public byte walkable;

        [NativeTypeName("_Bool")]
        public byte fov;
    }

    /// <summary>
    /// Private map struct.
    /// </summary>
    public unsafe partial struct TCOD_Map
    {
        public int width;

        public int height;

        public int nbcells;

        [NativeTypeName("struct TCOD_MapCell *restrict")]
        public TCOD_MapCell* cells;
    }

    public enum TCOD_fov_algorithm_t
    {
        FOV_BASIC,
        FOV_DIAMOND,
        FOV_SHADOW,
        FOV_PERMISSIVE_0,
        FOV_PERMISSIVE_1,
        FOV_PERMISSIVE_2,
        FOV_PERMISSIVE_3,
        FOV_PERMISSIVE_4,
        FOV_PERMISSIVE_5,
        FOV_PERMISSIVE_6,
        FOV_PERMISSIVE_7,
        FOV_PERMISSIVE_8,
        FOV_RESTRICTIVE,
        FOV_SYMMETRIC_SHADOWCAST,
        NB_FOV_ALGORITHMS,
    }
}

