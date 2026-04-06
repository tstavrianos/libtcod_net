using System;
using System.Runtime.InteropServices;
using System.Text;
using Interop.Runtime;

namespace libtcod_net.TCOD;

internal sealed class StringMarshal : IDisposable
{
    private readonly nint _pointer;
    private bool _disposed;
    public CString CStr { get; }
    public int Length { get; }

    public StringMarshal(string? value)
    {
        _pointer = value is not null ? Marshal.StringToCoTaskMemUTF8(value) : nint.Zero;
        CStr = CString.FromIntPtr(_pointer);
        Length = value is not null ? Encoding.UTF8.GetByteCount(value) : 0;
    }

    public void Dispose()
    {
        if (!_disposed && _pointer != nint.Zero)
            Marshal.FreeCoTaskMem(_pointer);
        _disposed = true;
    }
}
