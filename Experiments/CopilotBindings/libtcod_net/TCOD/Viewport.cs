namespace libtcod_net.TCOD;

public sealed class Viewport : TCODResource
{
    private readonly int _version;

    private Viewport(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Viewport with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        var s = libtcod.TCOD_ViewportOptions.RetrieveFromPointer(pointer);
        _version = s.tcod_version;
    }

    public static Viewport Create()
    {
        var p = libtcod.TCOD_viewport_new();
        ErrorHelper.CheckAndThrow(p);
        return new Viewport(p);
    }

    public void WriteToStruct(out libtcod.TCOD_ViewportOptions options)
    {
        options = libtcod.TCOD_ViewportOptions.RetrieveFromPointer(Pointer);
    }

    public void ReadFromStruct(libtcod.TCOD_ViewportOptions options)
    {
        options.tcod_version = _version;
        options.ApplyToPointer(Pointer);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_viewport_delete(Pointer);
    }
}
