using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageLibrary;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class OpenCommand:ICommand
    {
        private EditableImageViewModel _viewModel;
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
            var openDialog = new OpenFileDialog() { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;" };
            openDialog.ShowDialog();
            if (File.Exists(openDialog.FileName))
            {
                _viewModel.Image = new EditableImage(openDialog.FileName);
            };
        }

        public event EventHandler CanExecuteChanged;
    }
}
