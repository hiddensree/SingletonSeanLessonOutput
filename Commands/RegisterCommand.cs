using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels;
using System.Threading.Tasks;
using static NewBankAccount.Domain.Interfaces.IAuthenticationService;

namespace NewBankAccount.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        #region Constructor and Fields
        private readonly IViewModelNavigator _viewModelNavigator;
        private readonly IAuthenticationControl _authenticationControl;
        private readonly RegisterViewModel _registerViewModel;

        public RegisterCommand(IViewModelNavigator viewModelNavigator, IAuthenticationControl authenticationControl, RegisterViewModel registerViewModel)
        {
            _viewModelNavigator = viewModelNavigator;
            _authenticationControl = authenticationControl;
            _registerViewModel = registerViewModel;
        }

        #endregion


        public override async Task ExecuteAsync(object? parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;
            RegistrationResult registrationResult = await _authenticationControl.Register(
                _registerViewModel.FirstName, 
                _registerViewModel.LastName, 
                _registerViewModel.Email, 
                _registerViewModel.Telephone, 
                _registerViewModel.Password, 
                _registerViewModel.ConfirmPassword);

            switch (registrationResult)
            {
                case RegistrationResult.Success:
                    _viewModelNavigator.NavigateTo();
                    break;
                case RegistrationResult.PasswordsDoNotMatch: 
                    _registerViewModel.ErrorMessage = "Lacks Focus, Concentrate !!!";
                    break;
                case RegistrationResult.EmailAlreadyExists:
                    _registerViewModel.ErrorMessage = "Forget your past? !!!!";
                    break;
                case RegistrationResult.ObligatoyDataMissing:
                    _registerViewModel.ErrorMessage = "Missing Something?";
                    break;
                case RegistrationResult.WrongTelephone:
                    _registerViewModel.ErrorMessage = "Dont ghost me, Valid Number Please";
                    break;
                default: 
                    break;
            }
        }
    }
}
