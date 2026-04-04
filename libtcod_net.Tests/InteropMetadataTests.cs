using System.Reflection;
using System.Runtime.InteropServices;

namespace libtcod_net.Tests;

public class InteropMetadataTests
{
    private static readonly Type InteropType = typeof(libtcod.Interop.libtcod);

    [Theory]
    [InlineData("TCOD_random_get_instance", 1)]
    [InlineData("TCOD_random_new", 1)]
    [InlineData("TCOD_random_get_int", 1)]
    [InlineData("TCOD_noise_new", 1)]
    [InlineData("TCOD_noise_get_vectorized", 2)]
    [InlineData("TCOD_path_new_using_map", 1)]
    [InlineData("TCOD_dijkstra_new", 1)]
    [InlineData("TCOD_heap_init", 1)]
    [InlineData("TCOD_minheap_push", 2)]
    [InlineData("TCOD_pf_new", 2)]
    [InlineData("TCOD_console_flush_ex", 1)]
    [InlineData("TCOD_console_credits_render_ex", 1)]
    public void ExpectedInteropMethodsExist(string methodName, int overloadCount)
    {
        var methods = GetMethods(methodName);
        Assert.Equal(overloadCount, methods.Length);
    }

    [Theory]
    [InlineData("TCOD_random_get_instance")]
    [InlineData("TCOD_noise_new")]
    [InlineData("TCOD_path_new_using_map")]
    [InlineData("TCOD_dijkstra_new")]
    [InlineData("TCOD_heap_init")]
    [InlineData("TCOD_pf_new")]
    [InlineData("TCOD_console_flush_ex")]
    public void InteropMethodsUseExpectedDllImportSettings(string methodName)
    {
        foreach (var method in GetMethods(methodName))
        {
            var dllImport = method.GetCustomAttribute<DllImportAttribute>();
            Assert.NotNull(dllImport);
            Assert.Equal("libtcod", dllImport!.Value);
            Assert.Equal(CallingConvention.Cdecl, dllImport.CallingConvention);
            Assert.True(dllImport.ExactSpelling);
        }
    }

    [Theory]
    [InlineData("TCOD_path_compute")]
    [InlineData("TCOD_path_walk")]
    [InlineData("TCOD_dijkstra_path_set")]
    [InlineData("TCOD_dijkstra_path_walk")]
    [InlineData("TCOD_console_credits_render_ex")]
    public void BoolReturnMethodsAreMarshaledAsI1(string methodName)
    {
        foreach (var method in GetMethods(methodName))
        {
            Assert.Equal(typeof(bool), method.ReturnType);
            var marshalAs = method.ReturnParameter.GetCustomAttribute<MarshalAsAttribute>();
            Assert.NotNull(marshalAs);
            Assert.Equal(UnmanagedType.I1, marshalAs!.Value);
        }
    }

    private static MethodInfo[] GetMethods(string name)
    {
        return InteropType
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == name)
            .ToArray();
    }
}
