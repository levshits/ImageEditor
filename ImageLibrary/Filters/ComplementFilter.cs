using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLibrary.Filters
{
    class ComplementFilter: AbstractFilter
    {
        private Dictionary<Type, IFilter> filters = new Dictionary<Type, IFilter>(); 
        public ComplementFilter() { }

        public void AddOrUpdateFilter(IFilter filter)
        {
            filters[filter.GetType()] = filter;
        }

        public override Bitmap Apply(Bitmap source)
        {
            ComputeResultMatrix();
            var result = base.Apply(source);
            GC.Collect();
            return result;
        }

        private void ComputeResultMatrix()
        {
            Matrix = null;
            _matrix = null;
            foreach (var filter in filters)
            {
                if (_matrix == null)
                {
                    _matrix = new float[5][];
                    for (int i = 0; i < 5; i++)
                    {
                        _matrix[i] = new float[5];
                        for (int j = 0; j < 5; j++)
                        {
                            _matrix[i][j] = filter.Value[i, j];
                        }
                    }
                }
                else
                {             
                    var temp = new float[5][];
                    for (int i = 0; i < 5; i++)
                    {
                        temp[i] = new float[5];
                    }

                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            for (int inner = 0; inner < 5; inner++)
                            {
                                temp[row][col] += _matrix[row][inner]*filter.Value[inner, col];
                            }
                        }
                    }
                    _matrix = temp;
                }
                Matrix = new ColorMatrix(_matrix);
            }
        }

    }
}
