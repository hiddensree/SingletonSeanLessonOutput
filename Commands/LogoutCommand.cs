using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBankAccount.WPF.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        #region Constructor and Fields

        private readonly IAuthenticationControl _authenticationControl;
        private readonly IGetCurrentViewModel _getCurrentViewModel;
        public ViewModelBase InitilizeViewModel => _login(); //repetitive but effective!!!
        private CreateViewModel<LoginViewModel> _login;

        public LogoutCommand(IAuthenticationControl authenticationControl, IGetCurrentViewModel getCurrentViewModel , CreateViewModel<LoginViewModel> login)
        {
            _login = login;
            _authenticationControl = authenticationControl;
            _getCurrentViewModel = getCurrentViewModel;
        }
        #endregion

        public override async Task ExecuteAsync(object? parameter)
        {
           
           _authenticationControl.Logout();
           _getCurrentViewModel.CurrentViewModel = _login();
            
          
        }
    }
}
