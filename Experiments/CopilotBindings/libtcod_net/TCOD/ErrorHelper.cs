using System.Collections.Concurrent;
using System.Collections.Generic;

namespace libtcod_net.TCOD;

public static class ErrorHelper
{
    private static readonly ConcurrentQueue<string> _warnings = [];
    public static IEnumerable<string> Warnings => _warnings;

    public static void ClearWarnings()
    {
        _warnings.Clear();
    }

    private static void Throw(libtcod.TCOD_Error error)
    {
        var message = libtcod.TCOD_get_error();
        throw new TCODException(message, error);
    }

    public static void CheckAndThrow(nint pointer)
    {
        if (pointer == nint.Zero)
            Throw(libtcod.TCOD_Error.TCOD_E_ERROR);
    }

    public static void CheckAndThrow(int ret)
    {
        if (ret < 0)
            Throw(libtcod.TCOD_Error.TCOD_E_ERROR);
    }

    public static void CheckAndThrow(libtcod.TCOD_Error ret)
    {
        if (ret != libtcod.TCOD_Error.TCOD_E_OK)
        {
            var errorOrWarning = libtcod.TCOD_get_error();
            if (ret == libtcod.TCOD_Error.TCOD_E_WARN)
            {
                _warnings.Enqueue(errorOrWarning);
            }
            else
            {
                throw new TCODException(errorOrWarning, ret);
            }
        }
    }
}
