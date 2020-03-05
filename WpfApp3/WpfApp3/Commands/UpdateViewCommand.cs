using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp3.ViewModels;

namespace WpfApp3.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel _viewModel;


        public UpdateViewCommand(MainViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Judges")
            {
                _viewModel.SelectedViewModel = new JudgeViewModel();
            }else if(parameter.ToString() == "Simple")
            {
                _viewModel.SelectedViewModel = new SimpleViewModel();
            }
        }
    }
}
