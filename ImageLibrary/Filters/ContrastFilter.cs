using System;
using System.Drawing.Imaging;

namespace ImageLibrary.Filters
{
    public class ContrastFilter : AbstractFilter
    {
        public ContrastFilter(int contrastLevel)
        {
            var c =  (float)(Math.Pow(Math.E,(double)(256+contrastLevel*2)/255)/Math.E);
            var t = (1f - c)*0.5f;
            _matrix = new[]
            {
                new[]{c, 0, 0, 0, 0},
                new[]{0, c, 0, 0, 0}, 
                new[]{0, 0, c, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new[]{t, t, t, 0, 1} 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
