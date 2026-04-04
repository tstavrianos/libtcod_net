using System.Runtime.InteropServices;

namespace libtcod_net;

[StructLayout(LayoutKind.Sequential)]
public struct TCOD_dice_t
{
    public int nb_rolls;
    public int nb_faces;
    public float multiplier;
    public float addsub;
}
