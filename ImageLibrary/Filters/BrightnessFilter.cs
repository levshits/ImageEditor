using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Filters
{
    class BrightnessFilter : AbstractFilter
    {
        public BrightnessFilter(int brightness)
        {
            var b = (float)brightness/255;
            _matrix = new float[][]
            {
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0}, 
                new float[]{0, 0, 1, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new float[]{b, b, b, 0, 1}, 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
