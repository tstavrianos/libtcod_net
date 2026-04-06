using System.Collections.Concurrent;
using System.Collections.Generic;
using Interop.Runtime;

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
        string messageStr = CString.ToString(message);
        throw new TCODException(messageStr, error);
    }

    public static unsafe void CheckAndThrow<T>(T* pointer)
        where T : unmanaged
    {
        if (pointer == null)
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
            var message = libtcod.TCOD_get_error();
            string messageStr = CString.ToString(message);
            if (ret == libtcod.TCOD_Error.TCOD_E_WARN)
            {
                _warnings.Enqueue(messageStr);
            }
            else
            {
                throw new TCODException(messageStr, ret);
            }
        }
    }
}
