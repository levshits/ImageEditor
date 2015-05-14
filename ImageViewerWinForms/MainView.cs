using System;
using System.Windows.Forms;
using ImageLibrary;

namespace ImageViewerWinForms
{
    public partial class MainView : Form
    {
        private EditableImage image;
        public MainView()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Image Files|*.jpg;*.png;*.gif;*.bmp;" };
            openFileDialog.ShowDialog();
            if(System.IO.File.Exists(openFileDialog.FileName))
                image = new EditableImage(openFileDialog.FileName);
            ImageBox.EditableImage = image;
            ImageBox.Image = image.ImageView;
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
            
            image.ChangeBrightness(brightnessLevel.Value);
            ImageBox.Image = image.ImageView;

        }

        private void contrastLevel_ValueChanged(object sender, EventArgs e)
        {
            image.ChangeContrast(contrastLevel.Value);
            ImageBox.Image = image.ImageView;
        }

        private void ColorLevel_ValueChanged(object sender, EventArgs e)
        {
            image.ChangeColor(RedLevel.Value, GreenLevel.Value, BlueLevel.Value);
            ImageBox.Image = image.ImageView;
        }

        private void saturationLevel_ValueChanged(object sender, EventArgs e)
        {
            image.ChangeSaturation(saturationLevel.Value);
            ImageBox.Image = image.ImageView;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                image.Save();
                Reset();
            }
        }

        private void Reset()
        {
            saturationLevel.Value = 0;
            contrastLevel.Value = 0;
            brightnessLevel.Value = 0;
            RedLevel.Value = 0;
            GreenLevel.Value = 0;
            BlueLevel.Value = 0;
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { DefaultExt = "*.jpg", Filter = "jpg|*.jpg;| png|*.png;| bmp|*.bmp;| gif|*.gif;" };
                saveFileDialog.ShowDialog();
                if (!System.IO.File.Exists(saveFileDialog.FileName) && saveFileDialog.FileName != "")
                {
                    image.Save(saveFileDialog.FileName);
                    Reset();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null && image.IsChanged())
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
        private void Selection_Click(object sender, EventArgs e)
        {
            Reset();
            ImageBox.SelectionIsActive = true;
        }

        private void Pan_Click(object sender, EventArgs e)
        {
            ImageBox.Image = image.ImageView;
            ImageBox.SelectionIsActive = false;
        }
    }
}
