using System.Runtime.InteropServices;

namespace libtcod_net.TCOD;

internal ref struct GCHandleScope(object obj)
{
    private GCHandle _handle = GCHandle.Alloc(obj);
    private bool _disposed = false;

    public nint Ptr => GCHandle.ToIntPtr(_handle);

    public void Dispose()
    {
        if (!_disposed && _handle.IsAllocated)
        {
            _handle.Free();
            _disposed = true;
        }
    }
}
