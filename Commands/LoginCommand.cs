using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels;
using System;
using NewBankAccount.Domain.Exceptions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace NewBankAccount.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        #region Constructor and Fields

        private readonly IViewModelNavigator _viewModelNavigator;
        private readonly IAuthenticationControl _authenticationControl;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(IViewModelNavigator viewModelNavigator, IAuthenticationControl authenticationControl, LoginViewModel loginViewModel)
        {
            _viewModelNavigator = viewModelNavigator;
            _authenticationControl = authenticationControl;
            _loginViewModel = loginViewModel;
        }

        #endregion

        public override async Task ExecuteAsync(object? parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;
            //missing exceptions with error messages !!!

            try
            {
                await _authenticationControl.Login(_loginViewModel.Email, _loginViewModel.Password);
                _viewModelNavigator.NavigateTo();
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Nice Try, Wrong Password !!";

            }
            catch (InvalidLoginRegiisterInputException)
            {
                _loginViewModel.ErrorMessage = "Did you forget yourself?";

            }
            catch (Exception)
            {

                _loginViewModel.ErrorMessage = "Mayday Mayday";
            }
        }
    }
}
