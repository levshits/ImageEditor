using System;
using System.Drawing.Imaging;

namespace ImageLibrary
{
    public class StringToImageExtensionConverter
    {
        public static ImageFormat Convert(string value)
        {
            switch (value)
            {
                case ".jpg": return ImageFormat.Jpeg;
                case ".png": return ImageFormat.Png;
                case ".bmp": return ImageFormat.Bmp;
                case ".gif": return ImageFormat.Gif;
                default: return ImageFormat.Jpeg;
            }
        }
    }
}
