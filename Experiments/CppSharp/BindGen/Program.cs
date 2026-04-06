using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

namespace BindGen;

internal static class Program
{
    private const string TilesetHeaderPath = "native\\libtcod\\src\\libtcod\\tileset.h";

    public static void Main(string[] args)
    {
        ConsoleDriver.Run(new MyLib());
        RewriteGeneratedBindings();
        if (
            (
                File.Exists("Std.cs")
                || File.Exists("libtcod_net.cs")
                || File.Exists("libtcod_net-symbols.cpp")
            ) && !File.Exists("libtcod_net.csproj")
        )
        {
            if (File.Exists("Std.cs"))
                File.Delete("Std.cs");
            if (File.Exists("libtcod_net.cs"))
                File.Delete("libtcod_net.cs");
            if (File.Exists("libtcod_net-symbols.cpp"))
                File.Delete("libtcod_net-symbols.cpp");
        }
    }

    private static void RewriteGeneratedBindings()
    {
        const string generatedFile = "libtcod_net.cs";
        var projectOutputFile = Path.Combine("libtcod_net", "libtcod_net.cs");
        if (!File.Exists(generatedFile))
            return;

        var source = File.ReadAllText(generatedFile);
        var updated = source.Replace("DllImport(\"tcod_net\"", "DllImport(\"libtcod\"");
        updated = updated.Replace(
            "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))]",
            "[MarshalAs(UnmanagedType.LPUTF8Str)]"
        );
        updated = updated.Replace(
            "return ((__Internal*)__Instance)->argv;",
            "return (sbyte**)((__Internal*)__Instance)->argv;"
        );
        updated = updated.Replace(
            "return ((__Internal*)__Instance)->array;",
            "return (__IntPtr*)((__Internal*)__Instance)->array;"
        );
        updated = updated.Replace(
            "((__Internal*)__Instance)->array = value;",
            "((__Internal*)__Instance)->array = (__IntPtr) value;"
        );
        updated = updated.Replace(
            "((__Internal*)__Instance)->colored = (__IntPtr) (byte) (value ? 1 : 0);",
            "((__Internal*)__Instance)->colored = (__IntPtr) value;"
        );
        updated = updated.Replace(
            "internal static extern void TCOD_console_get_char_background(__IntPtr return, __IntPtr con, int x, int y);",
            "internal static extern void TCOD_console_get_char_background(__IntPtr __return, __IntPtr con, int x, int y);"
        );
        updated = updated.Replace(
            "internal static extern void TCOD_console_get_char_foreground(__IntPtr return, __IntPtr con, int x, int y);",
            "internal static extern void TCOD_console_get_char_foreground(__IntPtr __return, __IntPtr con, int x, int y);"
        );
        updated = updated.Replace(
            "TCOD_console_print_internal(__arg0, x, y, w, idx, flag, align, msg, can_split, count_only)",
            "TCOD_console_print_internal(__arg0, x, y, w, 0, flag, align, msg, can_split, count_only)"
        );
        updated = updated.Replace(
            "public static void TCOD_console_put_rgb(global::libtcod_net.TCOD_Console console, int x, int y, int ch, global::libtcod_net.TCOD_ColorRGB fg, global::libtcod_net.TCOD_ColorRGB bg, global::libtcod_net.TCOD_bkgnd_flag_t flag)",
            "public static void TCOD_console_put_rgb(global::libtcod_net.TCOD_Console console, int x, int y, int ch, global::libtcod_net.TCOD_ColorRGB fg = null, global::libtcod_net.TCOD_ColorRGB bg = null, global::libtcod_net.TCOD_bkgnd_flag_t flag = global::libtcod_net.TCOD_bkgnd_flag_t.TCOD_BKGND_DEFAULT)"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.SDL_Window TCOD_context_get_sdl_window(global::libtcod_net.TCOD_Context context)\r\n        {\r\n            var __arg0 = context is null ? __IntPtr.Zero : context.__Instance;\r\n            var ___ret = __Internal.TCOD_context_get_sdl_window(__arg0);\r\n            var __result0 = global::libtcod_net.SDL_Window.__GetOrCreateInstance(___ret, false);\r\n            return __result0;\r\n        }",
            "public static __IntPtr TCOD_context_get_sdl_window(global::libtcod_net.TCOD_Context context)\r\n        {\r\n            var __arg0 = context is null ? __IntPtr.Zero : context.__Instance;\r\n            var ___ret = __Internal.TCOD_context_get_sdl_window(__arg0);\r\n            return ___ret;\r\n        }"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.SDL_Renderer TCOD_context_get_sdl_renderer(global::libtcod_net.TCOD_Context context)\r\n        {\r\n            var __arg0 = context is null ? __IntPtr.Zero : context.__Instance;\r\n            var ___ret = __Internal.TCOD_context_get_sdl_renderer(__arg0);\r\n            var __result0 = global::libtcod_net.SDL_Renderer.__GetOrCreateInstance(___ret, false);\r\n            return __result0;\r\n        }",
            "public static __IntPtr TCOD_context_get_sdl_renderer(global::libtcod_net.TCOD_Context context)\r\n        {\r\n            var __arg0 = context is null ? __IntPtr.Zero : context.__Instance;\r\n            var ___ret = __Internal.TCOD_context_get_sdl_renderer(__arg0);\r\n            return ___ret;\r\n        }"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load(string filename, int columns, int rows, int n, ref int charmap)",
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load(string filename, int columns, int rows, int n, int[] charmap)"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_mem(ulong buffer_length, byte* buffer, int columns, int rows, int n, ref int charmap)",
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_mem(ulong buffer_length, byte* buffer, int columns, int rows, int n, int[] charmap)"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_raw(int width, int height, global::libtcod_net.TCOD_ColorRGBA pixels, int columns, int rows, int n, ref int charmap)",
            "public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_raw(int width, int height, global::libtcod_net.TCOD_ColorRGBA pixels, int columns, int rows, int n, int[] charmap)"
        );
        updated = updated.Replace(
            "fixed (int* __charmap4 = &charmap)",
            "fixed (int* __charmap4 = charmap)"
        );
        updated = updated.Replace(
            "fixed (int* __charmap5 = &charmap)",
            "fixed (int* __charmap5 = charmap)"
        );
        updated = updated.Replace(
            "fixed (int* __charmap6 = &charmap)",
            "fixed (int* __charmap6 = charmap)"
        );
        updated = updated.Replace(
            "public static global::libtcod_net.TCOD_Error TCOD_context_new(global::libtcod_net.TCOD_ContextParams __arg13, global::libtcod_net.TCOD_Context __arg14)",
            "public static global::libtcod_net.TCOD_Error TCOD_context_new(in global::libtcod_net.TCOD_ContextParams __arg13, out global::libtcod_net.TCOD_Context __arg14)"
        );
        updated = updated.Replace(
            "            var ____arg1 = __arg14 is null ? __IntPtr.Zero : __arg14.__Instance;",
            "            __IntPtr ____arg1 = default;"
        );
        updated = updated.Replace(
            "            var ___ret = __Internal.TCOD_context_new(__arg0, __arg1);\r\n            return ___ret;",
            "            var ___ret = __Internal.TCOD_context_new(__arg0, __arg1);\r\n            __arg14 = ____arg1.ToPointer() == null ? null : global::libtcod_net.TCOD_Context.__GetOrCreateInstance(____arg1, false);\r\n            return ___ret;"
        );
        updated = updated.Replace(
            "            var ___ret = __Internal.TCOD_context_new(__arg0, __arg1);\n            return ___ret;",
            "            var ___ret = __Internal.TCOD_context_new(__arg0, __arg1);\n            __arg14 = ____arg1.ToPointer() == null ? null : global::libtcod_net.TCOD_Context.__GetOrCreateInstance(____arg1, false);\n            return ___ret;"
        );

        if (
            updated.Contains("global::libtcod_net.Delegates.", StringComparison.Ordinal)
            && !updated.Contains("partial class Delegates", StringComparison.Ordinal)
        )
        {
            updated +=
                "\n\nnamespace libtcod_net\n"
                + "{\n"
                + "    public static unsafe partial class Delegates\n"
                + "    {\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate void Action___IntPtr(__IntPtr arg0);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate void Action___IntPtr_doublePtr_doublePtr(__IntPtr arg0, double* arg1, double* arg2);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate void Action___IntPtr_string8(__IntPtr arg0, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPUTF8Str)] string arg1);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate int Func_int___IntPtr_int(__IntPtr arg0, int arg1);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate global::libtcod_net.TCOD_Error Func_libtcod_net_TCOD_Error___IntPtr___IntPtr(__IntPtr arg0, __IntPtr arg1);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate global::libtcod_net.TCOD_Error Func_libtcod_net_TCOD_Error___IntPtr___IntPtr___IntPtr(__IntPtr arg0, __IntPtr arg1, __IntPtr arg2);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate global::libtcod_net.TCOD_Error Func_libtcod_net_TCOD_Error___IntPtr___IntPtr_intPtr_intPtr(__IntPtr arg0, __IntPtr arg1, int* arg2, int* arg3);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate global::libtcod_net.TCOD_Error Func_libtcod_net_TCOD_Error___IntPtr_float_intPtr_intPtr(__IntPtr arg0, float arg1, int* arg2, int* arg3);\n"
                + "\n"
                + "        [global::System.Runtime.InteropServices.UnmanagedFunctionPointer(__CallingConvention.Cdecl)]\n"
                + "        public delegate global::libtcod_net.TCOD_Error Func_libtcod_net_TCOD_Error___IntPtr_string8(__IntPtr arg0, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPUTF8Str)] string arg1);\n"
                + "    }\n"
                + "}\n";
        }

        if (
            updated.Contains("CppSharp.Runtime.MarshalUtil", StringComparison.Ordinal)
            && !updated.Contains("namespace CppSharp.Runtime", StringComparison.Ordinal)
        )
        {
            updated +=
                "\n\nnamespace CppSharp.Runtime\n"
                + "{\n"
                + "    internal static unsafe class MarshalUtil\n"
                + "    {\n"
                + "        public static T[] GetArray<T>(T* pointer, int count) where T : unmanaged\n"
                + "        {\n"
                + "            if (pointer == null || count <= 0)\n"
                + "                return System.Array.Empty<T>();\n"
                + "\n"
                + "            var result = new T[count];\n"
                + "            for (var i = 0; i < count; i++)\n"
                + "                result[i] = pointer[i];\n"
                + "            return result;\n"
                + "        }\n"
                + "\n"
                + "        public static string GetString(System.Text.Encoding encoding, System.IntPtr pointer)\n"
                + "        {\n"
                + "            if (pointer == System.IntPtr.Zero)\n"
                + "                return string.Empty;\n"
                + "\n"
                + "            return System.Runtime.InteropServices.Marshal.PtrToStringUTF8(pointer) ?? string.Empty;\n"
                + "        }\n"
                + "    }\n"
                + "}\n";
        }

        updated = AppendCharmapSymbols(updated);
        updated = AppendTilesetSpanOverloads(updated);
        updated = AppendUnifiedStaticFacade(updated);

        File.WriteAllText(projectOutputFile, updated);
    }

