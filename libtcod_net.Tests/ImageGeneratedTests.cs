using System.Runtime.InteropServices;
using Interop.Runtime;
using static libtcod_net.libtcod;

namespace libtcod_net.Tests;

public unsafe class ImageGeneratedTests
{
    [Fact]
    public void ImageNewAndPixelOperations_MatchNativeCoverage()
    {
        var image = TCOD_image_new(3, 2);
        Assert.False(image == null);

        try
        {
            Assert.Equal(TCOD_ColorRGB.TCOD_black, TCOD_image_get_pixel(image, 0, 0));

            TCOD_image_clear(image, TCOD_ColorRGB.TCOD_black);

            var pixel = new TCOD_ColorRGB
            {
                r = 1,
                g = 2,
                b = 3,
            };
            TCOD_image_put_pixel(image, 0, 0, pixel);

            Assert.Equal(pixel, TCOD_image_get_pixel(image, 0, 0));

            int width,
                height;
            TCOD_image_get_size(image, &width, &height);
            Assert.Equal(3, width);
            Assert.Equal(2, height);
        }
        finally
        {
            TCOD_image_delete(image);
        }
    }

    [Fact]
    public void ImageLoadPng_LoadsNativeFixture()
    {
        using var allocator = new ArenaNativeAllocator(1024);
        var path = NativeTestAssetPaths.NativeData("img", "circle.png");
        var pathPtr = CString.FromString(allocator, path);
        var image = TCOD_image_load(pathPtr);
        allocator.Free(pathPtr);
        Assert.False(image == null);

        try
        {
            int width,
                height;
            TCOD_image_get_size(image, &width, &height);
            Assert.True(width > 0);
            Assert.True(height > 0);
        }
        finally
        {
            TCOD_image_delete(image);
        }
    }
}
