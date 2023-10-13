using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        #region Getter and Setters
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private double _telephone;
        public double Telephone
        {
            get => _telephone;
            set
            {
                _telephone = value;
                OnPropertyChanged(nameof(Telephone));
            }
        }


        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _confirmpassword;
        public string ConfirmPassword
        {
            get => _confirmpassword;
            set
            {
                _confirmpassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        #endregion



        #region Setters for MessageViewModel
        /// <summary>
        /// Here we  use messageviewmodel -- only interested in errors 
        /// </summary>
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage //actual exception message connected to the register command 
        {
            set
            {
                ErrorMessageViewModel.Message = value;
            }
        }
        #endregion



        #region Command Declaration

        public ICommand RegisterCommand { get; }
        public ICommand NavigateToLoginRegisterViewCommand { get; }

        #endregion



        #region Constructor

        public RegisterViewModel(IViewModelNavigator registerviewModelNavigator, IAuthenticationControl authenticationControl, IViewModelNavigator loginviewmodelNavigator)
        {


            RegisterCommand = new RegisterCommand(registerviewModelNavigator, authenticationControl , this);
            NavigateToLoginRegisterViewCommand = new NavigateToLoginRegisterViewCommand(loginviewmodelNavigator);
            ErrorMessageViewModel = new MessageViewModel();

        }

        #endregion












    }
}
