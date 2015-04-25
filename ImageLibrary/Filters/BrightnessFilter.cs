using System.Drawing.Imaging;

namespace ImageLibrary.Filters
{
    class BrightnessFilter : AbstractFilter
    {
        public BrightnessFilter(int brightness)
        {
            var b = (float)brightness/255;
            _matrix = new[]
            {
                new float[]{1, 0, 0, 0, 0},
                new float[]{0, 1, 0, 0, 0}, 
                new float[]{0, 0, 1, 0, 0}, 
                new float[]{0, 0, 0, 1, 0}, 
                new[]{b, b, b, 0, 1} 
            };
            Matrix = new ColorMatrix(_matrix);
        }
    }
}
