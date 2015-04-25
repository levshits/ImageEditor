using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary
{
    public class StringToImageExtensionConverter
    {
        public static ImageFormat Convert(String value)
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
