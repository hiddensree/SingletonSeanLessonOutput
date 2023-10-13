using NewBankAccount.WPF.MVVM.Factories.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewBankAccount.WPF.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        #region Constructor and Fields

        private readonly IBankAccountNavigationFactory _bankAccountNavigationFactory;
        private readonly IGetCurrentViewModel _GetCurrentViewModel;

        public UpdateViewModelCommand(IBankAccountNavigationFactory bankAccountNavigationFactory, IGetCurrentViewModel getCurrentViewModel)
        {
            _bankAccountNavigationFactory = bankAccountNavigationFactory;
            _GetCurrentViewModel = getCurrentViewModel;
        }

        #endregion

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _GetCurrentViewModel.CurrentViewModel = _bankAccountNavigationFactory.CreateViewModel(viewType);
            }
        }
    }
}
