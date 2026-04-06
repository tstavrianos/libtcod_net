using System;

namespace libtcod_net.TCOD;

public abstract unsafe class TCODResource<T> : IDisposable
    where T : unmanaged
{
    private T* _pointer;
    private bool _disposed;

    internal T* Pointer
    {
        get
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
            return _pointer;
        }
        set => _pointer = value;
    }

    protected bool OwnsNativeResource { get; init; } = true;

    protected abstract void ReleaseUnmanagedResources();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (OwnsNativeResource && _pointer != null)
        {
            ReleaseUnmanagedResources();
            _pointer = null;
        }

        _disposed = true;
    }

    ~TCODResource()
    {
        Dispose(disposing: false);
    }
}
