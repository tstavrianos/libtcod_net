using System.Runtime.InteropServices;

namespace libtcod.Interop;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_dice_t
    {
        public int nb_rolls;
        public int nb_faces;
        public float multiplier;
        public float addsub;
    }
}
