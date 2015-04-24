using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageLibrary;

namespace ImageViewerWinForms
{
    public partial class MainView : Form
    {
        private EditableImage _image;
        public MainView()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if(System.IO.File.Exists(openFileDialog.FileName))
                _image = new EditableImage(openFileDialog.FileName);
            ImageBox.Image = _image.ImageView;
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

        private void brightnessLevel_ValueChanged(object sender, EventArgs e)
        {
            
            _image.ChangeBrightness(brightnessLevel.Value);
            ImageBox.imageBox.Image = _image.ImageView;

        }

        private void contrastLevel_ValueChanged(object sender, EventArgs e)
        {
            _image.ChangeContrast(contrastLevel.Value);
            ImageBox.imageBox.Image = _image.ImageView;
        }

        private void ColorLevel_ValueChanged(object sender, EventArgs e)
        {
            _image.ChangeColor(RedLevel.Value, GreenLevel.Value, BlueLevel.Value);
            ImageBox.imageBox.Image = _image.ImageView;
        }

        private void saturationLevel_ValueChanged(object sender, EventArgs e)
        {
            _image.ChangeSaturation(saturationLevel.Value);
            ImageBox.imageBox.Image = _image.ImageView;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image != null)
            {
                _image.Save();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                if (!System.IO.File.Exists(saveFileDialog.FileName) && saveFileDialog.FileName != "")
                {
                    _image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image != null && _image.IsChanged())
            {
                var result = MessageBox.Show("Do you want close program without saving?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
