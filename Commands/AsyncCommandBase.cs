using System.Threading.Tasks;
using System;
using System.Windows.Input;

namespace NewBankAccount.WPF.Commands
{
    /// <summary>
    /// Custom Command Base USING Task<> and Async
    /// Also with Conditional IsExecuting 
    /// </summary>
    public abstract class AsyncCommandBase : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        #region Exception Handler if needed
        //public Action<Exception> _onException { get; }
        //public AsyncCommandBase(Action<Exception> onException)
        //{
        //    _onException = onException;
        //}
        #endregion

        #region PropChange for IsExcuting
        private bool _isExecuting;
        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion


        public bool CanExecute(object? parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object? parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);


            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object? parameter);  //Investigate the usage of this method !!!!
    }
}
