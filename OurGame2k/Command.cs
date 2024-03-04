using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OurGame2k
{
    public class Command(Action<object?> action, Predicate<object?>? canExecute = null) : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return canExecute?.Invoke(parameter) ?? true; // возможность вызова проверяем с помощью вапросека
        }
        
        public void Execute(object? parameter)
        {
            action(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
