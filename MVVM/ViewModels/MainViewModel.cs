using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using System;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Private Fields

        private readonly IBankAccountNavigationFactory _bankAccountNavigationFactory;
        private readonly IGetCurrentViewModel _GetCurrentViewModel;
        private readonly IAuthenticationControl _authenticationControl;
        private CreateViewModel<LoginViewModel> _login;

        #endregion



        #region Public Fields 

        public ViewModelBase CurrentViewModel => _GetCurrentViewModel.CurrentViewModel;

        public bool IsLoggedIn => _authenticationControl.IsLoggedIn;

        public ViewModelBase InitilizeViewModel => _login();

        #endregion



        #region Command Declaration

        public ICommand UpdateViewModelCommand { get; }
        public ICommand LogoutCommand { get; }

        #endregion



        #region Constructor
        public MainViewModel(
            IBankAccountNavigationFactory bankAccountNavigationFactory, 
            IGetCurrentViewModel getCurrentViewModel, 
            CreateViewModel<LoginViewModel> login,
            IAuthenticationControl authenticationControl)
        {
            _authenticationControl = authenticationControl;
            _bankAccountNavigationFactory = bankAccountNavigationFactory;
            _GetCurrentViewModel = getCurrentViewModel;
            _login = login;


            _GetCurrentViewModel.StateChanged += GetCurrentViewModelStateChanged;
            _authenticationControl.StateChanged += ControlStateChanged;

            UpdateViewModelCommand = new UpdateViewModelCommand(_bankAccountNavigationFactory, _GetCurrentViewModel);
            _GetCurrentViewModel.CurrentViewModel = _login();
            //UpdateViewModelCommand.Execute(ViewType.GlobalTransaction);  //tesging purpose !!!
            LogoutCommand = new LogoutCommand(authenticationControl, _GetCurrentViewModel, _login);
        }

        #endregion



        #region Subscriptions

        private void ControlStateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void GetCurrentViewModelStateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(InitilizeViewModel));
        }

        #endregion



    }
}