    private static string AppendUnifiedStaticFacade(string source)
    {
        if (source.Contains("public static unsafe partial class libtcod", StringComparison.Ordinal))
            return source;

        var methods = CollectFacadeMethods(source);
        if (methods.Count == 0)
            return source;

        var sb = new StringBuilder(source);
        sb.Append("\n\nnamespace libtcod_net\n");
        sb.Append("{\n");
        sb.Append("    public static unsafe partial class libtcod\n");
        sb.Append("    {\n");
        foreach (var method in methods)
        {
            sb.Append("        public static ");
            sb.Append(method.ReturnType);
            sb.Append(' ');
            sb.Append(method.Name);
            sb.Append('(');
            sb.Append(method.Parameters);
            sb.Append(")\n");
            sb.Append("        {\n");
            sb.Append("            ");
            if (!string.Equals(method.ReturnType, "void", StringComparison.Ordinal))
                sb.Append("return ");
            sb.Append("global::libtcod_net.");
            sb.Append(method.SourceClass);
            sb.Append('.');
            sb.Append(method.Name);
            sb.Append('(');
            sb.Append(method.Arguments);
            sb.Append(");\n");
            sb.Append("        }\n\n");
        }
        sb.Append("    }\n");
        sb.Append("}\n");
        return sb.ToString();
    }

