using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserManagement.WPF.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _executeSync;
        private readonly Func<Task> _executeAsync;
        private readonly Func<bool> _canExecute;
        private bool _isExecuting;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _executeSync = execute ?? throw new ArgumentNullException(nameof(execute));
            _executeAsync = null;
            _canExecute = canExecute;
        }

        public RelayCommand(Func<Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Func<Task> execute, Func<bool> canExecute)
        {
            _executeAsync = execute ?? throw new ArgumentNullException(nameof(execute));
            _executeSync = null;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            try
            {
                _isExecuting = true;
                CommandManager.InvalidateRequerySuggested();

                if (_executeAsync != null)
                {
                    await _executeAsync();
                }
                else
                {
                    _executeSync();
                }
            }
            finally
            {
                _isExecuting = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}