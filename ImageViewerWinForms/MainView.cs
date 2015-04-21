using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewerWinForms
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.Image = Image.FromFile(@"C:\Users\Valentin\Desktop\Фото\1.jpg");
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if(ImageBox.ZoomValue < 10)
            ImageBox.ZoomValue += .1;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if(ImageBox.ZoomValue > .1)
            ImageBox.ZoomValue -= .1;
        }
    }
}