    private static List<FacadeMethod> CollectFacadeMethods(string source)
    {
        var lines = source.Replace("\r\n", "\n").Split('\n');
        var result = new List<FacadeMethod>();
        var seen = new HashSet<string>(StringComparer.Ordinal);
        var classStack = new Stack<(string Name, int Depth)>();

        var braceDepth = 0;
        string? pendingClass = null;

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();

            var classMatch = Regex.Match(
                line,
                @"^public\s+unsafe\s+partial\s+class\s+([A-Za-z_][A-Za-z0-9_]*)$"
            );
            if (classMatch.Success)
                pendingClass = classMatch.Groups[1].Value;

            var openCount = rawLine.Count(c => c == '{');
            var closeCount = rawLine.Count(c => c == '}');

            if (pendingClass != null && openCount > 0)
            {
                classStack.Push((pendingClass, braceDepth + 1));
                pendingClass = null;
            }

            if (classStack.Count > 0)
            {
                var methodMatch = Regex.Match(
                    line,
                    @"^public\s+static\s+(.+?)\s+(TCOD_[A-Za-z0-9_]+)\((.*)\)$"
                );
                if (methodMatch.Success)
                {
                    var returnType = methodMatch.Groups[1].Value.Trim();
                    var methodName = methodMatch.Groups[2].Value.Trim();
                    var parameters = methodMatch.Groups[3].Value;
                    var sourceClass = classStack.Peek().Name;
                    if (
                        string.Equals(sourceClass, "libtcod", StringComparison.Ordinal)
                        || string.Equals(sourceClass, "Delegates", StringComparison.Ordinal)
                    )
                    {
                        // Skip helper classes.
                    }
                    else
                    {
                        var args = ExtractArgumentList(parameters);
                        var key = $"{returnType}|{methodName}|{parameters}";
                        if (seen.Add(key))
                        {
                            result.Add(
                                new FacadeMethod(
                                    sourceClass,
                                    returnType,
                                    methodName,
                                    parameters,
                                    args
                                )
                            );
                        }
                    }
                }
            }

            braceDepth += openCount;
            braceDepth -= closeCount;

            while (classStack.Count > 0 && braceDepth < classStack.Peek().Depth)
                classStack.Pop();
        }

