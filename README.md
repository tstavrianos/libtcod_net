# Dotnet bindings for libtcod

Initial bindings were generated mostly with the help of copilot, with some tweaks here and there.

Included are some unit tests to verify everything is working correctly (ported from the libtcod source code).

Also, have a very rough sample project that shows tilesets, viewports, contexts, consoles and events.

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

## TODO

* Figure out why the code generated from CppSharp compiles but does not run. (very low on my list)
* Review the unit tests and try and include something that covers as much surface as possible.
* Managed wrapper classes.
* Expand the overloads as required.