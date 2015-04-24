using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using AForge.Imaging.Filters;
using ImageLibrary.Annotations;
using ImageLibrary.Filters;
using IFilter = ImageLibrary.Filters.IFilter;

namespace ImageLibrary
{
    public class EditableImage: INotifyPropertyChanged
    {
        private Bitmap _sourceImage;
        private Bitmap _imageView;
        private String _path;
        private ComplementFilter filter;

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
            filter = new ComplementFilter();
        }

        public void ChangeBrightness(int brightness)
        {
            IFilter f = new BrightnessFilter(brightness);
            filter.AddOrUpdateFilter(f);
            ImageView = filter.Apply(_sourceImage);
        }

        public void ChangeContrast(int contrast)
        {
            IFilter f = new ContrastFilter(contrast);
            filter.AddOrUpdateFilter(f);
            ImageView = filter.Apply(_sourceImage);
        }

        public void ChangeSaturation(int saturation)
        {
            IFilter f = new SaturationFilter(saturation);
            filter.AddOrUpdateFilter(f);
            ImageView = filter.Apply(_sourceImage);
        }

        public bool IsChanged()
        {
            return _sourceImage != _imageView;
        }

        public void Save()
        {
            ImageView.Save(_path);
            _sourceImage = ImageView;
        }

        public void Save(String path)
        {
            ImageView.Save(path);
            _sourceImage = ImageView;
        }

        public void ChangeColor(int red, int green, int blue)
        {
            IFilter f = new ColorFilter(red, green, blue);
            filter.AddOrUpdateFilter(f);
            ImageView = filter.Apply(_sourceImage);
        }
    }
}
