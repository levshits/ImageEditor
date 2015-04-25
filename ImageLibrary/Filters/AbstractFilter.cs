using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLibrary.Filters
{
    public abstract class AbstractFilter : IFilter
    {
        protected float[][] _matrix;
        public ColorMatrix Matrix { get; protected set; }

        public float this[int i, int j]
        {
            get { return _matrix[i][j]; }
        }

        public virtual Bitmap Apply(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(Matrix);
            var resultImage = new Bitmap(width, height, Graphics.FromImage(source));
            var g = Graphics.FromImage(resultImage);
            var region = new Rectangle(0, 0, width, height);
            g.DrawImage(source, region, 0, 0, width, height, GraphicsUnit.Pixel, attributes);
            GC.Collect();
            return resultImage; 
        }
    }
}
