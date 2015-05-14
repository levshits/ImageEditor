using System;
using System.Drawing;
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
        private readonly EditableImageViewModel viewModel;
        public OpenCommand(EditableImageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (viewModel.Image != null && viewModel.Image.IsChanged())
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
                        viewModel.Image = new EditableImage(openDialog.FileName);
                        viewModel.Image.Rectangle = Rectangle.Empty;
                    }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
