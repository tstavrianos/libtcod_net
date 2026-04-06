using System;
using System.Runtime.InteropServices;

using System.Runtime.InteropServices.Marshalling;
namespace libtcod_net
{
    /// <summary>
    /// A struct used for computing a bresenham line.
    /// </summary>
    public partial struct TCOD_bresenham_data_t
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

    public static unsafe partial class libtcod
    {


        /// <summary>
        /// Iterate over a line using a callback.
        /// </summary>
        /// <param name="xo">The origin x position.</param>
        /// <param name="yo">The origin y position.</param>
        /// <param name="xd">The destination x position.</param>
        /// <param name="yd">The destination y position.</param>
        /// <param name="listener">A TCOD_line_listener_t callback. Iteration stops early if this callback returns false.</param>
        /// <returns>true if the line was completely exhausted by the callback.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_line(int xFrom, int yFrom, int xTo, int yTo, [NativeTypeName("TCOD_line_listener_t")] delegate* unmanaged[Cdecl]<int, int, byte> listener);

        /// <summary>
        /// Initialize a TCOD_bresenham_data_t struct.
        /// </summary>
        /// <param name="xFrom">The starting x position.</param>
        /// <param name="yFrom">The starting y position.</param>
        /// <param name="xTo">The ending x position.</param>
        /// <param name="yTo">The ending y position.</param>
        /// <param name="data">Pointer to a TCOD_bresenham_data_t struct.</param>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void TCOD_line_init_mt(int xFrom, int yFrom, int xTo, int yTo, TCOD_bresenham_data_t* data);

        /// <summary>
        /// Get the next point on a line, returns true once the line has ended.
        /// </summary>
        /// <param name="xCur">An int pointer to fill with the next x position.</param>
        /// <param name="yCur">An int pointer to fill with the next y position.</param>
        /// <param name="data">Pointer to a initialized TCOD_bresenham_data_t struct.</param>
        /// <returns>true after the ending point has been reached.</returns>
        [DllImport("libtcod", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte TCOD_line_step_mt([NativeTypeName("int *restrict")] int* xCur, [NativeTypeName("int *restrict")] int* yCur, TCOD_bresenham_data_t* data);

    }
}

