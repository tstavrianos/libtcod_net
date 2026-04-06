using System;

namespace System.Runtime.InteropServices.Marshalling;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Delegate)]
public sealed class NativeTypeNameAttribute : Attribute
{
    public NativeTypeNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
