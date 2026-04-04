namespace libtcod_net.Tests;

public class ImageGeneratedTests
{
    [Fact]
    public void ImageNewAndPixelOperations_MatchNativeCoverage()
    {
        var image = LibraryImportMethods.TCOD_image_new(3, 2);
        Assert.NotEqual(nint.Zero, image);

        try
        {
            Assert.Equal(
                TCOD_ColorRGB.TCOD_black,
                LibraryImportMethods.TCOD_image_get_pixel(image, 0, 0)
            );

            LibraryImportMethods.TCOD_image_clear(image, TCOD_ColorRGB.TCOD_black);

            var pixel = new TCOD_ColorRGB
            {
                r = 1,
                g = 2,
                b = 3,
            };
            LibraryImportMethods.TCOD_image_put_pixel(image, 0, 0, pixel);

            Assert.Equal(pixel, LibraryImportMethods.TCOD_image_get_pixel(image, 0, 0));

            LibraryImportMethods.TCOD_image_get_size(image, out var width, out var height);
            Assert.Equal(3, width);
            Assert.Equal(2, height);
        }
        finally
        {
            LibraryImportMethods.TCOD_image_delete(image);
        }
    }

    [Fact]
    public void ImageLoadPng_LoadsNativeFixture()
    {
        var path = NativeTestAssetPaths.NativeData("img", "circle.png");
        var image = LibraryImportMethods.TCOD_image_load(path);
        Assert.NotEqual(nint.Zero, image);

        try
        {
            LibraryImportMethods.TCOD_image_get_size(image, out var width, out var height);
            Assert.True(width > 0);
            Assert.True(height > 0);
        }
        finally
        {
            LibraryImportMethods.TCOD_image_delete(image);
        }
    }
}
