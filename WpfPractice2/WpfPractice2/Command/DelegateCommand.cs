using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPractice2.Command
{
    using System.Windows.Input;
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod = null)
        {
            execute = executeMethod;
            canExecute = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        private Func<bool> canExecute;
        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? true;    
        }

        private Action execute;
        public void Execute(object parameter)
        {
            execute();
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
