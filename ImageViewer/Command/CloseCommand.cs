using System;
using System.Windows;
using System.Windows.Input;
using ImageViewer.ViewModel;

namespace ImageViewer.Command
{
    class CloseCommand :ICommand
    {
        private readonly EditableImageViewModel viewModel;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (viewModel.Image != null && viewModel.Image.IsChanged())
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
            this.viewModel = viewModel;
        }
    }
}
