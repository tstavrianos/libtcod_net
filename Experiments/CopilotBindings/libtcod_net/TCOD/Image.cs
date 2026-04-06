using System;

namespace libtcod_net.TCOD;

public class Image : TCODResource
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Image(nint pointer)
    {
        if (pointer == nint.Zero)
            throw new TCODException(
                "Cannot construct Image with a NULL pointer",
                libtcod.TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        libtcod.TCOD_image_get_size(pointer, out var width, out var height);
        Width = width;
        Height = height;
    }

    public static Image Create(int width, int height)
    {
        var pointer = libtcod.TCOD_image_new(width, height);
        ErrorHelper.CheckAndThrow(pointer);
        return new Image(pointer);
    }

    public static Image FromFile(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var pointer = libtcod.TCOD_image_load(filename);
        ErrorHelper.CheckAndThrow(pointer);
        var image = new Image(pointer);
        return image;
    }

    public static Image FromConsole(Console console)
    {
        ArgumentNullException.ThrowIfNull(console);
        var pointer = libtcod.TCOD_image_from_console(console.Pointer);
        ErrorHelper.CheckAndThrow(pointer);
        var image = new Image(pointer);
        return image;
    }

    public void SaveToFile(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        var ret = libtcod.TCOD_image_save(Pointer, filename);
        ErrorHelper.CheckAndThrow(ret);
    }

    public void RefreshConsole(Console console)
    {
        ArgumentNullException.ThrowIfNull(console);
        libtcod.TCOD_image_refresh_console(Pointer, console.Pointer);
    }

    public void Invert()
    {
        libtcod.TCOD_image_invert(Pointer);
    }

    public void HorizontalFlip()
    {
        libtcod.TCOD_image_hflip(Pointer);
    }

    public void VerticalFlip()
    {
        libtcod.TCOD_image_vflip(Pointer);
    }

    public void Rotate90(int rotations)
    {
        libtcod.TCOD_image_rotate90(Pointer, rotations);
    }

    public void Scale(int width, int height)
    {
        libtcod.TCOD_image_scale(Pointer, width, height);
        Width = width;
        Height = height;
    }

    public int GetAlpha(int x, int y)
    {
        return libtcod.TCOD_image_get_alpha(Pointer, x, y);
    }

    public libtcod.TCOD_ColorRGB GetMipmapPixel(float x0, float y0, float x1, float y1)
    {
        return libtcod.TCOD_image_get_mipmap_pixel(Pointer, x0, y0, x1, y1);
    }

    public void Blit(
        Console console,
        float x,
        float y,
        libtcod.TCOD_bkgnd_flag_t backgroundFlag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        float scaleX = 1,
        float scaleY = 1,
        float angle = 0
    )
    {
        ArgumentNullException.ThrowIfNull(console);
        libtcod.TCOD_image_blit(
            Pointer,
            console.Pointer,
            x,
            y,
            backgroundFlag,
            scaleX,
            scaleY,
            angle
        );
    }

    public void BlitRect(
        Console console,
        int x,
        int y,
        int width,
        int height,
        libtcod.TCOD_bkgnd_flag_t backgroundFlag = libtcod.TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        ArgumentNullException.ThrowIfNull(console);
        libtcod.TCOD_image_blit_rect(Pointer, console.Pointer, x, y, width, height, backgroundFlag);
    }

    public void Blit2x(
        Console destination,
        int xDestination,
        int yDestination,
        int xSource,
        int ySource,
        int width,
        int height
    )
    {
        ArgumentNullException.ThrowIfNull(destination);
        libtcod.TCOD_image_blit_2x(
            Pointer,
            destination.Pointer,
            xDestination,
            yDestination,
            xSource,
            ySource,
            width,
            height
        );
    }

    public void SetKeyColor(libtcod.TCOD_ColorRGB keyColor)
    {
        libtcod.TCOD_image_set_key_color(Pointer, keyColor);
    }

    public bool IsPixelTransparent(int x, int y)
    {
        return libtcod.TCOD_image_is_pixel_transparent(Pointer, x, y);
    }

    public libtcod.TCOD_ColorRGB this[int x, int y]
    {
        get => libtcod.TCOD_image_get_pixel(Pointer, x, y);
        set => libtcod.TCOD_image_put_pixel(Pointer, x, y, value);
    }

    protected override void ReleaseUnmanagedResources()
    {
        libtcod.TCOD_image_delete(Pointer);
    }
}
