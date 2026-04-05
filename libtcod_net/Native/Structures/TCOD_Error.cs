namespace libtcod_net;

public static partial class libtcod
{
    public enum TCOD_Error
    {
        TCOD_E_OK = 0,
        TCOD_E_ERROR = -1,
        TCOD_E_INVALID_ARGUMENT = -2,
        TCOD_E_OUT_OF_MEMORY = -3,
        TCOD_E_REQUIRES_ATTENTION = -4,
        TCOD_E_WARN = 1,
    }
}
