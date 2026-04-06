using System;
using System.Runtime.InteropServices;

namespace libtcod_net;

public static partial class libtcod
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TCOD_dice_t
    {
        public int nb_rolls;
        public int nb_faces;
        public float multiplier;
        public float addsub;

        public static TCOD_dice_t Parse(string s)
        {
            ArgumentException.ThrowIfNullOrEmpty(s);
            return TCOD_random_dice_new(s);
        }
    }
}
