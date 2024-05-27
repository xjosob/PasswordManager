using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Utilities
{
    public class CommandParam : ICommand
    {
        readonly Action<Parameter> _execute;
        readonly Predicate<Parameter> _canExecute;


        public CommandParam(Action<Parameter> execute) : this(execute, null) { }

        public CommandParam(Action<Parameter> execute, Predicate<Parameter> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            if (parameter is Parameter p)
                _execute?.Invoke(p);
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is Parameter p)
                return _canExecute == null || _canExecute(p);
            return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
