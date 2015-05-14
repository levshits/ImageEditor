using System;
using System.Windows.Input;
using ImageViewer.ViewModel;

namespace ImageViewer.Command
{
    class SaveCommand:ICommand
    {
        private readonly EditableImageViewModel viewModel;
        public bool CanExecute(object parameter)
        {
            return viewModel.Image != null && viewModel.Image.IsChanged();
        }

        public void Execute(object parameter)
        {
            if (viewModel.Image != null)
            {
                viewModel.Image.Save();
                viewModel.Reset();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SaveCommand(EditableImageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
