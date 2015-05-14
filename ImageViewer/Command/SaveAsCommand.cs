using System;
using System.IO;
using System.Windows.Input;
using ImageViewer.ViewModel;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class SaveAsCommand:ICommand
    {
        private readonly EditableImageViewModel viewModel;

        public SaveAsCommand(EditableImageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.Image != null;
        }

        public void Execute(object parameter)
        {
            if (viewModel.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog { DefaultExt = "*.jpg", Filter = "jpg|*.jpg;| png|*.png;| bmp|*.bmp;| gif|*.gif;" };
                saveFileDialog.ShowDialog();
                if (!File.Exists(saveFileDialog.FileName) && saveFileDialog.FileName != "")
                {
                    
                    viewModel.Image.Save(saveFileDialog.FileName);
                    viewModel.Reset();
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
