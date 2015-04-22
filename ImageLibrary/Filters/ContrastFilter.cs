using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Filters
{
    public class ContrastFilter : AbstractFilter
    {
        public ContrastFilter(int contrastLevel)
        {
            float c = (float) (256+contrastLevel)/255;
            float t = (1f - c)*0.5f;
            _matrix = new float[][]
            {
                new float[]{c, 0, 0, 0, 0},
                new float[]{0, c, 0, 0, 0}, 
                new float[]{0, 0, c, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new float[]{t, t, t, 0, 1}, 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
