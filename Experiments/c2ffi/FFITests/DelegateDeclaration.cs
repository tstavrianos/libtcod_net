using System.Collections.Generic;

namespace FFITests;

internal static class DelegateDeclarations
{
    internal static readonly Dictionary<string, DelegateDeclaration> Declarations = new()
    {
        {
            "TCOD_line_listener_t",
            new DelegateDeclaration(
                "TCOD_line_listener_t",
                "byte",
                [new("x", "int"), new("y", "int")]
            )
        },
        {
            "TCOD_bsp_callback_t",
            new DelegateDeclaration(
                "TCOD_bsp_callback_t",
                "byte",
                [new("node", "TCOD_bsp_t*"), new("userData", "void*")]
            )
        },
        {
            "TCOD_LoggingCallback",
            new DelegateDeclaration(
                "TCOD_LoggingCallback",
                "void",
                [new("message", "TCOD_LogMessage*"), new("userData", "void*")]
            )
        },
        {
            "TCOD_path_func_t",
            new DelegateDeclaration(
                "TCOD_path_func_t",
                "float",
                [
                    new("xFrom", "int"),
                    new("yFrom", "int"),
                    new("xTo", "int"),
                    new("yTo", "int"),
                    new("userData", "void*"),
                ]
            )
        },
    };
}

internal class DelegateDeclaration
{
    public DelegateDeclaration(
        string name,
        string returnType,
        DelegateDeclarationParameter[] parameters
    )
    {
        Name = name;
        ReturnType = returnType;
        Parameters = parameters;
    }

    public string Name { get; }
    public string ReturnType { get; }
    public DelegateDeclarationParameter[] Parameters { get; }
}

internal class DelegateDeclarationParameter
{
    public DelegateDeclarationParameter(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    public string Type { get; }
}
