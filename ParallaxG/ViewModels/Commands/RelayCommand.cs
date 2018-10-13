using System;
using System.Windows.Input;

namespace ParallaxG.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new NullReferenceException($"{nameof(RelayCommand)} requires {nameof(Action<object>)} for {nameof(Execute)}");
            this.canExecute = canExecute ?? new Predicate<object>((obj) => true);
        }

        public bool CanExecute(object parameter) => canExecute.Invoke(parameter);
        public void Execute(object parameter) => execute.Invoke(parameter);
    }
}