        return result;
    }

    private static string ExtractArgumentList(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
            return string.Empty;

        var parts = parameters.Split(',');
        var args = new List<string>(parts.Length);
        foreach (var part in parts)
        {
            var p = part.Trim();
            if (string.IsNullOrEmpty(p))
                continue;

            var modifier = string.Empty;
            if (p.StartsWith("ref ", StringComparison.Ordinal))
            {
                modifier = "ref ";
                p = p[4..].TrimStart();
            }
            else if (p.StartsWith("out ", StringComparison.Ordinal))
            {
                modifier = "out ";
                p = p[4..].TrimStart();
            }
            else if (p.StartsWith("in ", StringComparison.Ordinal))
            {
                modifier = "in ";
                p = p[3..].TrimStart();
            }

            var eq = p.IndexOf('=');
            if (eq >= 0)
                p = p[..eq].TrimEnd();

            var name = p.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last();
            args.Add(modifier + name);
        }

        return string.Join(", ", args);
    }

    private readonly record struct FacadeMethod(
        string SourceClass,
        string ReturnType,
        string Name,
        string Parameters,
        string Arguments
    );

    private static string AppendTilesetSpanOverloads(string source)
    {
        if (
            source.Contains(
                "TCOD_tileset_load(string filename, int columns, int rows, int n, ReadOnlySpan<int> charmap)",
                StringComparison.Ordinal
            )
        )
            return source;

        var block =
            "\n\nnamespace libtcod_net\n"
            + "{\n"
            + "    public unsafe partial class tileset\n"
            + "    {\n"
            + "        public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load(string filename, int columns, int rows, int n, ReadOnlySpan<int> charmap)\n"
            + "        {\n"
            + "            return TCOD_tileset_load(filename, columns, rows, n, charmap.ToArray());\n"
            + "        }\n"
            + "\n"
            + "        public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_mem(ulong buffer_length, byte* buffer, int columns, int rows, int n, ReadOnlySpan<int> charmap)\n"
            + "        {\n"
            + "            return TCOD_tileset_load_mem(buffer_length, buffer, columns, rows, n, charmap.ToArray());\n"
            + "        }\n"
            + "\n"
            + "        public static global::libtcod_net.TCOD_Tileset TCOD_tileset_load_raw(int width, int height, global::libtcod_net.TCOD_ColorRGBA pixels, int columns, int rows, int n, ReadOnlySpan<int> charmap)\n"
            + "        {\n"
            + "            return TCOD_tileset_load_raw(width, height, pixels, columns, rows, n, charmap.ToArray());\n"
            + "        }\n"
            + "    }\n"
            + "}\n";

        return source + block;
    }

    private static string AppendCharmapSymbols(string source)
    {
        if (source.Contains("public static class TCOD_Charmaps", StringComparison.Ordinal))
            return source;

        var cp437 = ExtractCharmapValues(TilesetHeaderPath, "TCOD_CHARMAP_CP437_");
        var tcod = ExtractCharmapValues(TilesetHeaderPath, "TCOD_CHARMAP_TCOD_");
        if (cp437 == null || tcod == null)
            return source;

        var sb = new StringBuilder(source);
        sb.Append("\n\nnamespace libtcod_net\n");
        sb.Append("{\n");
        sb.Append("    public static class TCOD_Charmaps\n");
        sb.Append("    {\n");
        sb.Append("        public static readonly int[] TCOD_CHARMAP_CP437 = new int[]\n");
        sb.Append("        {\n");
        AppendValues(sb, cp437, 12);
        sb.Append("        };\n\n");
        sb.Append("        public static readonly int[] TCOD_CHARMAP_TCOD = new int[]\n");
        sb.Append("        {\n");
        AppendValues(sb, tcod, 12);
        sb.Append("        };\n");
        sb.Append("    }\n");
        sb.Append("}\n");
        return sb.ToString();
    }

    private static void AppendValues(StringBuilder sb, IReadOnlyList<int> values, int perLine)
    {
        for (var i = 0; i < values.Count; i++)
        {
            if (i % perLine == 0)
                sb.Append("            ");

            sb.Append(values[i]);
            if (i < values.Count - 1)
                sb.Append(", ");

            if (i % perLine == perLine - 1 || i == values.Count - 1)
                sb.Append("\n");
        }
    }

    private static int[]? ExtractCharmapValues(string headerPath, string macroName)
    {
        if (!File.Exists(headerPath))
            return null;

        var source = File.ReadAllText(headerPath);
        var start = source.IndexOf($"#define {macroName}", StringComparison.Ordinal);
        if (start < 0)
            return null;

        var end = source.IndexOf("\n}", start, StringComparison.Ordinal);
        if (end < 0)
            return null;

        var block = source[start..end];
        var matches = Regex.Matches(block, @"0x[0-9A-Fa-f]+|\b\d+\b");
        if (matches.Count == 0)
            return null;

        var values = new int[matches.Count];
        for (var i = 0; i < matches.Count; i++)
        {
            var token = matches[i].Value;
            values[i] = token.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? Convert.ToInt32(token, 16)
                : int.Parse(token);
        }

        return values;
    }
}

