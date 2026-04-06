using System.Runtime.CompilerServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_keycode_t
    {
        TCODK_NONE,
        TCODK_ESCAPE,
        TCODK_BACKSPACE,
        TCODK_TAB,
        TCODK_ENTER,
        TCODK_SHIFT,
        TCODK_CONTROL,
        TCODK_ALT,
        TCODK_PAUSE,
        TCODK_CAPSLOCK,
        TCODK_PAGEUP,
        TCODK_PAGEDOWN,
        TCODK_END,
        TCODK_HOME,
        TCODK_UP,
        TCODK_LEFT,
        TCODK_RIGHT,
        TCODK_DOWN,
        TCODK_PRINTSCREEN,
        TCODK_INSERT,
        TCODK_DELETE,
        TCODK_LWIN,
        TCODK_RWIN,
        TCODK_APPS,
        TCODK_0,
        TCODK_1,
        TCODK_2,
        TCODK_3,
        TCODK_4,
        TCODK_5,
        TCODK_6,
        TCODK_7,
        TCODK_8,
        TCODK_9,
        TCODK_KP0,
        TCODK_KP1,
        TCODK_KP2,
        TCODK_KP3,
        TCODK_KP4,
        TCODK_KP5,
        TCODK_KP6,
        TCODK_KP7,
        TCODK_KP8,
        TCODK_KP9,
        TCODK_KPADD,
        TCODK_KPSUB,
        TCODK_KPDIV,
        TCODK_KPMUL,
        TCODK_KPDEC,
        TCODK_KPENTER,
        TCODK_F1,
        TCODK_F2,
        TCODK_F3,
        TCODK_F4,
        TCODK_F5,
        TCODK_F6,
        TCODK_F7,
        TCODK_F8,
        TCODK_F9,
        TCODK_F10,
        TCODK_F11,
        TCODK_F12,
        TCODK_NUMLOCK,
        TCODK_SCROLLLOCK,
        TCODK_SPACE,
        TCODK_CHAR,
        TCODK_TEXT,
    }

    public partial struct TCOD_key_t
    {
        public TCOD_keycode_t vk;

        [NativeTypeName("char")]
        public sbyte c;

        [NativeTypeName("char[32]")]
        public _text_e__FixedBuffer text;

        [NativeTypeName("_Bool")]
        public byte pressed;

        [NativeTypeName("_Bool")]
        public byte lalt;

        [NativeTypeName("_Bool")]
        public byte lctrl;

        [NativeTypeName("_Bool")]
        public byte lmeta;

        [NativeTypeName("_Bool")]
        public byte ralt;

        [NativeTypeName("_Bool")]
        public byte rctrl;

        [NativeTypeName("_Bool")]
        public byte rmeta;

        [NativeTypeName("_Bool")]
        public byte shift;

        [InlineArray(32)]
        public partial struct _text_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public enum TCOD_chars_t
    {
        TCOD_CHAR_HLINE = 196,
        TCOD_CHAR_VLINE = 179,
        TCOD_CHAR_NE = 191,
        TCOD_CHAR_NW = 218,
        TCOD_CHAR_SE = 217,
        TCOD_CHAR_SW = 192,
        TCOD_CHAR_TEEW = 180,
        TCOD_CHAR_TEEE = 195,
        TCOD_CHAR_TEEN = 193,
        TCOD_CHAR_TEES = 194,
        TCOD_CHAR_CROSS = 197,
        TCOD_CHAR_DHLINE = 205,
        TCOD_CHAR_DVLINE = 186,
        TCOD_CHAR_DNE = 187,
        TCOD_CHAR_DNW = 201,
        TCOD_CHAR_DSE = 188,
        TCOD_CHAR_DSW = 200,
        TCOD_CHAR_DTEEW = 185,
        TCOD_CHAR_DTEEE = 204,
        TCOD_CHAR_DTEEN = 202,
        TCOD_CHAR_DTEES = 203,
        TCOD_CHAR_DCROSS = 206,
        TCOD_CHAR_BLOCK1 = 176,
        TCOD_CHAR_BLOCK2 = 177,
        TCOD_CHAR_BLOCK3 = 178,
        TCOD_CHAR_ARROW_N = 24,
        TCOD_CHAR_ARROW_S = 25,
        TCOD_CHAR_ARROW_E = 26,
        TCOD_CHAR_ARROW_W = 27,
        TCOD_CHAR_ARROW2_N = 30,
        TCOD_CHAR_ARROW2_S = 31,
        TCOD_CHAR_ARROW2_E = 16,
        TCOD_CHAR_ARROW2_W = 17,
        TCOD_CHAR_DARROW_H = 29,
        TCOD_CHAR_DARROW_V = 18,
        TCOD_CHAR_CHECKBOX_UNSET = 224,
        TCOD_CHAR_CHECKBOX_SET = 225,
        TCOD_CHAR_RADIO_UNSET = 9,
        TCOD_CHAR_RADIO_SET = 10,
        TCOD_CHAR_SUBP_NW = 226,
        TCOD_CHAR_SUBP_NE = 227,
        TCOD_CHAR_SUBP_N = 228,
        TCOD_CHAR_SUBP_SE = 229,
        TCOD_CHAR_SUBP_DIAG = 230,
        TCOD_CHAR_SUBP_E = 231,
        TCOD_CHAR_SUBP_SW = 232,
        TCOD_CHAR_SMILIE = 1,
        TCOD_CHAR_SMILIE_INV = 2,
        TCOD_CHAR_HEART = 3,
        TCOD_CHAR_DIAMOND = 4,
        TCOD_CHAR_CLUB = 5,
        TCOD_CHAR_SPADE = 6,
        TCOD_CHAR_BULLET = 7,
        TCOD_CHAR_BULLET_INV = 8,
        TCOD_CHAR_MALE = 11,
        TCOD_CHAR_FEMALE = 12,
        TCOD_CHAR_NOTE = 13,
        TCOD_CHAR_NOTE_DOUBLE = 14,
        TCOD_CHAR_LIGHT = 15,
        TCOD_CHAR_EXCLAM_DOUBLE = 19,
        TCOD_CHAR_PILCROW = 20,
        TCOD_CHAR_SECTION = 21,
        TCOD_CHAR_POUND = 156,
        TCOD_CHAR_MULTIPLICATION = 158,
        TCOD_CHAR_FUNCTION = 159,
        TCOD_CHAR_RESERVED = 169,
        TCOD_CHAR_HALF = 171,
        TCOD_CHAR_ONE_QUARTER = 172,
        TCOD_CHAR_COPYRIGHT = 184,
        TCOD_CHAR_CENT = 189,
        TCOD_CHAR_YEN = 190,
        TCOD_CHAR_CURRENCY = 207,
        TCOD_CHAR_THREE_QUARTERS = 243,
        TCOD_CHAR_DIVISION = 246,
        TCOD_CHAR_GRADE = 248,
        TCOD_CHAR_UMLAUT = 249,
        TCOD_CHAR_POW1 = 251,
        TCOD_CHAR_POW3 = 252,
        TCOD_CHAR_POW2 = 253,
        TCOD_CHAR_BULLET_SQUARE = 254,
    }

    public enum TCOD_key_status_t
    {
        TCOD_KEY_PRESSED = 1,
        TCOD_KEY_RELEASED = 2,
    }

    public enum TCOD_font_flags_t
    {
        TCOD_FONT_LAYOUT_ASCII_INCOL = 1,
        TCOD_FONT_LAYOUT_ASCII_INROW = 2,
        TCOD_FONT_TYPE_GREYSCALE = 4,
        TCOD_FONT_TYPE_GRAYSCALE = 4,
        TCOD_FONT_LAYOUT_TCOD = 8,
        TCOD_FONT_LAYOUT_CP437 = 16,
    }

    public enum TCOD_renderer_t
    {
        TCOD_RENDERER_GLSL,
        TCOD_RENDERER_OPENGL,
        TCOD_RENDERER_SDL,
        TCOD_RENDERER_SDL2,
        TCOD_RENDERER_OPENGL2,
        TCOD_RENDERER_XTERM,
        TCOD_NB_RENDERERS,
    }
}

