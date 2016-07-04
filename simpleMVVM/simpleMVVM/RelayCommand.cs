using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simpleMVVM
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _executeAction;
        private Predicate<object> _canExecuteAction;

        public RelayCommand(Action<object> executeAction, Predicate<object> canExecuteAction = null)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        
        public bool CanExecute(object parameter)
        {
            if(_canExecuteAction==null)
            {
                return true;
            }
            else
            {
                return CanExecute(parameter);
            }
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}


