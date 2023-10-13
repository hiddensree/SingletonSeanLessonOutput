using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using NewBankAccount.WPF.Store;
using NewBankAccount.WPF.Store.AccountStore;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class AccountSettingsViewModel : ViewModelBase
    {
        


        #region Change Details PropChange

        //Predefined Props -- First Name, Last Name, Email, Telephone !!!!
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

        #endregion



        #region ChangePasswordCommand PropChange

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

        private string _newpassword;

        public string NewPassword
        {
            get
            {
                return _newpassword;
            }
            set
            {
                _newpassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string _confirmnewpassword;

        public string ConfirmNewPassword
        {
            get
            {
                return _confirmnewpassword;
            }
            set
            {
                _confirmnewpassword = value;
                OnPropertyChanged(nameof(ConfirmNewPassword));
            }
        }

        #endregion



        #region MessageViewModel

        public MessageViewModel StatusMessageViewModel { get; }
        public string StatusMessage
        {
            set => StatusMessageViewModel.Message = value;
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        #endregion


        public ICommand ModifyAccountDetailsCommand { get; set; }
        public ICommand ModifyPasswordCommand { get; set; }


      
        public AccountSettingsViewModel(IAccountStore accountStore, IModifyAccountDetails modifyAccountDetails)
        {

            ModifyAccountDetailsCommand = new ModifyAccountDetailsCommand(accountStore, this, modifyAccountDetails);
            ModifyPasswordCommand = new ModifyPasswordCommand(accountStore, this, modifyAccountDetails);

            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();

            
        }
    }
}
