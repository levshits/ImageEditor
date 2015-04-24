using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ImageLibrary;
using ImageLibrary.Annotations;
using ImageViewer.Command;

namespace ImageViewer
{
    public class EditableImageViewModel:INotifyPropertyChanged
    {
        
        private EditableImage _image;

        public EditableImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        private int _brightness;

        public int Brightness
        {
            get { return _brightness; }
            set
            {
                _brightness = value;
                Image.ChangeBrightness(value);
                OnPropertyChanged();
            }
        }

        private int _contrast;

        public int Contrast
        {
            get { return _contrast; }
            set
            {
                _contrast = value;
                Image.ChangeContrast(value);
                OnPropertyChanged();
            }
        }

        private int _saturation;

        public int Saturation
        {
            get { return _saturation; }
            set
            {
                _saturation = value;
                Image.ChangeSaturation(value);
                OnPropertyChanged();
            }
        }

        private int _red;

        public int Red
        {
            get { return _red; }
            set
            {
                _red = value;
                Image.ChangeColor(Red, Green, Blue);
                OnPropertyChanged();
            }
        }

        private int _green;

        public int Green
        {
            get { return _green; }
            set
            {
                _green = value;
                Image.ChangeColor(Red, Green, Blue);
                OnPropertyChanged();
            }
        }

        private int _blue;

        public int Blue
        {
            get { return _blue; }
            set
            {
                _blue = value;
                Image.ChangeColor(Red, Green, Blue);
                OnPropertyChanged();
            }
        }

        //public float Saturation
        //{
        //    get { return _saturation; }
        //    set
        //    {
        //        _saturation = value;
        //        Image.ChangeSaturation(value);
        //        OnPropertyChanged();
        //    }
        //}

        public ICommand OpenCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveAsCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public EditableImageViewModel()
        {
            OpenCommand = new OpenCommand(this);
            SaveCommand = new SaveCommand(this);
            SaveAsCommand = new SaveAsCommand(this);
            CloseCommand = new CloseCommand(this);

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
    }
}
