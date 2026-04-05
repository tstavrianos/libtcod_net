using System;

namespace libtcod_net.TCOD;

public class TCODException : Exception
{
    public TCODException(string message, libtcod.TCOD_Error error)
        : base(message)
    {
        Error = error;
    }

    public libtcod.TCOD_Error Error { get; }
}
