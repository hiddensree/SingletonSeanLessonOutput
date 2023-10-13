using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using System.Security.Cryptography.Xml;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        #region Getters and Setters

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        #endregion



        #region Setters for MessageViewModel
        /// <summary>
        /// Here we  use messageviewmodel -- only interested in errors 
        /// </summary>
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage //actual exception message connected to the login command 
        {
            set
            {
                ErrorMessageViewModel.Message = value;
            }
        }
        #endregion




        #region Command Declaration

        public ICommand LoginCommand { get; }
        public ICommand NavigateToLoginRegisterViewCommand { get; }

        #endregion



        #region Constructor

        public LoginViewModel(IViewModelNavigator loginviewModelNavigator, IAuthenticationControl authenticationControl, IViewModelNavigator registerviewModelNavigator )
        {
            LoginCommand = new LoginCommand(loginviewModelNavigator, authenticationControl, this);

            NavigateToLoginRegisterViewCommand = new NavigateToLoginRegisterViewCommand(registerviewModelNavigator);

            ErrorMessageViewModel = new MessageViewModel();

        }

        #endregion




    }
}
