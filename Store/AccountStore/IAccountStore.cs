using NewBankAccount.Domain.Models;
using System;

namespace NewBankAccount.WPF.Store.AccountStore
{
    public interface IAccountStore
    {

        BankAccount CurrentBankAccount { get; set; }
        event Action StateChanged;

    }
}
