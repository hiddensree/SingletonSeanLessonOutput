using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBankAccount.WPF.Store
{
    public class GetCurrentBankAccount
    {

        private readonly IAccountStore _accountStore;

        public string Iban_Id => _accountStore.CurrentBankAccount?.AccountHolder?.IBan_Id ?? string.Empty;

        public double AccountBalance => _accountStore.CurrentBankAccount?.BankBalance ?? 0; //safe

        public double AccountTelephone => _accountStore.CurrentBankAccount?.AccountHolder?.TelephoneNumber ?? 0; //safe

        public string AccountLastName => _accountStore.CurrentBankAccount?.AccountHolder?.LastName ?? string.Empty;
        public string AccountFirstName => _accountStore.CurrentBankAccount?.AccountHolder?.FirstName ?? string.Empty;
        public string? AccountEmail => _accountStore.CurrentBankAccount?.AccountHolder?.Email ?? string.Empty;

        public IEnumerable<BankTransaction> BankTransactions => _accountStore.CurrentBankAccount?.BankTransactions ?? new List<BankTransaction>();
        public IEnumerable<InternationalMoneyTransfers> BankTransfers => _accountStore.CurrentBankAccount?.BankTransfers ?? new List<InternationalMoneyTransfers>();



        public event Action StateChanged; //lazy way

        public GetCurrentBankAccount(IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += OnStateChanged; //we need to unsubscribe at some point !!!! memoryleaks??? 
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }












    }
}