internal sealed class MyLib : ILibrary
{
    private const string IncludeRoot = "native\\libtcod\\src\\libtcod";
    private static readonly HashSet<string> ReservedParameterNames = new(StringComparer.Ordinal)
    {
        "abstract",
        "as",
        "base",
        "bool",
        "break",
        "byte",
        "case",
        "catch",
        "char",
        "checked",
        "class",
        "const",
        "continue",
        "decimal",
        "default",
        "delegate",
        "do",
        "double",
        "else",
        "enum",
        "event",
        "explicit",
        "extern",
        "false",
        "finally",
        "fixed",
        "float",
        "for",
        "foreach",
        "goto",
        "if",
        "implicit",
        "in",
        "int",
        "interface",
        "internal",
        "is",
        "lock",
        "long",
        "namespace",
        "new",
        "null",
        "object",
        "operator",
        "out",
        "override",
        "params",
        "private",
        "protected",
        "public",
        "readonly",
        "ref",
        "return",
        "sbyte",
        "sealed",
        "short",
        "sizeof",
        "stackalloc",
        "static",
        "string",
        "struct",
        "switch",
        "this",
        "throw",
        "true",
        "try",
        "typeof",
        "uint",
        "ulong",
        "unchecked",
        "unsafe",
        "ushort",
        "using",
        "virtual",
        "void",
        "volatile",
        "while",
    };

    private static readonly HashSet<string> AllowedFunctions = new(StringComparer.Ordinal)
    {
        "TCOD_bsp_contains",
        "TCOD_bsp_delete",
        "TCOD_bsp_father",
        "TCOD_bsp_find_node",
        "TCOD_bsp_is_leaf",
        "TCOD_bsp_left",
        "TCOD_bsp_new",
        "TCOD_bsp_new_with_size",
        "TCOD_bsp_remove_sons",
        "TCOD_bsp_resize",
        "TCOD_bsp_right",
        "TCOD_bsp_split_once",
        "TCOD_bsp_split_recursive",
        "TCOD_bsp_traverse_in_order",
        "TCOD_bsp_traverse_inverted_level_order",
        "TCOD_bsp_traverse_level_order",
        "TCOD_bsp_traverse_post_order",
        "TCOD_bsp_traverse_pre_order",
        "TCOD_console_blit",
        "TCOD_console_blit_key_color",
        "TCOD_console_clear",
        "TCOD_console_credits_render_ex",
        "TCOD_console_delete",
        "TCOD_console_draw_frame_rgb",
        "TCOD_console_draw_rect_rgb",
        "TCOD_console_flush",
        "TCOD_console_flush_ex",
        "TCOD_console_from_file",
        "TCOD_console_from_xp",
        "TCOD_console_get_char",
        "TCOD_console_get_char_background",
        "TCOD_console_get_char_foreground",
        "TCOD_console_get_height",
        "TCOD_console_get_height_rect_n",
        "TCOD_console_get_height_rect_wn",
        "TCOD_console_get_width",
        "TCOD_console_load_apf",
        "TCOD_console_load_asc",
        "TCOD_console_load_xp",
        "TCOD_console_new",
        "TCOD_console_printn",
        "TCOD_console_printn_rect",
        "TCOD_console_put_rgb",
        "TCOD_console_save_apf",
        "TCOD_console_save_asc",
        "TCOD_console_save_xp",
        "TCOD_console_set_color_control",
        "TCOD_console_set_key_color",
        "TCOD_context_change_tileset",
        "TCOD_context_delete",
        "TCOD_context_get_renderer_type",
        "TCOD_context_get_sdl_renderer",
        "TCOD_context_get_sdl_window",
        "TCOD_context_new",
        "TCOD_context_present",
        "TCOD_context_recommended_console_size",
        "TCOD_context_save_screenshot",
        "TCOD_context_screen_capture",
        "TCOD_context_screen_capture_alloc",
        "TCOD_context_screen_pixel_to_tile_d",
        "TCOD_context_screen_pixel_to_tile_i",
        "TCOD_context_set_mouse_transform",
        "TCOD_dijkstra_compute",
        "TCOD_dijkstra_delete",
        "TCOD_dijkstra_get",
        "TCOD_dijkstra_get_distance",
        "TCOD_dijkstra_is_empty",
        "TCOD_dijkstra_new",
        "TCOD_dijkstra_new_using_function",
        "TCOD_dijkstra_path_set",
        "TCOD_dijkstra_path_walk",
        "TCOD_dijkstra_reverse",
        "TCOD_dijkstra_size",
        "TCOD_heap_clear",
        "TCOD_heap_init",
        "TCOD_heap_uninit",
        "TCOD_heightmap_add",
        "TCOD_heightmap_add_fbm",
        "TCOD_heightmap_add_hill",
        "TCOD_heightmap_add_hm",
        "TCOD_heightmap_add_voronoi",
        "TCOD_heightmap_clamp",
        "TCOD_heightmap_clear",
        "TCOD_heightmap_copy",
        "TCOD_heightmap_count_cells",
        "TCOD_heightmap_delete",
        "TCOD_heightmap_dig_bezier",
        "TCOD_heightmap_dig_hill",
        "TCOD_heightmap_get_interpolated_value",
        "TCOD_heightmap_get_minmax",
        "TCOD_heightmap_get_normal",
        "TCOD_heightmap_get_slope",
        "TCOD_heightmap_has_land_on_border",
        "TCOD_heightmap_kernel_transform",
        "TCOD_heightmap_kernel_transform_out",
        "TCOD_heightmap_lerp_hm",
        "TCOD_heightmap_mid_point_displacement",
        "TCOD_heightmap_multiply_hm",
        "TCOD_heightmap_new",
        "TCOD_heightmap_normalize",
        "TCOD_heightmap_rain_erosion",
        "TCOD_heightmap_scale",
        "TCOD_heightmap_scale_fbm",
        "TCOD_heightmap_threshold_mask",
        "TCOD_image_blit",
        "TCOD_image_blit_2x",
        "TCOD_image_blit_rect",
        "TCOD_image_clear",
        "TCOD_image_delete",
        "TCOD_image_from_console",
        "TCOD_image_get_alpha",
        "TCOD_image_get_mipmap_pixel",
        "TCOD_image_get_pixel",
        "TCOD_image_get_size",
        "TCOD_image_hflip",
        "TCOD_image_invert",
        "TCOD_image_is_pixel_transparent",
        "TCOD_image_load",
        "TCOD_image_new",
        "TCOD_image_put_pixel",
        "TCOD_image_refresh_console",
        "TCOD_image_rotate90",
        "TCOD_image_save",
        "TCOD_image_scale",
        "TCOD_image_set_key_color",
        "TCOD_image_vflip",
        "TCOD_line",
        "TCOD_line_init_mt",
        "TCOD_line_step_mt",
        "TCOD_load_bdf",
        "TCOD_load_bdf_memory",
        "TCOD_load_truetype_font_",
        "TCOD_load_xp",
        "TCOD_map_clear",
        "TCOD_map_compute_fov",
        "TCOD_map_copy",
        "TCOD_map_delete",
        "TCOD_map_get_height",
        "TCOD_map_get_nb_cells",
        "TCOD_map_get_width",
        "TCOD_map_is_in_fov",
        "TCOD_map_is_transparent",
        "TCOD_map_is_walkable",
        "TCOD_map_new",
        "TCOD_map_set_in_fov",
        "TCOD_map_set_properties",
        "TCOD_minheap_heapify",
        "TCOD_minheap_pop",
        "TCOD_minheap_push",
        "TCOD_noise_delete",
        "TCOD_noise_get",
        "TCOD_noise_get_ex",
        "TCOD_noise_get_fbm",
        "TCOD_noise_get_fbm_ex",
        "TCOD_noise_get_fbm_vectorized",
        "TCOD_noise_get_turbulence",
        "TCOD_noise_get_turbulence_ex",
        "TCOD_noise_get_turbulence_vectorized",
        "TCOD_noise_get_vectorized",
        "TCOD_noise_new",
        "TCOD_noise_set_type",
        "TCOD_path_compute",
        "TCOD_path_delete",
        "TCOD_path_get",
        "TCOD_path_get_destination",
        "TCOD_path_get_origin",
        "TCOD_path_is_empty",
        "TCOD_path_new_using_function",
        "TCOD_path_new_using_map",
        "TCOD_path_reverse",
        "TCOD_path_size",
        "TCOD_path_walk",
        "TCOD_pf_compute",
        "TCOD_pf_compute_step",
        "TCOD_pf_delete",
        "TCOD_pf_new",
        "TCOD_pf_recompile",
        "TCOD_pf_set_distance_pointer",
        "TCOD_pf_set_graph2d_pointer",
        "TCOD_pf_set_traversal_pointer",
        "TCOD_printn_rgb",
        "TCOD_random_delete",
        "TCOD_random_dice_new",
        "TCOD_random_dice_roll",
        "TCOD_random_dice_roll_s",
        "TCOD_random_get_double",
        "TCOD_random_get_double_mean",
        "TCOD_random_get_float",
        "TCOD_random_get_float_mean",
        "TCOD_random_get_instance",
        "TCOD_random_get_int",
        "TCOD_random_get_int_mean",
        "TCOD_random_new",
        "TCOD_random_new_from_seed",
        "TCOD_random_restore",
        "TCOD_random_save",
        "TCOD_random_set_distribution",
        "TCOD_save_xp",
        "TCOD_sys_get_SDL_renderer",
        "TCOD_sys_get_SDL_window",
        "TCOD_sys_update_char",
        "TCOD_tileset_delete",
        "TCOD_tileset_load",
        "TCOD_tileset_load_fallback_font_",
        "TCOD_tileset_load_mem",
        "TCOD_tileset_load_raw",
        "TCOD_viewport_delete",
        "TCOD_viewport_new",
    };

