using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using NewBankAccount.WPF.Store;
using NewBankAccount.WPF.Store.AccountStore;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class LocalTransactionViewModel : ViewModelBase
    {

        #region Getters and Setters

        private readonly GetCurrentBankAccount _getCurrentBankAccount;

        private double _deposit { get; set; } = 0;

        public double BankBalance => _getCurrentBankAccount.AccountBalance;

        public double Deposit
        {
            get => _deposit;
            set
            {
                _deposit = value;
                OnPropertyChanged(nameof(Deposit));
                OnPropertyChanged(nameof(BalanceCalc));
            }
        }
        private double _withdraw { get; set; } = 0;

        public double Withdraw
        {
            get => _withdraw;
            set
            {
                _withdraw = value;
                OnPropertyChanged(nameof(Withdraw));
                OnPropertyChanged(nameof(BalanceCalc)); //to update the calculated value !!!!!
            }
        }

        #endregion




        #region Main Logic
        public double BalanceCalc => BankBalance + Deposit - Withdraw; //currently not used !!

        #endregion




        #region Setters for MessageViewModel
        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage
        {
            set
            {
                StatusMessageViewModel.Message = value;
            }
        }


        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set
            {
                ErrorMessageViewModel.Message = value;
            }
        }

        #endregion




        #region Command Declaration

        public ICommand DepositCommand { get; }
        public ICommand WithdrawCommand { get; }

        #endregion




        #region Constructor

        public LocalTransactionViewModel(ITransactionService transactionService, IAccountStore accountStore ,GetCurrentBankAccount getCurrentBankAccount)
        {
            _getCurrentBankAccount = getCurrentBankAccount;
            DepositCommand = new DepositCommand(accountStore, transactionService, this);
            WithdrawCommand = new WithdrawCommand(accountStore, transactionService, this);

            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel(); 
        }

        #endregion
    }
}
