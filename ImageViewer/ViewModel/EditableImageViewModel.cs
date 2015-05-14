using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ImageLibrary;
using ImageLibrary.Annotations;
using ImageViewer.Command;
using Microsoft.Expression.Interactivity.Core;

namespace ImageViewer.ViewModel
{
    public class EditableImageViewModel:INotifyPropertyChanged
    {
        
        private EditableImage image;

        public EditableImage Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        private int brightness;

        public int Brightness
        {
            get { return brightness; }
            set
            {
                brightness = value;
                OnPropertyChanged();
            }
        }

        private int contrast;

        public int Contrast
        {
            get { return contrast; }
            set
            {
                contrast = value;
                OnPropertyChanged();
            }
        }

        private int saturation;

        public int Saturation
        {
            get { return saturation; }
            set
            {
                saturation = value;
                OnPropertyChanged();
            }
        }

        
        private int red;

        public int Red
        {
            get { return red; }
            set
            {
                red = value;
                OnPropertyChanged();
            }
        }

        private int green;

        public int Green
        {
            get { return green; }
            set
            {
                green = value;
                OnPropertyChanged();
            }
        }

        private int blue;

        public int Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                OnPropertyChanged();
            }
        }

        public void OnBrightnessChanged()
        {
            Image.ChangeBrightness(Brightness);
        }
        public void OnSaturationChanged()
        {
            Image.ChangeSaturation(Saturation);
        }
        public void OnContrastChanged()
        {
            Image.ChangeContrast(Contrast);
        }

        public void OnColorChanged()
        {
            Image.ChangeColor(Red, Green, Blue);
        }

        public void Reset()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Brightness = 0;
            Contrast = 0;
            Saturation = 0;
        }

        public ICommand OpenCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveAsCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand SelectionCommand { get; private set; }
        public ICommand PanCommand { get; private set; }

        public bool SelectionActivated = false;

        public EditableImageViewModel()
        {
            OpenCommand = new OpenCommand(this);
            SaveCommand = new SaveCommand(this);
            SaveAsCommand = new SaveAsCommand(this);
            CloseCommand = new CloseCommand(this);
            SelectionCommand = new ActionCommand( ()=> { SelectionActivated = true; });
            PanCommand = new ActionCommand((() => { SelectionActivated = false; }));


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
