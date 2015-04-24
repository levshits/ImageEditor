using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(Matrix);
            Graphics g = default(System.Drawing.Graphics);
            Bitmap resultImage = new Bitmap(width, height, Graphics.FromImage(source));
            g = Graphics.FromImage(resultImage);
            Rectangle region = new Rectangle(0, 0, width, height);
            g.DrawImage(source, region, 0, 0, width, height, GraphicsUnit.Pixel, attributes);
            GC.Collect();
            return resultImage; 
        }
    }
}
