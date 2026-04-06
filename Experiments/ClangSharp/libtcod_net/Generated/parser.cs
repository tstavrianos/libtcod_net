using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public enum TCOD_value_type_t
    {
        TCOD_TYPE_NONE,
        TCOD_TYPE_BOOL,
        TCOD_TYPE_CHAR,
        TCOD_TYPE_INT,
        TCOD_TYPE_FLOAT,
        TCOD_TYPE_STRING,
        TCOD_TYPE_COLOR,
        TCOD_TYPE_DICE,
        TCOD_TYPE_VALUELIST00,
        TCOD_TYPE_VALUELIST01,
        TCOD_TYPE_VALUELIST02,
        TCOD_TYPE_VALUELIST03,
        TCOD_TYPE_VALUELIST04,
        TCOD_TYPE_VALUELIST05,
        TCOD_TYPE_VALUELIST06,
        TCOD_TYPE_VALUELIST07,
        TCOD_TYPE_VALUELIST08,
        TCOD_TYPE_VALUELIST09,
        TCOD_TYPE_VALUELIST10,
        TCOD_TYPE_VALUELIST11,
        TCOD_TYPE_VALUELIST12,
        TCOD_TYPE_VALUELIST13,
        TCOD_TYPE_VALUELIST14,
        TCOD_TYPE_VALUELIST15,
        TCOD_TYPE_CUSTOM00,
        TCOD_TYPE_CUSTOM01,
        TCOD_TYPE_CUSTOM02,
        TCOD_TYPE_CUSTOM03,
        TCOD_TYPE_CUSTOM04,
        TCOD_TYPE_CUSTOM05,
        TCOD_TYPE_CUSTOM06,
        TCOD_TYPE_CUSTOM07,
        TCOD_TYPE_CUSTOM08,
        TCOD_TYPE_CUSTOM09,
        TCOD_TYPE_CUSTOM10,
        TCOD_TYPE_CUSTOM11,
        TCOD_TYPE_CUSTOM12,
        TCOD_TYPE_CUSTOM13,
        TCOD_TYPE_CUSTOM14,
        TCOD_TYPE_CUSTOM15,
        TCOD_TYPE_LIST = 1024,
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct TCOD_value_t
    {
        [FieldOffset(0)]
        [NativeTypeName("_Bool")]
        public byte b;

        [FieldOffset(0)]
        [NativeTypeName("char")]
        public sbyte c;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int i;

        [FieldOffset(0)]
        public float f;

        [FieldOffset(0)]
        [NativeTypeName("char *")]
        public sbyte* s;

        [FieldOffset(0)]
        [NativeTypeName("TCOD_color_t")]
        public TCOD_ColorRGB col;

        [FieldOffset(0)]
        public TCOD_dice_t dice;

        [FieldOffset(0)]
        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* list;

        [FieldOffset(0)]
        public void* custom;
    }

    public unsafe partial struct TCOD_ParserStruct
    {
        [NativeTypeName("char *")]
        public sbyte* name;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* flags;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* props;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* lists;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* structs;
    }

    public unsafe partial struct TCOD_Parser
    {
        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* structs;

        [NativeTypeName("TCOD_parser_custom_t[16]")]
        public _customs_e__FixedBuffer customs;

        [NativeTypeName("_Bool")]
        public byte fatal;

        [NativeTypeName("TCOD_list_t")]
        public TCOD_List* props;

        public unsafe partial struct _customs_e__FixedBuffer
        {
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e0;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e1;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e2;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e3;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e4;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e5;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e6;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e7;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e8;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e9;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e10;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e11;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e12;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e13;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e14;
            public delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> e15;

            public ref delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> this[int index]
            {
                get
                {
                    fixed (delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t>* pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct TCOD_parser_listener_t
    {
        [NativeTypeName("_Bool (*)(TCOD_ParserStruct *, const char *)")]
        public delegate* unmanaged[Cdecl]<TCOD_ParserStruct*, sbyte*, byte> new_struct;

        [NativeTypeName("_Bool (*)(const char *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, byte> new_flag;

        [NativeTypeName("_Bool (*)(const char *, TCOD_value_type_t, TCOD_value_t)")]
        public delegate* unmanaged[Cdecl]<sbyte*, TCOD_value_type_t, TCOD_value_t, byte> new_property;

        [NativeTypeName("_Bool (*)(TCOD_ParserStruct *, const char *)")]
        public delegate* unmanaged[Cdecl]<TCOD_ParserStruct*, sbyte*, byte> end_struct;

        [NativeTypeName("void (*)(const char *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, void> error;
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_struct_get_name([NativeTypeName("const TCOD_ParserStruct *")] TCOD_ParserStruct* def);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_property(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* name, TCOD_value_type_t type, [NativeTypeName("_Bool")] byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_list_property(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* name, TCOD_value_type_t type, [NativeTypeName("_Bool")] byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_value_list(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *const *")] sbyte** value_list, [NativeTypeName("_Bool")] byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_value_list_sized(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *const *")] sbyte** value_list, int size, [NativeTypeName("_Bool")] byte mandatory);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_flag(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_struct_add_structure(TCOD_ParserStruct* def, [NativeTypeName("const TCOD_ParserStruct *")] TCOD_ParserStruct* sub_structure);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_struct_is_mandatory(TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_type_t TCOD_struct_get_type([NativeTypeName("const TCOD_ParserStruct *")] TCOD_ParserStruct* def, [NativeTypeName("const char *")] sbyte* propname);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_Parser* TCOD_parser_new();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_ParserStruct* TCOD_parser_new_struct(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_type_t TCOD_parser_new_custom_type(TCOD_Parser* parser, [NativeTypeName("TCOD_parser_custom_t")] delegate* unmanaged[Cdecl]<TCOD_lex_t*, TCOD_parser_listener_t*, TCOD_ParserStruct*, sbyte*, TCOD_value_t> custom_type_parser);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_parser_run(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* filename, TCOD_parser_listener_t* listener);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_parser_delete(TCOD_Parser* parser);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_parser_error([NativeTypeName("const char *")] sbyte* msg, __arglist);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_parser_has_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_parser_get_bool_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_parser_get_char_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_parser_get_int_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_parser_get_float_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_parser_get_string_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_parser_get_color_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_dice_t TCOD_parser_get_dice_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_parser_get_dice_property_py(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name, TCOD_dice_t* dice);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* TCOD_parser_get_custom_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_list_t")]
        public static extern TCOD_List* TCOD_parser_get_list_property(TCOD_Parser* parser, [NativeTypeName("const char *")] sbyte* name, TCOD_value_type_t type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_bool_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_char_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_integer_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_float_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_string_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_color_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_dice_value();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_value_list_value(TCOD_ParserStruct* def, int list_num);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_value_t TCOD_parse_property_value(TCOD_Parser* parser, TCOD_ParserStruct* def, [NativeTypeName("char *")] sbyte* propname, [NativeTypeName("_Bool")] byte list);
    }
}

