using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using ImageLibrary;
using ImageViewer.ViewModel;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class OpenCommand:ICommand
    {
        private readonly EditableImageViewModel _viewModel;
        public OpenCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.Image != null && _viewModel.Image.IsChanged())
            {
                var result = MessageBox.Show("Do you want open other image without saving?", "Warning",
                    MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    return;
                }

            }
            var openDialog = new OpenFileDialog {Filter = "Image Files|*.jpg;*.png;*.gif;*.bmp;"};
                    openDialog.ShowDialog();
                    if (File.Exists(openDialog.FileName))
                    {
                        _viewModel.Image = new EditableImage(openDialog.FileName);
                    }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
