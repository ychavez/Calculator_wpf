using System;
using System.Windows.Input;

namespace Productos_wpf.Handlers
{
    public delegate bool delCanExecute(object parameter);
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;
        public CommandHandler(Action action1, Func<bool> action2)
        {
            _action = action1;
            _canExecute = action2;
        }

        public bool CanExecute(object parameter)
        {
            bool res = _canExecute();
            return res;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        public event EventHandler CanExecuteChanged;
    }
}
