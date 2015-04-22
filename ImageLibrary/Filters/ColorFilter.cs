using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Filters
{
    class ColorFilter : AbstractFilter
    {
        public ColorFilter(int red, int green, int blue)
        {
            var r = (float)red / 255;
            var g = (float)green / 255;
            var b = (float)blue / 255;
            _matrix = new float[][]
            {
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0}, 
                new float[]{0, 0, 1, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new float[]{r, g, b, 0, 1}, 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
