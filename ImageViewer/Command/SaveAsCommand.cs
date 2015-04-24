using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace ImageViewer.Command
{
    class SaveAsCommand:ICommand
    {
        private EditableImageViewModel _viewModel;

        public SaveAsCommand(EditableImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            if (!File.Exists(saveFileDialog.FileName))
            {
                _viewModel.Image.Save(saveFileDialog.FileName);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
