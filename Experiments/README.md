# Experiments

Different attempts at using different automation tools to generated the bindings automatically with different degrees of success.

## CopilotBindings

Initial bindings that copilot generated, why I had to slowly adjust as I used them. Used it as a template to compare the others against.

## CppSharp

Took alot of effort to get it to actually work, and even the generate code crashes the sample app. 20k lines of generated code, not going to try to fix this at the moment.

## ClangSharp

ClangSharpPInvokeGenerator on its own produces code that has some issues with the deprecation flags (it splits them into multiple lines in some cases).
Starting with that, I kept messing with it and the result is something that works, but requires a lot of sanitization to get a desirable output.

## C2FFI

Used <https://github.com/rpav/c2ffi> to generate libtcod.json and tried to see how complicated it would be to generate something good. If I decide to abandon the current generator I am using, this will replace it.
Shelved for now because it required me to setup msys2 and compile c2ffi in it to produce the json file.
