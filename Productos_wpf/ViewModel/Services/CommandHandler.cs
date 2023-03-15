using System;
using System.Windows.Input;

namespace Productos_wpf.ViewModel.Services
{
    public class CommandHandler : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public CommandHandler(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
          => canExecute();

        public void Execute(object? parameter)
        => execute();
    }
}
