@echo off

rem Ensure the required tools are installed. Can make these local if desired.
dotnet tool install --global bottlenoselabs.c2ffi.tool
dotnet tool install --global bottlenoselabs.C2CS.Tool 
dotnet tool install --global dotnet-script 

rem Step 1, parse the C headers and generate one json file per platform. Only x64 windows for now, haven't tested with others.
c2ffi  extract --config config-extract.json

rem Step 2, merge all the platform specific json files into one cross-platform one.
c2ffi merge --inputDirectoryPath ffi --outputFilePath merged.json

rem Step 3, basic sanitization of the merge json file. This is a bit hacky, but it works for now. It removes the "opaque" types that c2ffi generates for the SDL structs, and rewrites pointer types that point to those opaque types to point to void instead. It also removes unnamed enums, which c2cs doesn't support.
dotnet script fix.csx

rem Step 4, generate the C# code from the fixed json file.
c2cs generate --config config-generate-cs.json
