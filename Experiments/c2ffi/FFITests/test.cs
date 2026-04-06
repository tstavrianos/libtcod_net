using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace libtcod_net.Generated
{
    public enum TCOD_Error : int
    {
        TCOD_E_OK = 0,
        TCOD_E_ERROR = unchecked((int)0xFFFFFFFF),
        TCOD_E_INVALID_ARGUMENT = unchecked((int)0xFFFFFFFE),
        TCOD_E_OUT_OF_MEMORY = unchecked((int)0xFFFFFFFD),
        TCOD_E_REQUIRES_ATTENTION = unchecked((int)0xFFFFFFFC),
        TCOD_E_WARN = 1,
    }

    public enum TCOD_alignment_t : int
    {
        TCOD_LEFT = 0,
        TCOD_RIGHT = 1,
        TCOD_CENTER = 2,
    }

    public enum TCOD_bkgnd_flag_t : int
    {
        TCOD_BKGND_NONE = 0,
        TCOD_BKGND_SET = 1,
        TCOD_BKGND_MULTIPLY = 2,
        TCOD_BKGND_LIGHTEN = 3,
        TCOD_BKGND_DARKEN = 4,
        TCOD_BKGND_SCREEN = 5,
        TCOD_BKGND_COLOR_DODGE = 6,
        TCOD_BKGND_COLOR_BURN = 7,
        TCOD_BKGND_ADD = 8,
        TCOD_BKGND_ADDA = 9,
        TCOD_BKGND_BURN = 10,
        TCOD_BKGND_OVERLAY = 11,
        TCOD_BKGND_ALPH = 12,
        TCOD_BKGND_DEFAULT = 13,
    }

    public enum TCOD_colctrl_t : int
    {
        TCOD_COLCTRL_1 = 1,
        TCOD_COLCTRL_2 = 2,
        TCOD_COLCTRL_3 = 3,
        TCOD_COLCTRL_4 = 4,
        TCOD_COLCTRL_5 = 5,
        TCOD_COLCTRL_NUMBER = 5,
        TCOD_COLCTRL_FORE_RGB = 6,
        TCOD_COLCTRL_BACK_RGB = 7,
        TCOD_COLCTRL_STOP = 8,
    }

    public enum TCOD_distribution_t : int
    {
        TCOD_DISTRIBUTION_LINEAR = 0,
        TCOD_DISTRIBUTION_GAUSSIAN = 1,
        TCOD_DISTRIBUTION_GAUSSIAN_RANGE = 2,
        TCOD_DISTRIBUTION_GAUSSIAN_INVERSE = 3,
        TCOD_DISTRIBUTION_GAUSSIAN_RANGE_INVERSE = 4,
    }

    public enum TCOD_event_t : int
    {
        TCOD_EVENT_NONE = 0,
        TCOD_EVENT_KEY_PRESS = 1,
        TCOD_EVENT_KEY_RELEASE = 2,
        TCOD_EVENT_KEY = 3,
        TCOD_EVENT_MOUSE_MOVE = 4,
        TCOD_EVENT_MOUSE_PRESS = 8,
        TCOD_EVENT_MOUSE_RELEASE = 16,
        TCOD_EVENT_MOUSE = 28,
        TCOD_EVENT_FINGER_MOVE = 32,
        TCOD_EVENT_FINGER_PRESS = 64,
        TCOD_EVENT_FINGER_RELEASE = 128,
        TCOD_EVENT_FINGER = 224,
        TCOD_EVENT_ANY = 255,
    }

    public enum TCOD_fov_algorithm_t : int
    {
        FOV_BASIC = 0,
        FOV_DIAMOND = 1,
        FOV_SHADOW = 2,
        FOV_PERMISSIVE_0 = 3,
        FOV_PERMISSIVE_1 = 4,
        FOV_PERMISSIVE_2 = 5,
        FOV_PERMISSIVE_3 = 6,
        FOV_PERMISSIVE_4 = 7,
        FOV_PERMISSIVE_5 = 8,
        FOV_PERMISSIVE_6 = 9,
        FOV_PERMISSIVE_7 = 10,
        FOV_PERMISSIVE_8 = 11,
        FOV_RESTRICTIVE = 12,
        FOV_SYMMETRIC_SHADOWCAST = 13,
        NB_FOV_ALGORITHMS = 14,
    }

    public enum TCOD_keycode_t : int
    {
        TCODK_NONE = 0,
        TCODK_ESCAPE = 1,
        TCODK_BACKSPACE = 2,
        TCODK_TAB = 3,
        TCODK_ENTER = 4,
        TCODK_SHIFT = 5,
        TCODK_CONTROL = 6,
        TCODK_ALT = 7,
        TCODK_PAUSE = 8,
        TCODK_CAPSLOCK = 9,
        TCODK_PAGEUP = 10,
        TCODK_PAGEDOWN = 11,
        TCODK_END = 12,
        TCODK_HOME = 13,
        TCODK_UP = 14,
        TCODK_LEFT = 15,
        TCODK_RIGHT = 16,
        TCODK_DOWN = 17,
        TCODK_PRINTSCREEN = 18,
        TCODK_INSERT = 19,
        TCODK_DELETE = 20,
        TCODK_LWIN = 21,
        TCODK_RWIN = 22,
        TCODK_APPS = 23,
        TCODK_0 = 24,
        TCODK_1 = 25,
        TCODK_2 = 26,
        TCODK_3 = 27,
        TCODK_4 = 28,
        TCODK_5 = 29,
        TCODK_6 = 30,
        TCODK_7 = 31,
        TCODK_8 = 32,
        TCODK_9 = 33,
        TCODK_KP0 = 34,
        TCODK_KP1 = 35,
        TCODK_KP2 = 36,
        TCODK_KP3 = 37,
        TCODK_KP4 = 38,
        TCODK_KP5 = 39,
        TCODK_KP6 = 40,
        TCODK_KP7 = 41,
        TCODK_KP8 = 42,
        TCODK_KP9 = 43,
        TCODK_KPADD = 44,
        TCODK_KPSUB = 45,
        TCODK_KPDIV = 46,
        TCODK_KPMUL = 47,
        TCODK_KPDEC = 48,
        TCODK_KPENTER = 49,
        TCODK_F1 = 50,
        TCODK_F2 = 51,
        TCODK_F3 = 52,
        TCODK_F4 = 53,
        TCODK_F5 = 54,
        TCODK_F6 = 55,
        TCODK_F7 = 56,
        TCODK_F8 = 57,
        TCODK_F9 = 58,
        TCODK_F10 = 59,
        TCODK_F11 = 60,
        TCODK_F12 = 61,
        TCODK_NUMLOCK = 62,
        TCODK_SCROLLLOCK = 63,
        TCODK_SPACE = 64,
        TCODK_CHAR = 65,
        TCODK_TEXT = 66,
    }

    public enum TCOD_noise_type_t : int
    {
        TCOD_NOISE_PERLIN = 1,
        TCOD_NOISE_SIMPLEX = 2,
        TCOD_NOISE_WAVELET = 4,
        TCOD_NOISE_DEFAULT = 0,
    }

    public enum TCOD_random_algo_t : int
    {
        TCOD_RNG_MT = 0,
        TCOD_RNG_CMWC = 1,
    }

    public enum TCOD_renderer_t : int
    {
        TCOD_RENDERER_GLSL = 0,
        TCOD_RENDERER_OPENGL = 1,
        TCOD_RENDERER_SDL = 2,
        TCOD_RENDERER_SDL2 = 3,
        TCOD_RENDERER_OPENGL2 = 4,
        TCOD_RENDERER_XTERM = 5,
        TCOD_NB_RENDERERS = 6,
    }

    public enum TCOD_value_type_t : int
    {
        TCOD_TYPE_NONE = 0,
        TCOD_TYPE_BOOL = 1,
        TCOD_TYPE_CHAR = 2,
        TCOD_TYPE_INT = 3,
        TCOD_TYPE_FLOAT = 4,
        TCOD_TYPE_STRING = 5,
        TCOD_TYPE_COLOR = 6,
        TCOD_TYPE_DICE = 7,
        TCOD_TYPE_VALUELIST00 = 8,
        TCOD_TYPE_VALUELIST01 = 9,
        TCOD_TYPE_VALUELIST02 = 10,
        TCOD_TYPE_VALUELIST03 = 11,
        TCOD_TYPE_VALUELIST04 = 12,
        TCOD_TYPE_VALUELIST05 = 13,
        TCOD_TYPE_VALUELIST06 = 14,
        TCOD_TYPE_VALUELIST07 = 15,
        TCOD_TYPE_VALUELIST08 = 16,
        TCOD_TYPE_VALUELIST09 = 17,
        TCOD_TYPE_VALUELIST10 = 18,
        TCOD_TYPE_VALUELIST11 = 19,
        TCOD_TYPE_VALUELIST12 = 20,
        TCOD_TYPE_VALUELIST13 = 21,
        TCOD_TYPE_VALUELIST14 = 22,
        TCOD_TYPE_VALUELIST15 = 23,
        TCOD_TYPE_CUSTOM00 = 24,
        TCOD_TYPE_CUSTOM01 = 25,
        TCOD_TYPE_CUSTOM02 = 26,
        TCOD_TYPE_CUSTOM03 = 27,
        TCOD_TYPE_CUSTOM04 = 28,
        TCOD_TYPE_CUSTOM05 = 29,
        TCOD_TYPE_CUSTOM06 = 30,
        TCOD_TYPE_CUSTOM07 = 31,
        TCOD_TYPE_CUSTOM08 = 32,
        TCOD_TYPE_CUSTOM09 = 33,
        TCOD_TYPE_CUSTOM10 = 34,
        TCOD_TYPE_CUSTOM11 = 35,
        TCOD_TYPE_CUSTOM12 = 36,
        TCOD_TYPE_CUSTOM13 = 37,
        TCOD_TYPE_CUSTOM14 = 38,
        TCOD_TYPE_CUSTOM15 = 39,
        TCOD_TYPE_LIST = 1024,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void TCOD_LoggingCallback(TCOD_LogMessage* message, void* userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate byte TCOD_bsp_callback_t(TCOD_bsp_t* node, void* userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate byte TCOD_line_listener_t(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float TCOD_path_func_t(int xFrom, int yFrom, int xTo, int yTo, void* userData);

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct TCOD_Random
    {
        [FieldOffset(0)]
        public TCOD_random_algo_t algorithm;
        [FieldOffset(0)]
        public TCOD_Random_MT_CMWC mt_cmwc;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct TCOD_value_t
    {
        [FieldOffset(0)]
        public byte b;
        [FieldOffset(0)]
        public sbyte c;
        [FieldOffset(0)]
        public int i;
        [FieldOffset(0)]
        public float f;
        [FieldOffset(0)]
        public sbyte* s;
        [FieldOffset(0)]
        public TCOD_ColorRGB col;
        [FieldOffset(0)]
        public TCOD_dice_t dice;
        [FieldOffset(0)]
        public TCOD_List* list;
        [FieldOffset(0)]
        public void* custom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ArrayData
    {
        public sbyte ndim;
        public int int_type;
        public _shape_e__FixedBuffer shape;
        public _strides_e__FixedBuffer strides;
        public byte* data;
        [InlineArray(5)] 
        public unsafe partial struct _shape_e__FixedBuffer
        {
            public nuint e0;
        }
        [InlineArray(5)] 
        public unsafe partial struct _strides_e__FixedBuffer
        {
            public nuint e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_BasicGraph2D
    {
        public TCOD_ArrayData cost;
        public int cardinal;
        public int diagonal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ColorRGB
    {
        public byte r;
        public byte g;
        public byte b;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ColorRGBA
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Console
    {
        public int w;
        public int h;
        public TCOD_ConsoleTile* tiles;
        public TCOD_bkgnd_flag_t bkgnd_flag;
        public TCOD_alignment_t alignment;
        public TCOD_ColorRGB fore;
        public TCOD_ColorRGB back;
        public byte has_key_color;
        public TCOD_ColorRGB key_color;
        public int elements;
        public void* userdata;
        public void* on_delete;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ConsoleTile
    {
        public int ch;
        public TCOD_ColorRGBA fg;
        public TCOD_ColorRGBA bg;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Context
    {
        public int type;
        public void* contextdata_;
        public void* c_destructor_;
        public void* c_present_;
        public void* c_pixel_to_tile_;
        public void* c_save_screenshot_;
        public void* c_get_sdl_window_;
        public void* c_get_sdl_renderer_;
        public void* c_accumulate_;
        public void* c_set_tileset_;
        public void* c_recommended_console_size_;
        public void* c_screen_capture_;
        public void* c_set_mouse_transform_;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ContextParams
    {
        public int tcod_version;
        public int window_x;
        public int window_y;
        public int pixel_width;
        public int pixel_height;
        public int columns;
        public int rows;
        public int renderer_type;
        public TCOD_Tileset* tileset;
        public int vsync;
        public int sdl_window_flags;
        public sbyte* window_title;
        public int argc;
        public sbyte** argv;
        public void* cli_output;
        public void* cli_userdata;
        public byte window_xy_defined;
        public TCOD_Console* console;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Dijkstra
    {
        public int diagonal_cost;
        public int width;
        public int height;
        public int nodes_max;
        public TCOD_Map* map;
        public delegate* unmanaged[Cdecl]<int, int, int, int, void*, float> func;
        public void* user_data;
        public uint* distances;
        public uint* nodes;
        public TCOD_List* path;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Frontier
    {
        public sbyte ndim;
        public int active_dist;
        public _active_index_e__FixedBuffer active_index;
        public TCOD_Heap heap;
        [InlineArray(4)] 
        public unsafe partial struct _active_index_e__FixedBuffer
        {
            public int e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Heap
    {
        public byte* heap;
        public int size;
        public int capacity;
        public nuint node_size;
        public nuint data_size;
        public nuint data_offset;
        public int priority_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Image
    {
        public int nb_mipmaps;
        public TCOD_mipmap_* mipmaps;
        public TCOD_ColorRGB key_color;
        public byte has_key_color;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_List
    {
        public void** array;
        public int fillSize;
        public int allocSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_LogMessage
    {
        public sbyte* message;
        public int level;
        public sbyte* source;
        public int lineno;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Map
    {
        public int width;
        public int height;
        public int nbcells;
        public TCOD_MapCell* cells;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_MapCell
    {
        public byte transparent;
        public byte walkable;
        public byte fov;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_MouseTransform
    {
        public double offset_x;
        public double offset_y;
        public double scale_x;
        public double scale_y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Noise
    {
        public int ndim;
        public _map_e__FixedBuffer map;
        public _buffer_e__FixedBuffer buffer;
        public float H;
        public float lacunarity;
        public _exponent_e__FixedBuffer exponent;
        public float* waveletTileData;
        public TCOD_Random* rand;
        public TCOD_noise_type_t noise_type;
        [InlineArray(256)] 
        public unsafe partial struct _map_e__FixedBuffer
        {
            public byte e0;
        }
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct _buffer_e__FixedBuffer
        {
            public float* e0;
            public float* e1;
            public float* e2;
            public float* e3;
            public float* e4;
            public float* e5;
            public float* e6;
            public float* e7;
            public float* e8;
            public float* e9;
            public float* e10;
            public float* e11;
            public float* e12;
            public float* e13;
            public float* e14;
            public float* e15;
            public float* e16;
            public float* e17;
            public float* e18;
            public float* e19;
            public float* e20;
            public float* e21;
            public float* e22;
            public float* e23;
            public float* e24;
            public float* e25;
            public float* e26;
            public float* e27;
            public float* e28;
            public float* e29;
            public float* e30;
            public float* e31;
            public float* e32;
            public float* e33;
            public float* e34;
            public float* e35;
            public float* e36;
            public float* e37;
            public float* e38;
            public float* e39;
            public float* e40;
            public float* e41;
            public float* e42;
            public float* e43;
            public float* e44;
            public float* e45;
            public float* e46;
            public float* e47;
            public float* e48;
            public float* e49;
            public float* e50;
            public float* e51;
            public float* e52;
            public float* e53;
            public float* e54;
            public float* e55;
            public float* e56;
            public float* e57;
            public float* e58;
            public float* e59;
            public float* e60;
            public float* e61;
            public float* e62;
            public float* e63;
            public float* e64;
            public float* e65;
            public float* e66;
            public float* e67;
            public float* e68;
            public float* e69;
            public float* e70;
            public float* e71;
            public float* e72;
            public float* e73;
            public float* e74;
            public float* e75;
            public float* e76;
            public float* e77;
            public float* e78;
            public float* e79;
            public float* e80;
            public float* e81;
            public float* e82;
            public float* e83;
            public float* e84;
            public float* e85;
            public float* e86;
            public float* e87;
            public float* e88;
            public float* e89;
            public float* e90;
            public float* e91;
            public float* e92;
            public float* e93;
            public float* e94;
            public float* e95;
            public float* e96;
            public float* e97;
            public float* e98;
            public float* e99;
            public float* e100;
            public float* e101;
            public float* e102;
            public float* e103;
            public float* e104;
            public float* e105;
            public float* e106;
            public float* e107;
            public float* e108;
            public float* e109;
            public float* e110;
            public float* e111;
            public float* e112;
            public float* e113;
            public float* e114;
            public float* e115;
            public float* e116;
            public float* e117;
            public float* e118;
            public float* e119;
            public float* e120;
            public float* e121;
            public float* e122;
            public float* e123;
            public float* e124;
            public float* e125;
            public float* e126;
            public float* e127;
            public float* e128;
            public float* e129;
            public float* e130;
            public float* e131;
            public float* e132;
            public float* e133;
            public float* e134;
            public float* e135;
            public float* e136;
            public float* e137;
            public float* e138;
            public float* e139;
            public float* e140;
            public float* e141;
            public float* e142;
            public float* e143;
            public float* e144;
            public float* e145;
            public float* e146;
            public float* e147;
            public float* e148;
            public float* e149;
            public float* e150;
            public float* e151;
            public float* e152;
            public float* e153;
            public float* e154;
            public float* e155;
            public float* e156;
            public float* e157;
            public float* e158;
            public float* e159;
            public float* e160;
            public float* e161;
            public float* e162;
            public float* e163;
            public float* e164;
            public float* e165;
            public float* e166;
            public float* e167;
            public float* e168;
            public float* e169;
            public float* e170;
            public float* e171;
            public float* e172;
            public float* e173;
            public float* e174;
            public float* e175;
            public float* e176;
            public float* e177;
            public float* e178;
            public float* e179;
            public float* e180;
            public float* e181;
            public float* e182;
            public float* e183;
            public float* e184;
            public float* e185;
            public float* e186;
            public float* e187;
            public float* e188;
            public float* e189;
            public float* e190;
            public float* e191;
            public float* e192;
            public float* e193;
            public float* e194;
            public float* e195;
            public float* e196;
            public float* e197;
            public float* e198;
            public float* e199;
            public float* e200;
            public float* e201;
            public float* e202;
            public float* e203;
            public float* e204;
            public float* e205;
            public float* e206;
            public float* e207;
            public float* e208;
            public float* e209;
            public float* e210;
            public float* e211;
            public float* e212;
            public float* e213;
            public float* e214;
            public float* e215;
            public float* e216;
            public float* e217;
            public float* e218;
            public float* e219;
            public float* e220;
            public float* e221;
            public float* e222;
            public float* e223;
            public float* e224;
            public float* e225;
            public float* e226;
            public float* e227;
            public float* e228;
            public float* e229;
            public float* e230;
            public float* e231;
            public float* e232;
            public float* e233;
            public float* e234;
            public float* e235;
            public float* e236;
            public float* e237;
            public float* e238;
            public float* e239;
            public float* e240;
            public float* e241;
            public float* e242;
            public float* e243;
            public float* e244;
            public float* e245;
            public float* e246;
            public float* e247;
            public float* e248;
            public float* e249;
            public float* e250;
            public float* e251;
            public float* e252;
            public float* e253;
            public float* e254;
            public float* e255;
        }
        [InlineArray(128)] 
        public unsafe partial struct _exponent_e__FixedBuffer
        {
            public float e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Parser
    {
        public TCOD_List* structs;
        public _customs_e__FixedBuffer customs;
        public byte fatal;
        public TCOD_List* props;
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct _customs_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;
            public void* e4;
            public void* e5;
            public void* e6;
            public void* e7;
            public void* e8;
            public void* e9;
            public void* e10;
            public void* e11;
            public void* e12;
            public void* e13;
            public void* e14;
            public void* e15;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ParserStruct
    {
        public sbyte* name;
        public TCOD_List* flags;
        public TCOD_List* props;
        public TCOD_List* lists;
        public TCOD_List* structs;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Path
    {
        public byte _opaque;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Pathfinder
    {
        public sbyte ndim;
        public _shape_e__FixedBuffer shape;
        public byte owns_distance;
        public byte owns_graph;
        public byte owns_traversal;
        public TCOD_ArrayData distance;
        public TCOD_BasicGraph2D graph;
        public TCOD_ArrayData traversal;
        public TCOD_Heap heap;
        [InlineArray(4)] 
        public unsafe partial struct _shape_e__FixedBuffer
        {
            public nuint e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_PrintParamsRGB
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public TCOD_ColorRGB* fg;
        public TCOD_ColorRGB* bg;
        public TCOD_bkgnd_flag_t flag;
        public TCOD_alignment_t alignment;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Random_MT_CMWC
    {
        public TCOD_random_algo_t algorithm;
        public TCOD_distribution_t distribution;
        public _mt_e__FixedBuffer mt;
        public int cur_mt;
        public _Q_e__FixedBuffer Q;
        public uint c;
        public int cur;
        [InlineArray(624)] 
        public unsafe partial struct _mt_e__FixedBuffer
        {
            public uint e0;
        }
        [InlineArray(4096)] 
        public unsafe partial struct _Q_e__FixedBuffer
        {
            public uint e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Text
    {
        public byte _opaque;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Tileset
    {
        public int tile_width;
        public int tile_height;
        public int tile_length;
        public int tiles_capacity;
        public int tiles_count;
        public TCOD_ColorRGBA* pixels;
        public int character_map_length;
        public int* character_map;
        public TCOD_TilesetObserver* observer_list;
        public int virtual_columns;
        public int ref_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_TilesetAtlasSDL2
    {
        public void* renderer;
        public void* texture;
        public TCOD_Tileset* tileset;
        public TCOD_TilesetObserver* observer;
        public int texture_columns;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_TilesetObserver
    {
        public TCOD_Tileset* tileset;
        public TCOD_TilesetObserver* next;
        public void* userdata;
        public void* on_observer_delete;
        public void* on_tile_changed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_ViewportOptions
    {
        public int tcod_version;
        public byte keep_aspect;
        public byte integer_scaling;
        public TCOD_ColorRGBA clear_color;
        public float align_x;
        public float align_y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_Zip
    {
        public byte _opaque;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_bresenham_data_t
    {
        public int stepx;
        public int stepy;
        public int e;
        public int deltax;
        public int deltay;
        public int origx;
        public int origy;
        public int destx;
        public int desty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_bsp_t
    {
        public TCOD_tree_t tree;
        public int x;
        public int y;
        public int w;
        public int h;
        public int position;
        public byte level;
        public byte horizontal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_dice_t
    {
        public int nb_rolls;
        public int nb_faces;
        public float multiplier;
        public float addsub;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_heightmap_t
    {
        public int w;
        public int h;
        public float* values;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_key_t
    {
        public TCOD_keycode_t vk;
        public sbyte c;
        public _text_e__FixedBuffer text;
        public byte pressed;
        public byte lalt;
        public byte lctrl;
        public byte lmeta;
        public byte ralt;
        public byte rctrl;
        public byte rmeta;
        public byte shift;
        [InlineArray(32)] 
        public unsafe partial struct _text_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_lex_t
    {
        public int file_line;
        public int token_type;
        public int token_int_val;
        public int token_idx;
        public float token_float_val;
        public sbyte* tok;
        public int toklen;
        public sbyte lastStringDelim;
        public sbyte* pos;
        public sbyte* buf;
        public sbyte* filename;
        public sbyte* last_javadoc_comment;
        public int nb_symbols;
        public int nb_keywords;
        public int flags;
        public _symbols_e__FixedBuffer symbols;
        public _keywords_e__FixedBuffer keywords;
        public sbyte* simple_comment;
        public sbyte* comment_start;
        public sbyte* comment_stop;
        public sbyte* javadoc_comment_start;
        public sbyte* stringDelim;
        public byte javadoc_read;
        public byte allocBuf;
        public byte is_savepoint;
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct _symbols_e__FixedBuffer
        {
            public sbyte* e0;
            public sbyte* e1;
            public sbyte* e2;
            public sbyte* e3;
            public sbyte* e4;
            public sbyte* e5;
            public sbyte* e6;
            public sbyte* e7;
            public sbyte* e8;
            public sbyte* e9;
            public sbyte* e10;
            public sbyte* e11;
            public sbyte* e12;
            public sbyte* e13;
            public sbyte* e14;
            public sbyte* e15;
            public sbyte* e16;
            public sbyte* e17;
            public sbyte* e18;
            public sbyte* e19;
            public sbyte* e20;
            public sbyte* e21;
            public sbyte* e22;
            public sbyte* e23;
            public sbyte* e24;
            public sbyte* e25;
            public sbyte* e26;
            public sbyte* e27;
            public sbyte* e28;
            public sbyte* e29;
            public sbyte* e30;
            public sbyte* e31;
            public sbyte* e32;
            public sbyte* e33;
            public sbyte* e34;
            public sbyte* e35;
            public sbyte* e36;
            public sbyte* e37;
            public sbyte* e38;
            public sbyte* e39;
            public sbyte* e40;
            public sbyte* e41;
            public sbyte* e42;
            public sbyte* e43;
            public sbyte* e44;
            public sbyte* e45;
            public sbyte* e46;
            public sbyte* e47;
            public sbyte* e48;
            public sbyte* e49;
            public sbyte* e50;
            public sbyte* e51;
            public sbyte* e52;
            public sbyte* e53;
            public sbyte* e54;
            public sbyte* e55;
            public sbyte* e56;
            public sbyte* e57;
            public sbyte* e58;
            public sbyte* e59;
            public sbyte* e60;
            public sbyte* e61;
            public sbyte* e62;
            public sbyte* e63;
            public sbyte* e64;
            public sbyte* e65;
            public sbyte* e66;
            public sbyte* e67;
            public sbyte* e68;
            public sbyte* e69;
            public sbyte* e70;
            public sbyte* e71;
            public sbyte* e72;
            public sbyte* e73;
            public sbyte* e74;
            public sbyte* e75;
            public sbyte* e76;
            public sbyte* e77;
            public sbyte* e78;
            public sbyte* e79;
            public sbyte* e80;
            public sbyte* e81;
            public sbyte* e82;
            public sbyte* e83;
            public sbyte* e84;
            public sbyte* e85;
            public sbyte* e86;
            public sbyte* e87;
            public sbyte* e88;
            public sbyte* e89;
            public sbyte* e90;
            public sbyte* e91;
            public sbyte* e92;
            public sbyte* e93;
            public sbyte* e94;
            public sbyte* e95;
            public sbyte* e96;
            public sbyte* e97;
            public sbyte* e98;
            public sbyte* e99;
        }
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct _keywords_e__FixedBuffer
        {
            public sbyte* e0;
            public sbyte* e1;
            public sbyte* e2;
            public sbyte* e3;
            public sbyte* e4;
            public sbyte* e5;
            public sbyte* e6;
            public sbyte* e7;
            public sbyte* e8;
            public sbyte* e9;
            public sbyte* e10;
            public sbyte* e11;
            public sbyte* e12;
            public sbyte* e13;
            public sbyte* e14;
            public sbyte* e15;
            public sbyte* e16;
            public sbyte* e17;
            public sbyte* e18;
            public sbyte* e19;
            public sbyte* e20;
            public sbyte* e21;
            public sbyte* e22;
            public sbyte* e23;
            public sbyte* e24;
            public sbyte* e25;
            public sbyte* e26;
            public sbyte* e27;
            public sbyte* e28;
            public sbyte* e29;
            public sbyte* e30;
            public sbyte* e31;
            public sbyte* e32;
            public sbyte* e33;
            public sbyte* e34;
            public sbyte* e35;
            public sbyte* e36;
            public sbyte* e37;
            public sbyte* e38;
            public sbyte* e39;
            public sbyte* e40;
            public sbyte* e41;
            public sbyte* e42;
            public sbyte* e43;
            public sbyte* e44;
            public sbyte* e45;
            public sbyte* e46;
            public sbyte* e47;
            public sbyte* e48;
            public sbyte* e49;
            public sbyte* e50;
            public sbyte* e51;
            public sbyte* e52;
            public sbyte* e53;
            public sbyte* e54;
            public sbyte* e55;
            public sbyte* e56;
            public sbyte* e57;
            public sbyte* e58;
            public sbyte* e59;
            public sbyte* e60;
            public sbyte* e61;
            public sbyte* e62;
            public sbyte* e63;
            public sbyte* e64;
            public sbyte* e65;
            public sbyte* e66;
            public sbyte* e67;
            public sbyte* e68;
            public sbyte* e69;
            public sbyte* e70;
            public sbyte* e71;
            public sbyte* e72;
            public sbyte* e73;
            public sbyte* e74;
            public sbyte* e75;
            public sbyte* e76;
            public sbyte* e77;
            public sbyte* e78;
            public sbyte* e79;
            public sbyte* e80;
            public sbyte* e81;
            public sbyte* e82;
            public sbyte* e83;
            public sbyte* e84;
            public sbyte* e85;
            public sbyte* e86;
            public sbyte* e87;
            public sbyte* e88;
            public sbyte* e89;
            public sbyte* e90;
            public sbyte* e91;
            public sbyte* e92;
            public sbyte* e93;
            public sbyte* e94;
            public sbyte* e95;
            public sbyte* e96;
            public sbyte* e97;
            public sbyte* e98;
            public sbyte* e99;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_mipmap_
    {
        public int width;
        public int height;
        public float fwidth;
        public float fheight;
        public TCOD_ColorRGB* buf;
        public byte dirty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_mouse_t
    {
        public int x;
        public int y;
        public int dx;
        public int dy;
        public int cx;
        public int cy;
        public int dcx;
        public int dcy;
        public byte lbutton;
        public byte rbutton;
        public byte mbutton;
        public byte lbutton_pressed;
        public byte rbutton_pressed;
        public byte mbutton_pressed;
        public byte wheel_up;
        public byte wheel_down;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_parser_listener_t
    {
        public void* new_struct;
        public void* new_flag;
        public void* new_property;
        public void* end_struct;
        public void* error;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TCOD_tree_t
    {
        public TCOD_tree_t* next;
        public TCOD_tree_t* father;
        public TCOD_tree_t* sons;
    }

    public static unsafe partial class LibTcodNative
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_contains(TCOD_bsp_t* node, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_bsp_delete(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_father(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_find_node(TCOD_bsp_t* node, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_is_leaf(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_left(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_new_with_size(int x, int y, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_bsp_remove_sons(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_bsp_resize(TCOD_bsp_t* node, int x, int y, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bsp_t* TCOD_bsp_right(TCOD_bsp_t* node);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_bsp_split_once(TCOD_bsp_t* node, byte horizontal, int position);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_bsp_split_recursive(TCOD_bsp_t* node, TCOD_Random* randomizer, int nb, int minHSize, int minVSize, float maxHRatio, float maxVRatio);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_traverse_in_order(TCOD_bsp_t* node, TCOD_bsp_callback_t listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_traverse_inverted_level_order(TCOD_bsp_t* node, TCOD_bsp_callback_t listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_traverse_level_order(TCOD_bsp_t* node, TCOD_bsp_callback_t listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_traverse_post_order(TCOD_bsp_t* node, TCOD_bsp_callback_t listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_bsp_traverse_pre_order(TCOD_bsp_t* node, TCOD_bsp_callback_t listener, void* userData);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_clear_error();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_close_library(void* arg0);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_HSV(float hue, float saturation, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_RGB(byte r, byte g, byte b);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_add(TCOD_ColorRGB c1, TCOD_ColorRGB c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_alpha_blend(TCOD_ColorRGBA* dst, TCOD_ColorRGBA* src);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_color_equals(TCOD_ColorRGB c1, TCOD_ColorRGB c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_gen_map(TCOD_ColorRGB* map, int nb_key, TCOD_ColorRGB* key_color, int* key_index);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_get_HSV(TCOD_ColorRGB color, float* hue, float* saturation, float* value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_color_get_hue(TCOD_ColorRGB color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_color_get_saturation(TCOD_ColorRGB color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_color_get_value(TCOD_ColorRGB color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_lerp(TCOD_ColorRGB c1, TCOD_ColorRGB c2, float coef);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_multiply(TCOD_ColorRGB c1, TCOD_ColorRGB c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_multiply_scalar(TCOD_ColorRGB c1, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_scale_HSV(TCOD_ColorRGB* color, float saturation_coef, float value_coef);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_set_HSV(TCOD_ColorRGB* color, float hue, float saturation, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_set_hue(TCOD_ColorRGB* color, float hue);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_set_saturation(TCOD_ColorRGB* color, float saturation);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_set_value(TCOD_ColorRGB* color, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_color_shift_hue(TCOD_ColorRGB* color, float shift);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_color_subtract(TCOD_ColorRGB c1, TCOD_ColorRGB c2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_condition_broadcast(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_condition_delete(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_condition_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_condition_signal(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_condition_wait(void* sem, void* mut);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_blit(TCOD_Console* src, int xSrc, int ySrc, int wSrc, int hSrc, TCOD_Console* dst, int xDst, int yDst, float foreground_alpha, float background_alpha);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_blit_key_color(TCOD_Console* src, int xSrc, int ySrc, int wSrc, int hSrc, TCOD_Console* dst, int xDst, int yDst, float foreground_alpha, float background_alpha, TCOD_ColorRGB* key_color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_key_t TCOD_console_check_for_keypress(int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_clear(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_credits();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_credits_render(int x, int y, byte alpha);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_credits_render_ex(TCOD_Console* console, int x, int y, byte alpha, float delta_time);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_credits_reset();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_delete(TCOD_Console* console);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_disable_keyboard_repeat();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_draw_frame_rgb(TCOD_Console* con, int x, int y, int width, int height, int* decoration, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, byte clear);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_draw_rect_rgb(TCOD_Console* console, int x, int y, int width, int height, int ch, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_flush();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_flush_ex(TCOD_Console* console, TCOD_ViewportOptions* viewport);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_console_from_file(sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_console_from_file([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_console_from_xp(sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_console_from_xp([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_alignment_t TCOD_console_get_alignment(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_bkgnd_flag_t TCOD_console_get_background_flag(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_char(TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_console_get_char_background(TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_console_get_char_foreground(TCOD_Console* con, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_console_get_default_background(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_console_get_default_foreground(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_get_fade();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_console_get_fading_color();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_height(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_height_rect_n(TCOD_Console* console, int x, int y, int width, int height, nuint n, sbyte* str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_height_rect_n(TCOD_Console* console, int x, int y, int width, int height, nuint n, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_height_rect_wn(int width, nuint n, sbyte* str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_height_rect_wn(int width, nuint n, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_get_width(TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_has_mouse_focus();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_hline(TCOD_Console* con, int x, int y, int l, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_init_root(int w, int h, sbyte* title, byte fullscreen, TCOD_renderer_t renderer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_init_root(int w, int h, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, byte fullscreen, TCOD_renderer_t renderer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_init_root_(int w, int h, sbyte* title, byte fullscreen, TCOD_renderer_t renderer, byte vsync);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_init_root_(int w, int h, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, byte fullscreen, TCOD_renderer_t renderer, byte vsync);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_is_active();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_is_fullscreen();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_is_key_pressed(TCOD_keycode_t key);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_is_window_closed();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_console_list_from_xp(sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_console_list_from_xp([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_list_save_xp(TCOD_List* console_list, sbyte* filename, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_list_save_xp(TCOD_List* console_list, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_apf(TCOD_Console* con, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_apf(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_asc(TCOD_Console* con, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_asc(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_xp(TCOD_Console* con, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_load_xp(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_map_ascii_code_to_font(int asciiCode, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_map_ascii_codes_to_font(int asciiCode, int nbCodes, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_map_string_to_font(sbyte* s, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_map_string_to_font([MarshalAs(UnmanagedType.LPUTF8Str)] string s, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_map_string_to_font_utf(char* s, int fontCharX, int fontCharY);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_console_new(int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_printn(TCOD_Console* console, int x, int y, nuint n, sbyte* str, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_printn(TCOD_Console* console, int x, int y, nuint n, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_printn_frame(TCOD_Console* console, int x, int y, int width, int height, nuint n, sbyte* title, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, byte clear);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_printn_frame(TCOD_Console* console, int x, int y, int width, int height, nuint n, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, byte clear);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_printn_rect(TCOD_Console* console, int x, int y, int width, int height, nuint n, sbyte* str, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_printn_rect(TCOD_Console* console, int x, int y, int width, int height, nuint n, [MarshalAs(UnmanagedType.LPUTF8Str)] string str, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_put_char(TCOD_Console* con, int x, int y, int c, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_put_char_ex(TCOD_Console* con, int x, int y, int c, TCOD_ColorRGB fore, TCOD_ColorRGB back);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_put_rgb(TCOD_Console* console, int x, int y, int ch, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_rect(TCOD_Console* con, int x, int y, int rw, int rh, byte clear, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_resize_(TCOD_Console* console, int width, int height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_apf(TCOD_Console* con, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_apf(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_asc(TCOD_Console* con, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_asc(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_xp(TCOD_Console* con, sbyte* filename, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_console_save_xp(TCOD_Console* con, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_alignment(TCOD_Console* con, TCOD_alignment_t alignment);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_background_flag(TCOD_Console* con, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_char(TCOD_Console* con, int x, int y, int c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_char_background(TCOD_Console* con, int x, int y, TCOD_ColorRGB col, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_char_foreground(TCOD_Console* con, int x, int y, TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_color_control(TCOD_colctrl_t con, TCOD_ColorRGB fore, TCOD_ColorRGB back);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_set_custom_font(sbyte* fontFile, int flags, int nb_char_horiz, int nb_char_vertic);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_set_custom_font([MarshalAs(UnmanagedType.LPUTF8Str)] string fontFile, int flags, int nb_char_horiz, int nb_char_vertic);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_default_background(TCOD_Console* con, TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_default_foreground(TCOD_Console* con, TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_dirty(int x, int y, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_fade(byte val, TCOD_ColorRGB fade_color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_fullscreen(byte fullscreen);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_key_color(TCOD_Console* con, TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_keyboard_repeat(int initial_delay, int interval);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_window_title(sbyte* title);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_set_window_title([MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_console_vline(TCOD_Console* con, int x, int y, int l, TCOD_bkgnd_flag_t flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_vprintf(TCOD_Console* console, int x, int y, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment, sbyte* fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_console_vprintf(TCOD_Console* console, int x, int y, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_vprintf_rect(TCOD_Console* console, int x, int y, int width, int height, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment, sbyte* fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_console_vprintf_rect(TCOD_Console* console, int x, int y, int width, int height, TCOD_ColorRGB* fg, TCOD_ColorRGB* bg, TCOD_bkgnd_flag_t flag, TCOD_alignment_t alignment, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_key_t TCOD_console_wait_for_keypress(byte flush);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_change_tileset(TCOD_Context* self, TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_convert_event_coordinates(TCOD_Context* context, void* @event);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_context_delete(TCOD_Context* renderer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_context_get_renderer_type(TCOD_Context* context);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_context_get_sdl_renderer(TCOD_Context* context);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_context_get_sdl_window(TCOD_Context* context);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_new(TCOD_ContextParams* @params, TCOD_Context** @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Context* TCOD_context_new_();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_present(TCOD_Context* context, TCOD_Console* console, TCOD_ViewportOptions* viewport);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_recommended_console_size(TCOD_Context* context, float magnification, int* columns, int* rows);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_save_screenshot(TCOD_Context* context, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_save_screenshot(TCOD_Context* context, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_screen_capture(TCOD_Context* context, TCOD_ColorRGBA* out_pixels, int* width, int* height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGBA* TCOD_context_screen_capture_alloc(TCOD_Context* context, int* width, int* height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_d(TCOD_Context* context, double* x, double* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_screen_pixel_to_tile_i(TCOD_Context* context, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_context_set_mouse_transform(TCOD_Context* context, TCOD_MouseTransform* transform);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_dijkstra_compute(TCOD_Dijkstra* dijkstra, int root_x, int root_y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_dijkstra_delete(TCOD_Dijkstra* dijkstra);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_dijkstra_get(TCOD_Dijkstra* path, int index, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_dijkstra_get_distance(TCOD_Dijkstra* dijkstra, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_dijkstra_is_empty(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Dijkstra* TCOD_dijkstra_new(TCOD_Map* map, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Dijkstra* TCOD_dijkstra_new_using_function(int map_width, int map_height, TCOD_path_func_t func, void* user_data, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_dijkstra_path_set(TCOD_Dijkstra* dijkstra, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_dijkstra_path_walk(TCOD_Dijkstra* dijkstra, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_dijkstra_reverse(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_dijkstra_size(TCOD_Dijkstra* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_frontier_clear(TCOD_Frontier* frontier);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_frontier_delete(TCOD_Frontier* frontier);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Frontier* TCOD_frontier_new(int ndim);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_frontier_pop(TCOD_Frontier* frontier);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_frontier_push(TCOD_Frontier* frontier, int* index, int dist, int heuristic);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_frontier_size(TCOD_Frontier* frontier);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_get_default_tileset();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_get_error();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_get_function_address(void* library, sbyte* function_name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_get_function_address(void* library, [MarshalAs(UnmanagedType.LPUTF8Str)] string function_name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heap_clear(TCOD_Heap* heap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_heap_init(TCOD_Heap* heap, nuint data_size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heap_uninit(TCOD_Heap* heap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_add(TCOD_heightmap_t* hm, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_add_fbm(TCOD_heightmap_t* hm, TCOD_Noise* noise, float mul_x, float mul_y, float add_x, float add_y, float octaves, float delta, float scale);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_add_hill(TCOD_heightmap_t* hm, float hx, float hy, float h_radius, float h_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_add_hm(TCOD_heightmap_t* hm1, TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_add_voronoi(TCOD_heightmap_t* hm, int nbPoints, int nbCoef, float* coef, TCOD_Random* rnd);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_clamp(TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_clear(TCOD_heightmap_t* hm);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_copy(TCOD_heightmap_t* hm_source, TCOD_heightmap_t* hm_dest);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_heightmap_count_cells(TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_delete(TCOD_heightmap_t* hm);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_dig_bezier(TCOD_heightmap_t* hm, int* px, int* py, float startRadius, float startDepth, float endRadius, float endDepth);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_dig_hill(TCOD_heightmap_t* hm, float hx, float hy, float h_radius, float h_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_heightmap_get_interpolated_value(TCOD_heightmap_t* hm, float x, float y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_get_minmax(TCOD_heightmap_t* heightmap, float* min_out, float* max_out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_get_normal(TCOD_heightmap_t* hm, float x, float y, float* n, float waterLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_heightmap_get_slope(TCOD_heightmap_t* hm, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_heightmap_get_value(TCOD_heightmap_t* heightmap, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_heightmap_has_land_on_border(TCOD_heightmap_t* hm, float waterLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_heightmap_in_bounds(TCOD_heightmap_t* heightmap, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_heightmap_is_valid(TCOD_heightmap_t* heightmap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_islandify(TCOD_heightmap_t* hm, float seaLevel, TCOD_Random* rnd);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_kernel_transform(TCOD_heightmap_t* hm, int kernel_size, int* dx, int* dy, float* weight, float minLevel, float maxLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_kernel_transform_out(TCOD_heightmap_t* hm_src, TCOD_heightmap_t* hm_dst, int kernel_size, int* dx, int* dy, float* weight, byte* mask);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_lerp_hm(TCOD_heightmap_t* hm1, TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out, float coef);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_mid_point_displacement(TCOD_heightmap_t* hm, TCOD_Random* rnd, float roughness);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_multiply_hm(TCOD_heightmap_t* hm1, TCOD_heightmap_t* hm2, TCOD_heightmap_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_heightmap_t* TCOD_heightmap_new(int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_normalize(TCOD_heightmap_t* hm, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_rain_erosion(TCOD_heightmap_t* hm, int nbDrops, float erosionCoef, float sedimentationCoef, TCOD_Random* rnd);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_scale(TCOD_heightmap_t* hm, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_scale_fbm(TCOD_heightmap_t* hm, TCOD_Noise* noise, float mul_x, float mul_y, float add_x, float add_y, float octaves, float delta, float scale);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_set_value(TCOD_heightmap_t* heightmap, int x, int y, float value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_heightmap_threshold_mask(TCOD_heightmap_t* hm, byte* mask, float minLevel, float maxLevel);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_blit(TCOD_Image* image, TCOD_Console* console, float x, float y, TCOD_bkgnd_flag_t bkgnd_flag, float scale_x, float scale_y, float angle);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_blit_2x(TCOD_Image* image, TCOD_Console* dest, int dx, int dy, int sx, int sy, int w, int h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_blit_rect(TCOD_Image* image, TCOD_Console* console, int x, int y, int w, int h, TCOD_bkgnd_flag_t bkgnd_flag);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_clear(TCOD_Image* image, TCOD_ColorRGB color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_delete(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Image* TCOD_image_from_console(TCOD_Console* console);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_image_get_alpha(TCOD_Image* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_image_get_mipmap_pixel(TCOD_Image* image, float x0, float y0, float x1, float y1);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_image_get_pixel(TCOD_Image* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_get_size(TCOD_Image* image, int* w, int* h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_hflip(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_invert(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_image_is_pixel_transparent(TCOD_Image* image, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Image* TCOD_image_load(sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Image* TCOD_image_load([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Image* TCOD_image_new(int width, int height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_put_pixel(TCOD_Image* image, int x, int y, TCOD_ColorRGB col);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_refresh_console(TCOD_Image* image, TCOD_Console* console);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_rotate90(TCOD_Image* image, int numRotations);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_image_save(TCOD_Image* image, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_image_save(TCOD_Image* image, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_scale(TCOD_Image* image, int new_w, int new_h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_set_key_color(TCOD_Image* image, TCOD_ColorRGB key_color);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_image_vflip(TCOD_Image* image);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_lex_delete(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_lex_expect_token_type(TCOD_lex_t* lex, int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_lex_expect_token_value(TCOD_lex_t* lex, int token_type, sbyte* token_value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_lex_expect_token_value(TCOD_lex_t* lex, int token_type, [MarshalAs(UnmanagedType.LPUTF8Str)] string token_value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_lex_get_last_javadoc(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_lex_get_token_name(int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_lex_hextoint(sbyte c);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_lex_t* TCOD_lex_new(sbyte** symbols, sbyte** keywords, sbyte* simpleComment, sbyte* commentStart, sbyte* commentStop, sbyte* javadocCommentStart, sbyte* stringDelim, int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_lex_t* TCOD_lex_new(sbyte** symbols, sbyte** keywords, [MarshalAs(UnmanagedType.LPUTF8Str)] string simpleComment, [MarshalAs(UnmanagedType.LPUTF8Str)] string commentStart, [MarshalAs(UnmanagedType.LPUTF8Str)] string commentStop, [MarshalAs(UnmanagedType.LPUTF8Str)] string javadocCommentStart, [MarshalAs(UnmanagedType.LPUTF8Str)] string stringDelim, int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_lex_t* TCOD_lex_new_intern();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_lex_parse(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_lex_parse_until_token_type(TCOD_lex_t* lex, int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_lex_parse_until_token_value(TCOD_lex_t* lex, sbyte* token_value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_lex_parse_until_token_value(TCOD_lex_t* lex, [MarshalAs(UnmanagedType.LPUTF8Str)] string token_value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_lex_restore(TCOD_lex_t* lex, TCOD_lex_t* savepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_lex_savepoint(TCOD_lex_t* lex, TCOD_lex_t* savepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_lex_set_data_buffer(TCOD_lex_t* lex, sbyte* dat);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_lex_set_data_buffer(TCOD_lex_t* lex, [MarshalAs(UnmanagedType.LPUTF8Str)] string dat);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_lex_set_data_file(TCOD_lex_t* lex, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_lex_set_data_file(TCOD_lex_t* lex, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_line(int xFrom, int yFrom, int xTo, int yTo, TCOD_line_listener_t listener);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_line_init(int xFrom, int yFrom, int xTo, int yTo);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_line_init_mt(int xFrom, int yFrom, int xTo, int yTo, TCOD_bresenham_data_t* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_line_mt(int xFrom, int yFrom, int xTo, int yTo, TCOD_line_listener_t listener, TCOD_bresenham_data_t* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_line_step(int* xCur, int* yCur);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_line_step_mt(int* xCur, int* yCur, TCOD_bresenham_data_t* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_add_all(TCOD_List* l, TCOD_List* l2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_list_allocate(int nb_elements);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** TCOD_list_begin(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_clear(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_clear_and_delete(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_list_contains(TCOD_List* l, void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_delete(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_list_duplicate(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** TCOD_list_end(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_list_get(TCOD_List* l, int idx);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** TCOD_list_insert_before(TCOD_List* l, void* elt, int before);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_list_is_empty(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_list_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_list_peek(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_list_pop(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_push(TCOD_List* l, void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_remove(TCOD_List* l, void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_remove_fast(TCOD_List* l, void* elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** TCOD_list_remove_iterator(TCOD_List* l, void** elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void** TCOD_list_remove_iterator_fast(TCOD_List* l, void** elt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_reverse(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_list_set(TCOD_List* l, void* elt, int idx);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_list_size(TCOD_List* l);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_load_bdf(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_load_bdf([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_load_bdf_memory(int size, byte* buffer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_load_library(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_load_library([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_load_truetype_font_(sbyte* path, int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_load_truetype_font_([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_load_xp(sbyte* path, int n, TCOD_Console** @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_load_xp([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int n, TCOD_Console** @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_load_xp_from_memory(int n_data, byte* data, int n_out, TCOD_Console** @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_log_verbose_(sbyte* msg, int level, sbyte* source, int line);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_log_verbose_([MarshalAs(UnmanagedType.LPUTF8Str)] string msg, int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string source, int line);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_map_clear(TCOD_Map* map, byte transparent, byte walkable);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_map_compute_fov(TCOD_Map* map, int pov_x, int pov_y, int max_radius, byte light_walls, TCOD_fov_algorithm_t algo);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_map_copy(TCOD_Map* source, TCOD_Map* dest);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_map_delete(TCOD_Map* map);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_map_get_height(TCOD_Map* map);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_map_get_nb_cells(TCOD_Map* map);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_map_get_width(TCOD_Map* map);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_map_is_in_fov(TCOD_Map* map, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_map_is_transparent(TCOD_Map* map, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_map_is_walkable(TCOD_Map* map, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Map* TCOD_map_new(int width, int height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_map_set_in_fov(TCOD_Map* map, int x, int y, byte fov);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_map_set_properties(TCOD_Map* map, int x, int y, byte is_transparent, byte is_walkable);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_minheap_heapify(TCOD_Heap* minheap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_minheap_pop(TCOD_Heap* minheap, void* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_minheap_push(TCOD_Heap* minheap, int priority, void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_mouse_t TCOD_mouse_get_status();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mouse_includes_touch(byte enable);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_mouse_is_cursor_visible();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mouse_move(int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mouse_show_cursor(byte visible);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mutex_delete(void* mut);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mutex_in(void* mut);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_mutex_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_mutex_out(void* mut);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_namegen_destroy();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_namegen_generate(sbyte* name, byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_namegen_generate([MarshalAs(UnmanagedType.LPUTF8Str)] string name, byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_namegen_generate_custom(sbyte* name, sbyte* rule, byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_namegen_generate_custom([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string rule, byte allocate);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_namegen_get_sets();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_namegen_parse(sbyte* filename, TCOD_Random* random);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_namegen_parse([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, TCOD_Random* random);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_noise_delete(TCOD_Noise* noise);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get(TCOD_Noise* noise, float* f);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get_ex(TCOD_Noise* noise, float* f, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get_fbm(TCOD_Noise* noise, float* f, float octaves);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get_fbm_ex(TCOD_Noise* noise, float* f, float octaves, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_noise_get_fbm_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, float octaves, int n, float* x, float* y, float* z, float* w, float* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get_turbulence(TCOD_Noise* noise, float* f, float octaves);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_noise_get_turbulence_ex(TCOD_Noise* noise, float* f, float octaves, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_noise_get_turbulence_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, float octaves, int n, float* x, float* y, float* z, float* w, float* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_noise_get_vectorized(TCOD_Noise* noise, TCOD_noise_type_t type, int n, float* x, float* y, float* z, float* w, float* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Noise* TCOD_noise_new(int dimensions, float hurst, float lacunarity, TCOD_Random* random);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_noise_set_type(TCOD_Noise* noise, TCOD_noise_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_bool_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_char_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_color_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_dice_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_float_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_integer_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_property_value(TCOD_Parser* parser, TCOD_ParserStruct* def, sbyte* propname, byte list);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_property_value(TCOD_Parser* parser, TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string propname, byte list);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_string_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_t TCOD_parse_value_list_value(TCOD_ParserStruct* def, int list_num);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_parser_delete(TCOD_Parser* parser);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_parser_get_bool_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_parser_get_bool_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_parser_get_char_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_parser_get_char_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_parser_get_color_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_parser_get_color_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_parser_get_custom_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_parser_get_custom_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_dice_t TCOD_parser_get_dice_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_dice_t TCOD_parser_get_dice_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_parser_get_dice_property_py(TCOD_Parser* parser, sbyte* name, TCOD_dice_t* dice);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_parser_get_dice_property_py(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, TCOD_dice_t* dice);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_parser_get_float_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_parser_get_float_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_parser_get_int_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_parser_get_int_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_parser_get_list_property(TCOD_Parser* parser, sbyte* name, TCOD_value_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_parser_get_list_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, TCOD_value_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_parser_get_string_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_parser_get_string_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_parser_has_property(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_parser_has_property(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Parser* TCOD_parser_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_type_t TCOD_parser_new_custom_type(TCOD_Parser* parser, void* custom_type_parser);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ParserStruct* TCOD_parser_new_struct(TCOD_Parser* parser, sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ParserStruct* TCOD_parser_new_struct(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_parser_run(TCOD_Parser* parser, sbyte* filename, TCOD_parser_listener_t* listener);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_parser_run(TCOD_Parser* parser, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, TCOD_parser_listener_t* listener);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_path_compute(TCOD_Path* path, int ox, int oy, int dx, int dy);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_path_delete(TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_path_get(TCOD_Path* path, int index, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_path_get_destination(TCOD_Path* path, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_path_get_origin(TCOD_Path* path, int* x, int* y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_path_is_empty(TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Path* TCOD_path_new_using_function(int map_width, int map_height, TCOD_path_func_t func, void* user_data, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Path* TCOD_path_new_using_map(TCOD_Map* map, float diagonalCost);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_path_reverse(TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_path_size(TCOD_Path* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_path_walk(TCOD_Path* path, int* x, int* y, byte recalculate_when_needed);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_pf_compute(TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_pf_compute_step(TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_pf_delete(TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Pathfinder* TCOD_pf_new(int ndim, nuint* shape);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_pf_recompile(TCOD_Pathfinder* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_pf_set_distance_pointer(TCOD_Pathfinder* path, void* data, int int_type, nuint* strides);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_pf_set_graph2d_pointer(TCOD_Pathfinder* path, void* data, int int_type, nuint* strides, int cardinal, int diagonal);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_pf_set_traversal_pointer(TCOD_Pathfinder* path, void* data, int int_type, nuint* strides);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_printn_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, int n, sbyte* str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_printn_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, int n, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_quit();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_random_delete(TCOD_Random* mersenne);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_dice_t TCOD_random_dice_new(sbyte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_dice_t TCOD_random_dice_new([MarshalAs(UnmanagedType.LPUTF8Str)] string s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_random_dice_roll(TCOD_Random* mersenne, TCOD_dice_t dice);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_random_dice_roll_s(TCOD_Random* mersenne, sbyte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_random_dice_roll_s(TCOD_Random* mersenne, [MarshalAs(UnmanagedType.LPUTF8Str)] string s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TCOD_random_get_double(TCOD_Random* mersenne, double min, double max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TCOD_random_get_double_mean(TCOD_Random* mersenne, double min, double max, double mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_random_get_float(TCOD_Random* mersenne, float min, float max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_random_get_float_mean(TCOD_Random* mersenne, float min, float max, float mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Random* TCOD_random_get_instance();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_random_get_int(TCOD_Random* mersenne, int min, int max);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_random_get_int_mean(TCOD_Random* mersenne, int min, int max, int mean);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Random* TCOD_random_new(TCOD_random_algo_t algo);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Random* TCOD_random_new_from_seed(TCOD_random_algo_t algo, uint seed);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_random_restore(TCOD_Random* mersenne, TCOD_Random* backup);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Random* TCOD_random_save(TCOD_Random* mersenne);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_random_set_distribution(TCOD_Random* mersenne, TCOD_distribution_t distribution);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Context* TCOD_renderer_init_sdl2(int x, int y, int width, int height, sbyte* title, int window_flags, int vsync, TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Context* TCOD_renderer_init_sdl2(int x, int y, int width, int height, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, int window_flags, int vsync, TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong TCOD_rng_splitmix64_next(ulong* state);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_save_xp(int n, TCOD_Console** consoles, sbyte* path, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_save_xp(int n, TCOD_Console** consoles, [MarshalAs(UnmanagedType.LPUTF8Str)] string path, int compress_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_save_xp_to_memory(int n_consoles, TCOD_Console** consoles, int n_out, byte* @out, int compression_level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sdl2_atlas_delete(TCOD_TilesetAtlasSDL2* atlas);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_TilesetAtlasSDL2* TCOD_sdl2_atlas_new(void* renderer, TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_sdl2_render_texture(TCOD_TilesetAtlasSDL2* atlas, TCOD_Console* console, TCOD_Console* cache, void* target);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_sdl2_render_texture_setup(TCOD_TilesetAtlasSDL2* atlas, TCOD_Console* console, TCOD_Console** cache, void** target);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_semaphore_delete(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_semaphore_lock(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_semaphore_new(int initVal);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_semaphore_unlock(void* sem);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_set_default_tileset(TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_set_error(sbyte* msg);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_set_error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_set_log_callback(TCOD_LoggingCallback callback, void* userdata);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_set_log_level(int level);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_strcasecmp(sbyte* s1, sbyte* s2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_strcasecmp([MarshalAs(UnmanagedType.LPUTF8Str)] string s1, [MarshalAs(UnmanagedType.LPUTF8Str)] string s2);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_strdup(sbyte* s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_strdup([MarshalAs(UnmanagedType.LPUTF8Str)] string s);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_strncasecmp(sbyte* s1, sbyte* s2, nuint n);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_strncasecmp([MarshalAs(UnmanagedType.LPUTF8Str)] string s1, [MarshalAs(UnmanagedType.LPUTF8Str)] string s2, nuint n);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_flag(TCOD_ParserStruct* def, sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_flag(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_list_property(TCOD_ParserStruct* def, sbyte* name, TCOD_value_type_t type, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_list_property(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, TCOD_value_type_t type, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_property(TCOD_ParserStruct* def, sbyte* name, TCOD_value_type_t type, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_property(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, TCOD_value_type_t type, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_structure(TCOD_ParserStruct* def, TCOD_ParserStruct* sub_structure);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_value_list(TCOD_ParserStruct* def, sbyte* name, sbyte** value_list, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_value_list(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, sbyte** value_list, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_value_list_sized(TCOD_ParserStruct* def, sbyte* name, sbyte** value_list, int size, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_struct_add_value_list_sized(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, sbyte** value_list, int size, byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_struct_get_name(TCOD_ParserStruct* def);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_type_t TCOD_struct_get_type(TCOD_ParserStruct* def, sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_value_type_t TCOD_struct_get_type(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_struct_is_mandatory(TCOD_ParserStruct* def, sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_struct_is_mandatory(TCOD_ParserStruct* def, [MarshalAs(UnmanagedType.LPUTF8Str)] string propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_sys_accumulate_console(TCOD_Console* console);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_sys_accumulate_console_(TCOD_Console* console, void* viewport);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_event_t TCOD_sys_check_for_event(int eventMask, TCOD_key_t* key, TCOD_mouse_t* mouse);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_sys_clipboard_get();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_clipboard_set(sbyte* value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_clipboard_set([MarshalAs(UnmanagedType.LPUTF8Str)] string value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_create_directory(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_create_directory([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_delete_directory(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_delete_directory([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_delete_file(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_delete_file([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint TCOD_sys_elapsed_milli();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_sys_elapsed_seconds();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_force_fullscreen_resolution(int width, int height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_sys_get_SDL_renderer();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_sys_get_SDL_window();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_get_char_size(int* w, int* h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_sys_get_current_resolution(int* w, int* h);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_sys_get_directory_content(sbyte* path, sbyte* pattern);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_List* TCOD_sys_get_directory_content([MarshalAs(UnmanagedType.LPUTF8Str)] string path, [MarshalAs(UnmanagedType.LPUTF8Str)] string pattern);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_sys_get_fps();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_get_fullscreen_offsets(int* offset_x, int* offset_y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_sys_get_internal_console();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Context* TCOD_sys_get_internal_context();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_sys_get_last_frame_length();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_sys_get_num_cores();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_renderer_t TCOD_sys_get_renderer();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_sys_get_sdl_renderer();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_sys_get_sdl_window();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_is_directory(sbyte* path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_is_directory([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_event_t TCOD_sys_process_key_event(void* @in, TCOD_key_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_event_t TCOD_sys_process_mouse_event(void* @in, TCOD_mouse_t* @out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_read_file(sbyte* filename, byte** buf, nuint* size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_read_file([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, byte** buf, nuint* size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_register_SDL_renderer(void* renderer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_save_screenshot(sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_save_screenshot([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_set_fps(int val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_sys_set_renderer(TCOD_renderer_t renderer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_shutdown();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_sleep_milli(uint val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_startup();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_sys_update_char(int asciiCode, int font_x, int font_y, TCOD_Image* img, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_event_t TCOD_sys_wait_for_event(int eventMask, TCOD_key_t* key, TCOD_mouse_t* mouse, byte flush);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_write_file(sbyte* filename, byte* buf, uint size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_sys_write_file([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, byte* buf, uint size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_delete(TCOD_Text* txt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_text_get(TCOD_Text* txt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Text* TCOD_text_init(int x, int y, int w, int h, int max_chars);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Text* TCOD_text_init2(int w, int h, int max_chars);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_render(TCOD_Text* txt, TCOD_Console* con);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_reset(TCOD_Text* txt);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_set_colors(TCOD_Text* txt, TCOD_ColorRGB fore, TCOD_ColorRGB back, float back_transparency);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_set_pos(TCOD_Text* txt, int x, int y);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_set_properties(TCOD_Text* txt, int cursor_char, int blink_interval, sbyte* prompt, int tab_size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_text_set_properties(TCOD_Text* txt, int cursor_char, int blink_interval, [MarshalAs(UnmanagedType.LPUTF8Str)] string prompt, int tab_size);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte TCOD_text_update(TCOD_Text* txt, TCOD_key_t key);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_thread_delete(void* th);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void* TCOD_thread_new(void* func, void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_thread_wait(void* th);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_tileset_assign_tile(TCOD_Tileset* tileset, int tile_id, int codepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_tileset_delete(TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGBA* TCOD_tileset_get_tile(TCOD_Tileset* tileset, int codepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_get_tile_(TCOD_Tileset* tileset, int codepoint, TCOD_ColorRGBA* buffer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_tileset_get_tile_height_(TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_tileset_get_tile_width_(TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_load(sbyte* filename, int columns, int rows, int n, int* charmap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_load([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int columns, int rows, int n, int* charmap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_load_fallback_font_(int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_load_mem(nuint buffer_length, byte* buffer, int columns, int rows, int n, int* charmap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_load_raw(int width, int height, TCOD_ColorRGBA* pixels, int columns, int rows, int n, int* charmap);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_load_truetype_(sbyte* path, int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_load_truetype_([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Tileset* TCOD_tileset_new(int tile_width, int tile_height);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_tileset_notify_tile_changed(TCOD_Tileset* tileset, int tile_id);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_tileset_observer_delete(TCOD_TilesetObserver* observer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_TilesetObserver* TCOD_tileset_observer_new(TCOD_Tileset* tileset);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_render_to_surface(TCOD_Tileset* tileset, TCOD_Console* console, TCOD_Console** cache, void** surface_out);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_reserve(TCOD_Tileset* tileset, int desired);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Error TCOD_tileset_set_tile_(TCOD_Tileset* tileset, int codepoint, TCOD_ColorRGBA* buffer);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_tree_add_son(TCOD_tree_t* node, TCOD_tree_t* son);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_tree_t* TCOD_tree_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_viewport_delete(TCOD_ViewportOptions* viewport);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ViewportOptions* TCOD_viewport_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_vprintf_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, sbyte* fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_vprintf_rgb(TCOD_Console* console, TCOD_PrintParamsRGB @params, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, void* args);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_delete(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte TCOD_zip_get_char(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_ColorRGB TCOD_zip_get_color(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Console* TCOD_zip_get_console(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint TCOD_zip_get_current_bytes(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_get_data(TCOD_Zip* zip, int nbBytes, void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern float TCOD_zip_get_float(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Image* TCOD_zip_get_image(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_get_int(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Random* TCOD_zip_get_random(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint TCOD_zip_get_remaining_bytes(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte* TCOD_zip_get_string(TCOD_Zip* zip);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_load_from_file(TCOD_Zip* zip, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_load_from_file(TCOD_Zip* zip, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern TCOD_Zip* TCOD_zip_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_char(TCOD_Zip* zip, sbyte val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_color(TCOD_Zip* zip, TCOD_ColorRGB val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_console(TCOD_Zip* zip, TCOD_Console* val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_data(TCOD_Zip* zip, int nbBytes, void* data);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_float(TCOD_Zip* zip, float val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_image(TCOD_Zip* zip, TCOD_Image* val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_int(TCOD_Zip* zip, int val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_random(TCOD_Zip* zip, TCOD_Random* val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_string(TCOD_Zip* zip, sbyte* val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_put_string(TCOD_Zip* zip, [MarshalAs(UnmanagedType.LPUTF8Str)] string val);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_save_to_file(TCOD_Zip* zip, sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCOD_zip_save_to_file(TCOD_Zip* zip, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TCOD_zip_skip_bytes(TCOD_Zip* zip, uint nbBytes);

    }
}
