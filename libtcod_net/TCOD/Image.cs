using System;
using static libtcod_net.libtcod;

namespace libtcod_net.TCOD;

/// <summary>
/// Represents an image for rendering graphics.
/// </summary>
public sealed unsafe class Image : TCODResource<TCOD_Image>
{
    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    public int Width { get; private set; }

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    public int Height { get; private set; }

    private Image(TCOD_Image* pointer)
    {
        if (pointer == null)
            throw new TCODException(
                "Cannot construct Image with a NULL pointer",
                TCOD_Error.TCOD_E_ERROR
            );
        Pointer = pointer;
        int width,
            height;
        TCOD_image_get_size(pointer, &width, &height);
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Creates a new image with the specified width and height.
    /// </summary>
    /// <param name="width">The width of the image.</param>
    /// <param name="height">The height of the image.</param>
    /// <returns>A new Image instance.</returns>
    public static Image Create(int width, int height)
    {
        var pointer = TCOD_image_new(width, height);
        ErrorHelper.CheckAndThrow(pointer);
        return new Image(pointer);
    }

    /// <summary>
    /// Loads an image from a file.
    /// </summary>
    /// <param name="filename">The path to the image file.</param>
    /// <returns>A new Image instance.</returns>
    public static Image FromFile(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var pointer = TCOD_image_load(filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(pointer);
        var image = new Image(pointer);
        return image;
    }

    /// <summary>
    /// Creates an image from a console.
    /// </summary>
    /// <param name="console">The console to create the image from.</param>
    /// <returns>A new Image instance.</returns>
    public static Image FromConsole(Console console)
    {
        ArgumentNullException.ThrowIfNull(console);
        var pointer = TCOD_image_from_console(console.Pointer);
        ErrorHelper.CheckAndThrow(pointer);
        var image = new Image(pointer);
        return image;
    }

    /// <summary>
    /// Saves the image to a file.
    /// </summary>
    /// <param name="filename">The path to the file where the image will be saved.</param>
    /// <exception cref="ArgumentException">Thrown if the filename is null or empty.</exception>
    public void SaveToFile(string filename)
    {
        ArgumentException.ThrowIfNullOrEmpty(filename);
        using var filenamePtr = new StringMarshal(filename);
        var ret = TCOD_image_save(Pointer, filenamePtr.CStr);
        ErrorHelper.CheckAndThrow(ret);
    }

    /// <summary>
    /// If you need to refresh the image with the console's new content, you don't have to delete it and create another
    /// one. Instead, use this function. Note that you must use the same console that was used in the <see cref="FromConsole"/>
    /// call (or at least a console with the same size).
    /// </summary>
    /// <param name="console">The console to capture.</param>
    /// <exception cref="ArgumentNullException">Thrown if the console is null.</exception>
    public void RefreshConsole(Console console)
    {
        ArgumentNullException.ThrowIfNull(console);
        TCOD_image_refresh_console(Pointer, console.Pointer);
    }

    /// <summary>
    /// Inverts the colors of the image.
    /// </summary>
    public void Invert()
    {
        TCOD_image_invert(Pointer);
    }

    /// <summary>
    /// Flips the image horizontally.
    /// </summary>
    public void HorizontalFlip()
    {
        TCOD_image_hflip(Pointer);
    }

    /// <summary>
    /// Flips the image vertically.
    /// </summary>
    public void VerticalFlip()
    {
        TCOD_image_vflip(Pointer);
    }

    /// <summary>
    /// Rotates the image 90 degrees clockwise the specified number of times.
    /// </summary>
    /// <param name="rotations">The number of 90-degree rotations to apply.</param>
    public void Rotate90(int rotations)
    {
        TCOD_image_rotate90(Pointer, rotations);
    }

    /// <summary>
    /// You can resize an image and scale its content. If the new width is less than the old width or the new height is
    /// less than the old height, supersampling is used to scale down the image. Else the image is scaled up using
    /// nearest neighbor.
    /// </summary>
    /// <param name="width">The new width of the image.</param>
    /// <param name="height">The new height of the image.</param>
    public void Scale(int width, int height)
    {
        TCOD_image_scale(Pointer, width, height);
        Width = width;
        Height = height;
    }

    /// <summary>
    /// If you have set a key color for this image with <see cref="SetKeyColor"/>, or if this image was created from a
    /// 32 bits PNG file (with alpha layer), you can get the pixel transparency with this function. This function
    /// returns a value between 0 (transparent pixel) and 255 (opaque pixel).
    /// </summary>
    /// <param name="x">The x-coordinate of the pixel.</param>
    /// <param name="y">The y-coordinate of the pixel.</param>
    /// <returns>The alpha value of the pixel.</returns>
    public int GetAlpha(int x, int y)
    {
        return TCOD_image_get_alpha(Pointer, x, y);
    }

    /// <summary>
    /// This method uses mipmaps to get the average color of an arbitrary rectangular region of the image. It can be
    /// used to draw a scaled-down version of the image. It's used by libtcod's blitting functions.
    /// </summary>
    /// <param name="x0">The x-coordinate of the top-left corner of the mipmap region.</param>
    /// <param name="y0">The y-coordinate of the top-left corner of the mipmap region.</param>
    /// <param name="x1">The x-coordinate of the bottom-right corner of the mipmap region.</param>
    /// <param name="y1">The y-coordinate of the bottom-right corner of the mipmap region.</param>
    /// <returns>The average color of region.</returns>
    public TCOD_ColorRGB GetMipmapPixel(float x0, float y0, float x1, float y1)
    {
        return TCOD_image_get_mipmap_pixel(Pointer, x0, y0, x1, y1);
    }

    /// <summary>
    /// Blits the image onto the specified console at the given coordinates.
    /// </summary>
    /// <param name="console">The console to blit the image onto.</param>
    /// <param name="x">The x-coordinate on the console where the image will be blitted.</param>
    /// <param name="y">The y-coordinate on the console where the image will be blitted.</param>
    /// <param name="backgroundFlag">The background flag to use when blitting the image.</param>
    /// <param name="scaleX">The horizontal scale factor for the image.</param>
    /// <param name="scaleY">The vertical scale factor for the image.</param>
    /// <param name="angle">The rotation angle for the image.</param>
    /// <exception cref="ArgumentNullException">Thrown if the console is null.</exception>
    public void Blit(
        Console console,
        float x,
        float y,
        TCOD_bkgnd_flag_t backgroundFlag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE,
        float scaleX = 1,
        float scaleY = 1,
        float angle = 0
    )
    {
        ArgumentNullException.ThrowIfNull(console);
        TCOD_image_blit(Pointer, console.Pointer, x, y, backgroundFlag, scaleX, scaleY, angle);
    }

    /// <summary>
    /// Blits a rectangular region of the image onto the specified console at the given coordinates.
    /// </summary>
    /// <param name="console">The console to blit the image onto.</param>
    /// <param name="x">The x-coordinate on the console where the image will be blitted.</param>
    /// <param name="y">The y-coordinate on the console where the image will be blitted.</param>
    /// <param name="width">The width of the region to blit. If set to -1, the entire width of the image is used.</param>
    /// <param name="height">The height of the region to blit. If set to -1, the entire height of the image is used.</param>
    /// <param name="backgroundFlag">The background flag to use when blitting the image.</param>
    /// <exception cref="ArgumentNullException">Thrown if the console is null.</exception>
    public void BlitRect(
        Console console,
        int x,
        int y,
        int width,
        int height,
        TCOD_bkgnd_flag_t backgroundFlag = TCOD_bkgnd_flag_t.TCOD_BKGND_NONE
    )
    {
        ArgumentNullException.ThrowIfNull(console);
        TCOD_image_blit_rect(Pointer, console.Pointer, x, y, width, height, backgroundFlag);
    }

    /// <summary>
    /// Blitting with subcell resolution.
    /// </summary>
    /// <param name="destination">The destination console.</param>
    /// <param name="xDestination">The x-coordinate on the destination console.</param>
    /// <param name="yDestination">The y-coordinate on the destination console.</param>
    /// <param name="xSource">The x-coordinate on the source image.</param>
    /// <param name="ySource">The y-coordinate on the source image.</param>
    /// <param name="width">The width of the region to blit. If set to -1, the entire width of the source image is used.</param>
    /// <param name="height">The height of the region to blit. If set to -1, the entire height of the source image is used.</param>
    /// <exception cref="ArgumentNullException">Thrown if the destination console is null.</exception>
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
        TCOD_image_blit_2x(
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

    /// <summary>
    /// Sets the key color for the image. Pixels of this color will be treated as transparent.
    /// </summary>
    /// <param name="keyColor">The color to be treated as transparent.</param>
    public void SetKeyColor(TCOD_ColorRGB keyColor)
    {
        TCOD_image_set_key_color(Pointer, keyColor);
    }

    /// <summary>
    /// Checks if a specific pixel in the image is transparent.
    /// </summary>
    /// <param name="x">The x-coordinate of the pixel.</param>
    /// <param name="y">The y-coordinate of the pixel.</param>
    /// <returns>True if the pixel is transparent; otherwise, false.</returns>
    public bool IsPixelTransparent(int x, int y)
    {
        return TCOD_image_is_pixel_transparent(Pointer, x, y);
    }

    /// <summary>
    /// Gets or sets the color of a specific pixel in the image.
    /// </summary>
    /// <param name="x">The x-coordinate of the pixel.</param>
    /// <param name="y">The y-coordinate of the pixel.</param>
    public TCOD_ColorRGB this[int x, int y]
    {
        get => TCOD_image_get_pixel(Pointer, x, y);
        set => TCOD_image_put_pixel(Pointer, x, y, value);
    }

    protected override void ReleaseUnmanagedResources()
    {
        TCOD_image_delete(Pointer);
    }
}