    private static readonly BindingFlags ReflectionFlags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    private static readonly FieldInfo? QualifiedTypeTypeField = typeof(QualifiedType).GetField(
        "Type",
        ReflectionFlags
    );
    private static readonly FieldInfo? TagTypeDeclarationField = typeof(TagType).GetField(
        "Declaration",
        ReflectionFlags
    );
    private static readonly FieldInfo? PointerTypeQualifiedPointeeField =
        typeof(PointerType).GetField("QualifiedPointee", ReflectionFlags);
    private static readonly FieldInfo? ArrayTypeQualifiedTypeField = typeof(ArrayType).GetField(
        "QualifiedType",
        ReflectionFlags
    );
    private static readonly FieldInfo? FunctionTypeReturnTypeField = typeof(FunctionType).GetField(
        "ReturnType",
        ReflectionFlags
    );
    private static readonly FieldInfo? ClassFieldsField = typeof(Class).GetField(
        "Fields",
        ReflectionFlags
    );

    public void Setup(Driver driver)
    {
        var options = driver.Options;
        options.GeneratorKind = GeneratorKind.CSharp;

        var module = options.AddModule("libtcod_net");
        module.IncludeDirs.Add(IncludeRoot + "\\");

        foreach (
            var header in Directory.GetFiles(IncludeRoot, "*.h", SearchOption.TopDirectoryOnly)
        )
        {
            var fileName = Path.GetFileName(header);
            if (fileName.Contains("sdl", StringComparison.OrdinalIgnoreCase))
                continue;

            module.Headers.Add(fileName);
        }

        var parserOptions = driver.ParserOptions;
        parserOptions.LanguageVersion = CppSharp.Parser.LanguageVersion.CPP17;
        parserOptions.AddArguments("-fcxx-exceptions");
        parserOptions.EnableRTTI = true;
    }

