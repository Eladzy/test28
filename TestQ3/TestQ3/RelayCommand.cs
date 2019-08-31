using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestQ3
{
    class RelayCommand : ICommand
    {
        
        Action<object> _executeMethod;
        Func<object, bool> _canExecute;
        public RelayCommand(Func<object, bool> canExecute, Action<object> executeMethod)
        {
            this._canExecute = canExecute;
            this._executeMethod = executeMethod;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._executeMethod(parameter);
        }
    }
}
