using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Commands
{
    public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : CommandBase
    {
        private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        private readonly Func<object?, bool>? _canExecute = canExecute;

        public override bool CanExecute(object? parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) =>
            _execute(parameter);

        public void RaiseCanExecuteChanged() =>
            OnCanExecuteChanged();
    }
}
