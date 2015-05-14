using System;
using System.Drawing;
using System.Windows.Forms;
using ImageLibrary;

namespace ImageViewerWinForms
{
    public partial class ZoomAndPanImageBox : UserControl
    {
        public ZoomAndPanImageBox()
        {
            InitializeComponent();
        }

        public EditableImage EditableImage { get; set; }

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
                    zoomValue = 1;
                    imageBox.Size = value.Size;
                }
                else
                {
                    zoomValue = (double) (panel.Height)/value.Height;
                    imageBox.Size = new Size(Convert.ToInt32(value.Width*zoomValue), Convert.ToInt32(value.Height*zoomValue));
                }
            }
            else
            {
                if (panel.Width > value.Width)
                {
                    zoomValue = 1;
                    imageBox.Size = value.Size;
                }
                else
                {
                    zoomValue = (double) (panel.Width)/value.Width;
                    imageBox.Size = new Size(Convert.ToInt32(value.Width*zoomValue), Convert.ToInt32(value.Height*zoomValue));
                }
            }
        }
    }
}
