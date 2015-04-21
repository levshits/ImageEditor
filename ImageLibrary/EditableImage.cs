using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using AForge.Imaging.Filters;
using ImageLibrary.Annotations;

namespace ImageLibrary
{
    public class EditableImage: INotifyPropertyChanged
    {
        private Bitmap _sourceImage;
        private Bitmap _imageView;
        private String _path;

        public Bitmap ImageView
        {
            get { return _imageView; }
            private set
            {
                _imageView = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged
        public EditableImage(String path)
        {
            _sourceImage = new Bitmap(path);
            _path = path;
            ImageView = _sourceImage;
        }

        public void ChangeBrightness(int brightness)
        {
            _imageView = _sourceImage.Clone(
                new Rectangle(0, 0, _sourceImage.Width, _sourceImage.Height),
                _sourceImage.PixelFormat);
            for (int i = 0; i < _imageView.Width; i++)
            {
                for (int j = 0; j < _imageView.Height; j++)
                {
                    Color color = _sourceImage.GetPixel(i, j);
                    _sourceImage.SetPixel(i, j, color);
                }
            }
        }

        public void ChangeContrast(int contrast)
        {
            BrightnessCorrection filter = new BrightnessCorrection();
            filter.Apply(_sourceImage);
        }

        public void ChangeSaturation(float saturation)
        {
        }

        public bool IsChanged()
        {
            return _sourceImage != _imageView;
        }

        public void Save()
        {
            ImageView.Save(_path);
        }

        public void Save(String path)
        {
            ImageView.Save(path);
        }
    }
}
