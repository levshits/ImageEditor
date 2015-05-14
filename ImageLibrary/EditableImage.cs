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
        private Bitmap sourceImage;
        private Bitmap imageView;
        private readonly String path;
        private readonly ComplementFilter filter;
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set
            {
                rectangle = value;
                DrawSelectionRect(sourceImage);
            }
        }

        public Bitmap ImageView
        {
            get { return imageView; }
            private set
            {
                imageView = value;
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
            sourceImage = new Bitmap(path);
            this.path = path;
            ImageView = new Bitmap(sourceImage);
            filter = new ComplementFilter();
            Rectangle = Rectangle.Empty;
        }

        private void DrawSelectionRect(Bitmap sourceImage)
        {
            if (Rectangle != Rectangle.Empty)
            {
                var tempBitmap = new Bitmap(sourceImage);
                Graphics g = Graphics.FromImage(tempBitmap);
                {
                    g.DrawRectangle(new Pen(Color.Crimson, 3), Rectangle);
                }
                ImageView = tempBitmap;
                GC.Collect();
            }
        }
        public void ChangeBrightness(int brightness)
        {
            IFilter f = new BrightnessFilter(brightness);
            filter.AddOrUpdateFilter(f);
            ApplyFilter();
            DrawSelectionRect(imageView);
        }

        public void ChangeContrast(int contrast)
        {
            IFilter f = new ContrastFilter(contrast);
            filter.AddOrUpdateFilter(f);
            ApplyFilter();
            DrawSelectionRect(imageView);
        }

        public void ChangeSaturation(int saturation)
        {
            IFilter f = new SaturationFilter(saturation);
            filter.AddOrUpdateFilter(f);
            ApplyFilter();
            DrawSelectionRect(imageView);
        }

        private void ApplyFilter()
        {
            if (Rectangle == Rectangle.Empty)
            {
                ImageView = filter.Apply(sourceImage);
            }
            else
            {
                ImageView = filter.Apply(sourceImage, Rectangle);
            }
        }

        public bool IsChanged()
        {
            return sourceImage != imageView;
        }

        public void Save()
        {
            var extension = Path.GetExtension(path);
            if (extension != null)
            {
                extension = extension.ToLower();
                File.Delete(path);
                ApplyFilter();
                sourceImage.Dispose();
                ImageView.Save(path, StringToImageExtensionConverter.Convert(extension));
            }
            sourceImage = ImageView;
        }

        public void Save(String path)
        {
            var extension = Path.GetExtension(path);
            if (extension != null)
            {
                extension = extension.ToLower();
                ApplyFilter();
                ImageView.Save(path, StringToImageExtensionConverter.Convert(extension));
            }
            sourceImage = ImageView;
        }

        public void ChangeColor(int red, int green, int blue)
        {
            IFilter f = new ColorFilter(red, green, blue);
            filter.AddOrUpdateFilter(f);
            ApplyFilter();
            DrawSelectionRect(imageView);
        }
    }
}
