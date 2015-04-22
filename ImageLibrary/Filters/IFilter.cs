using System.Drawing;
using System.Drawing.Imaging;

namespace ImageLibrary.Filters
{
    public interface IFilter
    {
        ColorMatrix Matrix { get; }
        Bitmap Apply(Bitmap source);
        float this[int i, int j] { get; }
    }
}