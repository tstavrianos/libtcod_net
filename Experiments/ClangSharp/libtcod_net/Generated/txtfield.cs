using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public partial struct TCOD_Text
    {
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_text_t")]
        public static extern TCOD_Text* TCOD_text_init(int x, int y, int w, int h, int max_chars);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_text_t")]
        public static extern TCOD_Text* TCOD_text_init2(int w, int h, int max_chars);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_set_pos([NativeTypeName("TCOD_text_t")] TCOD_Text* txt, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_set_properties([NativeTypeName("TCOD_text_t")] TCOD_Text* txt, int cursor_char, int blink_interval, [NativeTypeName("const char *")] sbyte* prompt, int tab_size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_set_colors([NativeTypeName("TCOD_text_t")] TCOD_Text* txt, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB fore, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB back, float back_transparency);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_text_update([NativeTypeName("TCOD_text_t")] TCOD_Text* txt, TCOD_key_t key);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_render([NativeTypeName("TCOD_text_t")] TCOD_Text* txt, [NativeTypeName("TCOD_console_t")] TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_text_get([NativeTypeName("TCOD_text_t")] TCOD_Text* txt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_reset([NativeTypeName("TCOD_text_t")] TCOD_Text* txt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_text_delete([NativeTypeName("TCOD_text_t")] TCOD_Text* txt);
    }
}

