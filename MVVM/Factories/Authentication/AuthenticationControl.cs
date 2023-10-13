using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewBankAccount.Domain.Interfaces.IAuthenticationService;

namespace NewBankAccount.WPF.MVVM.Factories.Authentication
{
    public class AuthenticationControl : IAuthenticationControl
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public BankAccount? CurrentBankAccount
        {
            get
            {
                return _accountStore.CurrentBankAccount;
            }

            private set
            {
                _accountStore.CurrentBankAccount = value;
                StateChanged?.Invoke();
            }
        }


        public AuthenticationControl(IAuthenticationService authenticationService, IAccountStore store)
        {
            _authenticationService = authenticationService;
            _accountStore = store;
        }

        public event Action StateChanged;

        public bool IsLoggedIn => CurrentBankAccount != null;


      
        public async Task Login(string email, string password)
        {
           CurrentBankAccount =  await _authenticationService.Login(email, password);
        }

        public void Logout()
        {
            CurrentBankAccount = null;
        }

        public async Task<RegistrationResult> Register(string firstName, string lastName, string email, double telephoneNumber, string password, string confirmPassword)
        {
            return await _authenticationService.Register(firstName, lastName, email, telephoneNumber, password, confirmPassword);
        }
    }
}
