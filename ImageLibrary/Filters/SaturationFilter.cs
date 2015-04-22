using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Filters
{
    public class SaturationFilter : AbstractFilter
    {
        private float lumR = (float) 0.3086;
        private float lumG = (float) 0.6094;
        private float lumB = (float) 0.0820;

        public SaturationFilter(int saturation)
        {
            var s = (float)saturation / 255;
            float sr = (1 - s) * lumR;
            float sg = (1 - s) * lumG;
            float sb = (1 - s) * lumB;
            _matrix = new float[][]
            {
                new float[]{sr+s, sr, sr, 0, 0},
                new float[]{sg, sg+s, sg, 0, 0}, 
                new float[]{sb, sb, sb+s, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new float[]{0, 0, 0, 0, 1}, 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
