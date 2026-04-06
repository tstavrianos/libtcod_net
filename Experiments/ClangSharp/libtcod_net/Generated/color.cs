using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    /// <summary>
    /// A 3-channel RGB color struct.
    /// </summary>
    public partial struct TCOD_ColorRGB
    {
        [NativeTypeName("uint8_t")]
        public byte r;

        [NativeTypeName("uint8_t")]
        public byte g;

        [NativeTypeName("uint8_t")]
        public byte b;
    }

    /// <summary>
    /// A 4-channel RGBA color struct.
    /// </summary>
    public partial struct TCOD_ColorRGBA
    {
        [NativeTypeName("uint8_t")]
        public byte r;

        [NativeTypeName("uint8_t")]
        public byte g;

        [NativeTypeName("uint8_t")]
        public byte b;

        [NativeTypeName("uint8_t")]
        public byte a;
    }

    public static unsafe partial class libtcod
    {

        /// <summary>
        /// Return a new TCOD_color_t from HSV values.
        /// </summary>
        /// <param name="hue">The colors hue (in degrees.)</param>
        /// <param name="saturation">The colors saturation (from 0 to 1)</param>
        /// <param name="value">The colors value (from 0 to 1)</param>
        /// <returns>A new TCOD_color_t struct.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_HSV(float hue, float saturation, float value);

        /// <summary>
        /// Return true value if c1 and c2 are equal.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_color_equals([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c2);

        /// <summary>
        /// Add two colors together and return the result.
        /// </summary>
        /// <param name="c1">The first color.</param>
        /// <param name="c2">The second color.</param>
        /// <returns>A new TCOD_color_t struct with the result.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_add([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c2);

        /// <summary>
        /// Subtract c2 from c1 and return the result.
        /// </summary>
        /// <param name="c1">The first color.</param>
        /// <param name="c2">The second color.</param>
        /// <returns>A new TCOD_color_t struct with the result.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_subtract([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c2);

        /// <summary>
        /// Multiply two colors together and return the result.
        /// </summary>
        /// <param name="c1">The first color.</param>
        /// <param name="c2">The second color.</param>
        /// <returns>A new TCOD_color_t struct with the result.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_multiply([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c2);

        /// <summary>
        /// Multiply a color with a scalar value and return the result.
        /// </summary>
        /// <param name="c1">The color to multiply.</param>
        /// <param name="value">The scalar float.</param>
        /// <returns>A new TCOD_color_t struct with the result.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_multiply_scalar([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, float value);

        /// <summary>
        /// Interpolate two colors together and return the result.
        /// </summary>
        /// <param name="c1">The first color (where coef if 0)</param>
        /// <param name="c2">The second color (where coef if 1)</param>
        /// <param name="coef">The coefficient.</param>
        /// <returns>A new TCOD_color_t struct with the result.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("TCOD_color_t")]
        public static extern TCOD_ColorRGB TCOD_color_lerp([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c1, [NativeTypeName("TCOD_color_t")] TCOD_ColorRGB c2, float coef);

        /// <summary>
        /// Blend src into dst as an RGBA alpha blending operation.
        /// </summary>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_alpha_blend(TCOD_ColorRGBA* dst, [NativeTypeName("const TCOD_ColorRGBA *")] TCOD_ColorRGBA* src);

        /// <summary>
        /// Sets a colors values from HSV values.
        /// </summary>
        /// <param name="color">The color to be changed.</param>
        /// <param name="hue">The colors hue (in degrees.)</param>
        /// <param name="saturation">The colors saturation (from 0 to 1)</param>
        /// <param name="value">The colors value (from 0 to 1)</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_set_HSV([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float hue, float saturation, float value);

        /// <summary>
        /// Get a set of HSV values from a color.
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="hue">Pointer to a float, filled with the hue. (degrees)</param>
        /// <param name="saturation">Pointer to a float, filled with the saturation. (0 to 1)</param>
        /// <param name="value">Pointer to a float, filled with the value. (0 to 1)</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_get_HSV([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB color, float* hue, float* saturation, float* value);

        /// <summary>
        /// Return a colors hue.
        /// </summary>
        /// <param name="color">A color struct.</param>
        /// <returns>The colors hue. (degrees)</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_hue([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB color);

        /// <summary>
        /// Change a colors hue.
        /// </summary>
        /// <param name="color">Pointer to a color struct.</param>
        /// <param name="hue">The hue in degrees.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_set_hue([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float hue);

        /// <summary>
        /// Return a colors saturation.
        /// </summary>
        /// <param name="color">A color struct.</param>
        /// <returns>The colors saturation. (0 to 1)</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_saturation([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB color);

        /// <summary>
        /// Change a colors saturation.
        /// </summary>
        /// <param name="color">Pointer to a color struct.</param>
        /// <param name="saturation">The desired saturation value.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_set_saturation([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float saturation);

        /// <summary>
        /// Get a colors value.
        /// </summary>
        /// <param name="color">A color struct.</param>
        /// <returns>The colors value. (0 to 1)</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float TCOD_color_get_value([NativeTypeName("TCOD_color_t")] TCOD_ColorRGB color);

        /// <summary>
        /// Change a colors value.
        /// </summary>
        /// <param name="color">Pointer to a color struct.</param>
        /// <param name="value">The desired value.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_set_value([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float value);

        /// <summary>
        /// Shift a colors hue by an amount.
        /// </summary>
        /// <param name="color">Pointer to a color struct.</param>
        /// <param name="hue_shift">The distance to shift the hue, in degrees.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_shift_hue([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float shift);

        /// <summary>
        /// Scale a colors saturation and value.
        /// </summary>
        /// <param name="color">Pointer to a color struct.</param>
        /// <param name="saturation_coef">Multiplier for this colors saturation.</param>
        /// <param name="value_coef">Multiplier for this colors value.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_scale_HSV([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* color, float saturation_coef, float value_coef);

        /// <summary>
        /// Generate an interpolated gradient of colors.
        /// </summary>
        /// <param name="map">Array to fill with the new gradient.</param>
        /// <param name="nb_key">The array size of the key_color and key_index parameters.</param>
        /// <param name="key_color">An array of colors to use, in order.</param>
        /// <param name="key_index">An array mapping key_color items to the map array.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_color_gen_map([NativeTypeName("TCOD_color_t *")] TCOD_ColorRGB* map, int nb_key, [NativeTypeName("const TCOD_color_t *")] TCOD_ColorRGB* key_color, [NativeTypeName("const int *")] int* key_index);

        public const int TCOD_COLOR_RED = 0;
        public const int TCOD_COLOR_FLAME = 1;
        public const int TCOD_COLOR_ORANGE = 2;
        public const int TCOD_COLOR_AMBER = 3;
        public const int TCOD_COLOR_YELLOW = 4;
        public const int TCOD_COLOR_LIME = 5;
        public const int TCOD_COLOR_CHARTREUSE = 6;
        public const int TCOD_COLOR_GREEN = 7;
        public const int TCOD_COLOR_SEA = 8;
        public const int TCOD_COLOR_TURQUOISE = 9;
        public const int TCOD_COLOR_CYAN = 10;
        public const int TCOD_COLOR_SKY = 11;
        public const int TCOD_COLOR_AZURE = 12;
        public const int TCOD_COLOR_BLUE = 13;
        public const int TCOD_COLOR_HAN = 14;
        public const int TCOD_COLOR_VIOLET = 15;
        public const int TCOD_COLOR_PURPLE = 16;
        public const int TCOD_COLOR_FUCHSIA = 17;
        public const int TCOD_COLOR_MAGENTA = 18;
        public const int TCOD_COLOR_PINK = 19;
        public const int TCOD_COLOR_CRIMSON = 20;
        public const int TCOD_COLOR_NB = 21;

        public const int TCOD_COLOR_DESATURATED = 0;
        public const int TCOD_COLOR_LIGHTEST = 1;
        public const int TCOD_COLOR_LIGHTER = 2;
        public const int TCOD_COLOR_LIGHT = 3;
        public const int TCOD_COLOR_NORMAL = 4;
        public const int TCOD_COLOR_DARK = 5;
        public const int TCOD_COLOR_DARKER = 6;
        public const int TCOD_COLOR_DARKEST = 7;
        public const int TCOD_COLOR_LEVELS = 8;
    }
}

