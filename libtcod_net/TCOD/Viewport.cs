namespace libtcod_net.TCOD;

using static libtcod;

public sealed unsafe class Viewport : TCODResource<TCOD_ViewportOptions>
{
    private readonly int _version;

    private Viewport(TCOD_ViewportOptions* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Viewport with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        _version = pointer->tcod_version;
    }

    public static Viewport Create()
    {
        var p = TCOD_viewport_new();
        ErrorHelper.CheckAndThrow(p);
        return new Viewport(p);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_viewport_delete(Pointer);
    }
}