    public void SetupPasses(Driver driver) { }

    public void Preprocess(Driver driver, ASTContext ctx)
    {
        var parameterCounter = 0;
        foreach (var unit in ctx.TranslationUnits)
            NormalizeUnnamedParameters(unit, ref parameterCounter);

        var allowedUnits = new List<TranslationUnit>();
        foreach (var unit in ctx.TranslationUnits)
        {
            if (unit.IsSystemHeader || !IsAllowedHeader(unit.FilePath))
            {
                MarkIgnored(unit);
                continue;
            }

            allowedUnits.Add(unit);
        }

        var keep = ComputeKeepSet(allowedUnits);
        foreach (var unit in allowedUnits)
            FilterToKeepSet(unit, keep);
    }

    public void Postprocess(Driver driver, ASTContext ctx)
    {
        var allowedUnits = new List<TranslationUnit>();
        foreach (var unit in ctx.TranslationUnits)
        {
            if (unit.IsSystemHeader || !IsAllowedHeader(unit.FilePath))
                continue;

            allowedUnits.Add(unit);
        }

        var keep = ComputeKeepSet(allowedUnits);
        foreach (var unit in allowedUnits)
            FilterToKeepSet(unit, keep);
    }

    private static bool IsAllowedHeader(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return false;

        var fullPath = Path.GetFullPath(filePath);
        var rootPath = Path.GetFullPath(IncludeRoot).TrimEnd(Path.DirectorySeparatorChar);
        if (
            !fullPath.StartsWith(
                rootPath + Path.DirectorySeparatorChar,
                StringComparison.OrdinalIgnoreCase
            )
        )
            return false;

        if (!string.Equals(Path.GetExtension(fullPath), ".h", StringComparison.OrdinalIgnoreCase))
            return false;

        var parent = Path.GetDirectoryName(fullPath);
        if (!string.Equals(parent, rootPath, StringComparison.OrdinalIgnoreCase))
            return false;

        return !Path.GetFileName(fullPath).Contains("sdl", StringComparison.OrdinalIgnoreCase);
    }

    private HashSet<Declaration> ComputeKeepSet(IEnumerable<TranslationUnit> units)
    {
        var keep = new HashSet<Declaration>(ReferenceEqualityComparer.Instance);
        var visitedTypes = new HashSet<object>(ReferenceEqualityComparer.Instance);
        var queue = new Queue<Declaration>();

        foreach (var unit in units)
        {
            foreach (var decl in EnumerateDeclarations(unit))
            {
                if (decl is Function function && AllowedFunctions.Contains(function.Name))
                    queue.Enqueue(function);
            }
        }

        while (queue.Count > 0)
        {
            var decl = queue.Dequeue();
            if (!keep.Add(decl))
                continue;

            foreach (var dependency in GetDependencies(decl, visitedTypes))
            {
                if (ShouldIncludeDependency(dependency))
                    queue.Enqueue(dependency);
            }
        }

        return keep;
    }

    private static bool ShouldIncludeDependency(Declaration declaration)
    {
        if (declaration == null)
            return false;

        if (IsRequiredSupportDeclaration(declaration))
            return true;

        if (declaration is Function function)
            return AllowedFunctions.Contains(function.Name);

        if (IsSdlDeclarationName(declaration.Name))
            return false;

        if (declaration.TranslationUnit?.IsSystemHeader == true)
            return false;

        if (string.IsNullOrWhiteSpace(declaration.Name))
            return true;

        return declaration.Name.StartsWith("TCOD_", StringComparison.Ordinal);
    }

    private IEnumerable<Declaration> GetDependencies(
        Declaration declaration,
        HashSet<object> visitedTypes
    )
    {
        if (declaration is Function function)
        {
            foreach (var dep in GetDependencies(function.ReturnType, visitedTypes))
                yield return dep;
            foreach (var parameter in function.Parameters)
            foreach (var dep in GetDependencies(parameter.QualifiedType, visitedTypes))
                yield return dep;
            yield break;
        }

        if (declaration is TypedefDecl typedefDecl)
        {
            foreach (var dep in GetDependencies(typedefDecl.QualifiedType, visitedTypes))
                yield return dep;
            yield break;
        }

        if (declaration is Class @class)
        {
            if (ClassFieldsField?.GetValue(@class) is IEnumerable<Field> fields)
            {
                foreach (var field in fields)
                {
                    foreach (var dep in GetDependencies(field.QualifiedType, visitedTypes))
                        yield return dep;
                }
            }
        }
    }

