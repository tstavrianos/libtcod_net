using System.Runtime.InteropServices.Marshalling;

namespace libtcod_net
{
    public partial struct TCOD_mouse_t
    {
        public int x;

        public int y;

        public int dx;

        public int dy;

        public int cx;

        public int cy;

        public int dcx;

        public int dcy;

        [NativeTypeName("_Bool")]
        public byte lbutton;

        [NativeTypeName("_Bool")]
        public byte rbutton;

        [NativeTypeName("_Bool")]
        public byte mbutton;

        [NativeTypeName("_Bool")]
        public byte lbutton_pressed;

        [NativeTypeName("_Bool")]
        public byte rbutton_pressed;

        [NativeTypeName("_Bool")]
        public byte mbutton_pressed;

        [NativeTypeName("_Bool")]
        public byte wheel_up;

        [NativeTypeName("_Bool")]
        public byte wheel_down;
    }

    public partial struct TCOD_MouseTransform
    {
        public double offset_x;

        public double offset_y;

        public double scale_x;

        public double scale_y;
    }
}

