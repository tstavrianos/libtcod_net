# Dotnet bindings for libtcod

Bindings are auto generated using c2ffi and c2cs from bottlenoselabs. The included fix script is meant to cleanup some issues I had with the generated code.
The json files include the comments from the original headers, but c2cs doesn't seem to be doing anything with them. I might try and see if it's possible to add those
in a post-processing step.

## Included binaries

I have only generated these on windows (used VS2026) and tested only the x64 ones (x86 should work in theory).
They were generated using vcpkg from a visual studio command prompt:

```sh
git clone https://github.com/microsoft/vcpkg
cd vcpkg
bootstrap-vcpkg.bat
vcpkg install libtcod --triplet=x64-windows
vcpkg install libtcod --triplet=x86-windows
```

After that, I copied the dll and pbd files from vcpkg/installed/x64-windows/bin and vcpkg/installed/x64-windows/debug/bin (and same for x86).

The included binaries are only meant to make the unit tests and sample app work. You should generate your own if you are going to use this.

## TODO

* Review the unit tests and try and include something that covers as much surface as possible.
* Managed wrapper classes.
