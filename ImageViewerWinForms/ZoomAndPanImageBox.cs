using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerWinForms
{
    public partial class ZoomAndPanImageBox : UserControl
    {
        public ZoomAndPanImageBox()
        {
            InitializeComponent();
        }

        private void imageBox_Click(object sender, EventArgs e)
        {

        }

        private void CenterImage()
        {
            imageBox.Left = (panel.Width - imageBox.Width)/2;
            imageBox.Top = (panel.Height - imageBox.Height)/2;
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            CenterImage();
        }

        private void ComputeImageBoxSize(Image value)
        {
            double panelCoef = (float) (panel.Width)/panel.Height;
            double valueCoef = (float) (value.Width)/value.Height;
            if (panelCoef > valueCoef)
            {
                if (panel.Height > value.Height)
                {
                    _zoomValue = 1;
                    imageBox.Size = value.Size;
                }
                else
                {
                    _zoomValue = (double) (panel.Height)/value.Height;
                    imageBox.Size = new Size(Convert.ToInt32(value.Width*_zoomValue), Convert.ToInt32(value.Height*_zoomValue));
                }
            }
            else
            {
                if (panel.Width > value.Width)
                {
                    _zoomValue = 1;
                    imageBox.Size = value.Size;
                }
                else
                {
                    _zoomValue = (double) (panel.Width)/value.Width;
                    imageBox.Size = new Size(Convert.ToInt32(value.Width*_zoomValue), Convert.ToInt32(value.Height*_zoomValue));
                }
            }
        }
    }
}