    private IEnumerable<Declaration> GetDependencies(
        QualifiedType qualifiedType,
        HashSet<object> visitedTypes
    )
    {
        if (QualifiedTypeTypeField?.GetValue(qualifiedType) is not CppSharp.AST.Type type)
            yield break;

        foreach (var dep in GetDependencies(type, visitedTypes))
            yield return dep;
    }

    private IEnumerable<Declaration> GetDependencies(
        CppSharp.AST.Type type,
        HashSet<object> visitedTypes
    )
    {
        if (!visitedTypes.Add(type))
            yield break;

        if (type is TagType tagType)
        {
            if (TagTypeDeclarationField?.GetValue(tagType) is Declaration declaration)
                yield return declaration;
            yield break;
        }

        if (type is TypedefType typedefType)
        {
            if (typedefType.Declaration != null)
                yield return typedefType.Declaration;
            yield break;
        }

        if (type is PointerType pointerType)
        {
            if (PointerTypeQualifiedPointeeField?.GetValue(pointerType) is QualifiedType pointee)
            {
                foreach (var dep in GetDependencies(pointee, visitedTypes))
                    yield return dep;
            }
            yield break;
        }

        if (type is ArrayType arrayType)
        {
            if (ArrayTypeQualifiedTypeField?.GetValue(arrayType) is QualifiedType elementType)
            {
                foreach (var dep in GetDependencies(elementType, visitedTypes))
                    yield return dep;
            }
            yield break;
        }

        if (type is FunctionType functionType)
        {
            if (FunctionTypeReturnTypeField?.GetValue(functionType) is QualifiedType returnType)
            {
                foreach (var dep in GetDependencies(returnType, visitedTypes))
                    yield return dep;
            }

            foreach (var parameter in functionType.Parameters)
            {
                foreach (var dep in GetDependencies(parameter.QualifiedType, visitedTypes))
                    yield return dep;
            }
        }
    }

    private void FilterToKeepSet(DeclarationContext context, HashSet<Declaration> keep)
    {
        foreach (var decl in context.Declarations)
        {
            var shouldKeep =
                (IsRequiredSupportDeclaration(decl) || !IsSdlDeclarationName(decl.Name))
                && (
                    keep.Contains(decl)
                    || (decl is DeclarationContext nested && HasKeptDescendant(nested, keep))
                );
            if (!shouldKeep)
            {
                decl.GenerationKind = GenerationKind.None;
                decl.Ignore = true;
                if (decl is DeclarationContext ignoredContext)
                    MarkIgnored(ignoredContext);
                continue;
            }

            decl.GenerationKind = GenerationKind.Generate;
            decl.Ignore = false;

            if (decl is DeclarationContext dc)
                FilterToKeepSet(dc, keep);
        }
    }

    private static bool HasKeptDescendant(DeclarationContext context, HashSet<Declaration> keep)
    {
        foreach (var decl in context.Declarations)
        {
            if (keep.Contains(decl) || IsRequiredSupportDeclaration(decl))
                return true;
            if (decl is DeclarationContext nested && HasKeptDescendant(nested, keep))
                return true;
        }

        return false;
    }

    private static IEnumerable<Declaration> EnumerateDeclarations(DeclarationContext context)
    {
        foreach (var decl in context.Declarations)
        {
            yield return decl;
            if (decl is DeclarationContext nested)
            {
                foreach (var nestedDecl in EnumerateDeclarations(nested))
                    yield return nestedDecl;
            }
        }
    }

    private static bool IsSdlDeclarationName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        return string.Equals(name, "SDL_Surface", StringComparison.Ordinal)
            || string.Equals(name, "SDL_Renderer", StringComparison.Ordinal)
            || string.Equals(name, "SDL_Window", StringComparison.Ordinal)
            || name.StartsWith("SDL_", StringComparison.Ordinal);
    }

    private static bool IsRequiredSupportDeclaration(Declaration declaration)
    {
        return string.Equals(declaration.Name, "Delegates", StringComparison.Ordinal);
    }

    private static void MarkIgnored(DeclarationContext context)
    {
        foreach (var decl in context.Declarations)
        {
            decl.GenerationKind = GenerationKind.None;
            decl.Ignore = true;
            if (decl is DeclarationContext dc)
                MarkIgnored(dc);
        }
    }

    private static void NormalizeUnnamedParameters(
        DeclarationContext context,
        ref int parameterCounter
    )
    {
        foreach (var decl in context.Declarations)
        {
            if (decl is Function function)
            {
                foreach (var parameter in function.Parameters)
                {
                    if (
                        string.IsNullOrWhiteSpace(parameter.Name)
                        || ReservedParameterNames.Contains(parameter.Name)
                    )
                        parameter.Name = $"__arg{parameterCounter++}";
                }
            }

            if (decl is DeclarationContext dc)
                NormalizeUnnamedParameters(dc, ref parameterCounter);
        }
    }
}
