using System;
using System.IO;
using System.Windows.Input;
using ImageViewer.ViewModel;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class SaveAsCommand:ICommand
    {
        private readonly EditableImageViewModel _viewModel;

        public SaveAsCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.Image != null;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { DefaultExt = "*.jpg", Filter = "jpg|*.jpg;| png|*.png;| bmp|*.bmp;| gif|*.gif;" };
                saveFileDialog.ShowDialog();
                if (!File.Exists(saveFileDialog.FileName) && saveFileDialog.FileName != "")
                {
                    
                    _viewModel.Image.Save(saveFileDialog.FileName);
                    _viewModel.Reset();
                }
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
