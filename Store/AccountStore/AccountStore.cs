using NewBankAccount.Domain.Models;
using System;

namespace NewBankAccount.WPF.Store.AccountStore
{
    /// <summary>
    /// Account store mainly used for storing an account !!!!
    /// VIEWMODELS USE This account!!!
    /// Inject your current account here !!!
    /// </summary>
    public class AccountStore : IAccountStore
    {
        private BankAccount? _currentBankAccount;
        public BankAccount CurrentBankAccount
        {
            get
            {
                return _currentBankAccount;

            }
            set
            {
                _currentBankAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
