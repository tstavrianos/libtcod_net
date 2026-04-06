# BindingsPostProcessor

A Roslyn-based C# tool for post-processing generated P/Invoke bindings, transforming them into more idiomatic managed code.

## Features

### 1. Managed String Wrapper Generation

Automatically generates C# wrapper methods that accept `string` parameters instead of `sbyte*` (UTF-8 C strings). For example:

```csharp
// Generated extern function
[DllImport("libtcod")]
public static extern TCOD_Image* TCOD_image_load(sbyte* filename);

// Generated wrapper
public static TCOD_Image* TCOD_image_load(string filename)
{
    var filenamePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(filename);
    try
    {
        return TCOD_image_load((sbyte*)filenamePtr.ToPointer());
    }
    finally
    {
        System.Runtime.InteropServices.Marshal.FreeCoTaskMem(filenamePtr);
    }
}
```

**Benefits:**

- Type-safe string handling
- Automatic UTF-8 marshaling
- Memory safety (guaranteed cleanup via try-finally)
- Familiar to C# developers

### 2. Obsolete Declaration Removal

Removes functions and types marked with `[Obsolete]` attributes to keep the public API clean. Controlled via command-line flag.

### 3. SDL Struct Cleanup

Removes forward-declared SDL placeholder structs (`SDL_Window`, `SDL_Renderer`, etc.) that are not fully defined in the bindings.

## Usage

```bash
BindingsPostProcessor <output-directory> [--skip-wrappers] [--skip-obsolete-removal]
```

### Parameters

- `<output-directory>`: Path to the directory containing generated `.cs` files
- `--skip-wrappers`: Skip managed string wrapper generation
- `--skip-obsolete-removal`: Skip removal of [Obsolete] declarations

### Example

```bash
./bin/Debug/net8.0/BindingsPostProcessor.exe GeneratedCode_ClangSharp
```

## Integration

The tool is automatically called from `generate_bindings_clangsharp.ps1` after ClangSharp generates raw bindings and before Doxygen documentation injection.

### Build Integration

1. Run the generation script: `.\generate_bindings_clangsharp.ps1`
2. The script will build BindingsPostProcessor and run it automatically
3. Output files are placed in the specified output directory

## Architecture

### Core Components

- **ManagedStringWrapperGenerator.cs**: Identifies functions with `sbyte*` parameters and generates meaningful wrapper overloads
- **ObsoleteDeclarationRemover.cs**: Parses and removes deprecated declarations
- **SdlStructRemover.cs**: Cleans up placeholder SDL struct definitions

### Implementation Notes

- Uses regex-based parsing for robustness (simpler than full Roslyn trees for this use case)
- Maintains proper indentation and formatting from original files
- Tracks metrics for script output reporting

## Future Enhancements

- Integrated Doxygen documentation injection
- Nullable reference type handling for pointers
- Custom wrapper templates per function pattern
- Batch marshal handling for arrays and structures
