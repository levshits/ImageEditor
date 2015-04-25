using System;
using System.Windows.Input;
using ImageViewer.ViewModel;

namespace ImageViewer.Command
{
    class SaveCommand:ICommand
    {
        private readonly EditableImageViewModel _viewModel;
        public bool CanExecute(object parameter)
        {
            return _viewModel.Image != null && _viewModel.Image.IsChanged();
        }

        public void Execute(object parameter)
        {
            if (_viewModel.Image != null)
            {
                _viewModel.Image.Save();
                _viewModel.Reset();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SaveCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
