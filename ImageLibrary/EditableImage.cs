using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ImageLibrary.Annotations;
using ImageLibrary.Filters;

namespace ImageLibrary
{
    public class EditableImage: INotifyPropertyChanged
    {
        private Bitmap _sourceImage;
        private Bitmap _imageView;
        private String _path;
        private ComplementFilter _filter;

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
            _filter = new ComplementFilter();
        }

        public void ChangeBrightness(int brightness)
        {
            IFilter f = new BrightnessFilter(brightness);
            _filter.AddOrUpdateFilter(f);
            ImageView = _filter.Apply(_sourceImage);
        }

        public void ChangeContrast(int contrast)
        {
            IFilter f = new ContrastFilter(contrast);
            _filter.AddOrUpdateFilter(f);
            ImageView = _filter.Apply(_sourceImage);
        }

        public void ChangeSaturation(int saturation)
        {
            IFilter f = new SaturationFilter(saturation);
            _filter.AddOrUpdateFilter(f);
            ImageView = _filter.Apply(_sourceImage);
        }

        public bool IsChanged()
        {
            return _sourceImage != _imageView;
        }

        public void Save()
        {
            var extension = Path.GetExtension(_path);
            if (extension != null)
            {
                extension = extension.ToLower();
                _sourceImage.Dispose();
                File.Delete(_path);
                ImageView.Save(_path, StringToImageExtensionConverter.Convert(extension));
            }
            _sourceImage = ImageView;
        }

        public void Save(String path)
        {
            var extension = Path.GetExtension(path);
            if (extension != null)
            {
                extension = extension.ToLower();
                ImageView.Save(path, StringToImageExtensionConverter.Convert(extension));
            }
            _sourceImage = ImageView;
        }

        public void ChangeColor(int red, int green, int blue)
        {
            IFilter f = new ColorFilter(red, green, blue);
            _filter.AddOrUpdateFilter(f);
            ImageView = _filter.Apply(_sourceImage);
        }
    }
}
