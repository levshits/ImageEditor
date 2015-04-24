using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class SaveCommand:ICommand
    {
        private EditableImageViewModel _viewModel;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.Image != null)
            {
                _viewModel.Image.Save();
            }
        }

        public event EventHandler CanExecuteChanged;

        public SaveCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
