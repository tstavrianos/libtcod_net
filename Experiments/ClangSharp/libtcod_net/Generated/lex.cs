using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    public unsafe partial struct TCOD_lex_t
    {
        public int file_line;

        public int token_type;

        public int token_int_val;

        public int token_idx;

        public float token_float_val;

        [NativeTypeName("char *")]
        public sbyte* tok;

        public int toklen;

        [NativeTypeName("char")]
        public sbyte lastStringDelim;

        [NativeTypeName("char *")]
        public sbyte* pos;

        [NativeTypeName("char *")]
        public sbyte* buf;

        [NativeTypeName("char *")]
        public sbyte* filename;

        [NativeTypeName("char *")]
        public sbyte* last_javadoc_comment;

        public int nb_symbols;

        public int nb_keywords;

        public int flags;

        [NativeTypeName("char[100][5]")]
        public _symbols_e__FixedBuffer symbols;

        [NativeTypeName("char[100][20]")]
        public _keywords_e__FixedBuffer keywords;

        [NativeTypeName("const char *")]
        public sbyte* simple_comment;

        [NativeTypeName("const char *")]
        public sbyte* comment_start;

        [NativeTypeName("const char *")]
        public sbyte* comment_stop;

        [NativeTypeName("const char *")]
        public sbyte* javadoc_comment_start;

        [NativeTypeName("const char *")]
        public sbyte* stringDelim;

        [NativeTypeName("_Bool")]
        public byte javadoc_read;

        [NativeTypeName("_Bool")]
        public byte allocBuf;

        [NativeTypeName("_Bool")]
        public byte is_savepoint;

        [InlineArray(100 * 5)]
        public partial struct _symbols_e__FixedBuffer
        {
            public sbyte e0_0;
        }

        [InlineArray(100 * 20)]
        public partial struct _keywords_e__FixedBuffer
        {
            public sbyte e0_0;
        }
    }

    public static unsafe partial class libtcod
    {
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_lex_t* TCOD_lex_new_intern();

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern TCOD_lex_t* TCOD_lex_new([NativeTypeName("const char *const *")] sbyte** symbols, [NativeTypeName("const char *const *")] sbyte** keywords, [NativeTypeName("const char *")] sbyte* simpleComment, [NativeTypeName("const char *")] sbyte* commentStart, [NativeTypeName("const char *")] sbyte* commentStop, [NativeTypeName("const char *")] sbyte* javadocCommentStart, [NativeTypeName("const char *")] sbyte* stringDelim, int flags);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_lex_delete(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_lex_set_data_buffer(TCOD_lex_t* lex, [NativeTypeName("char *")] sbyte* dat);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_lex_set_data_file(TCOD_lex_t* lex, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_lex_parse(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_lex_parse_until_token_type(TCOD_lex_t* lex, int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_lex_parse_until_token_value(TCOD_lex_t* lex, [NativeTypeName("const char *")] sbyte* token_value);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_lex_expect_token_type(TCOD_lex_t* lex, int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_lex_expect_token_value(TCOD_lex_t* lex, int token_type, [NativeTypeName("const char *")] sbyte* token_value);
        // Managed wrapper for TCOD_lex_expect_token_value
        public static byte TCOD_lex_expect_token_value(
            TCOD_lex_t* lex,
            int token_type,
            string token_value
        )
        {
            var token_valuePtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8(token_value);
            try
            {
                return TCOD_lex_expect_token_value(lex, token_type, (sbyte*)token_valuePtr.ToPointer());
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(token_valuePtr);
            }
        }


        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_lex_savepoint(TCOD_lex_t* lex, TCOD_lex_t* savepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_lex_restore(TCOD_lex_t* lex, TCOD_lex_t* savepoint);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* TCOD_lex_get_last_javadoc(TCOD_lex_t* lex);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* TCOD_lex_get_token_name(int token_type);

        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int TCOD_lex_hextoint([NativeTypeName("char")] sbyte c);
    }
}

