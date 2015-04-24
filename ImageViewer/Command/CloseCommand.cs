using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class CloseCommand :ICommand
    {
        private EditableImageViewModel _viewModel;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_viewModel.Image != null && _viewModel.Image.IsChanged())
            {
                var result = MessageBox.Show("Do you want close program without saving?", "Warning",
                    MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.MainWindow.Close();
                }
            }
            else
            {
                Application.Current.MainWindow.Close();
            }
        }

        public event EventHandler CanExecuteChanged;

        public CloseCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
