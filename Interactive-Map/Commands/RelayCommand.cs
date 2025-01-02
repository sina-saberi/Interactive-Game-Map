using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Map.Commands
{
    public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : CommandBase
    {
        public override bool CanExecute(object? parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object? parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
    }
}
