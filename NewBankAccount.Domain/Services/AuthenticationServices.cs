using Microsoft.AspNet.Identity;
using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewBankAccount.Domain.Interfaces.IAuthenticationService;

namespace NewBankAccount.Domain.Services
{
    public class AuthenticationServices : IAuthenticationService
    {
        #region Fields and Constructor
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher; 
        private readonly IProvideIBANService _provideIBANService;

        public AuthenticationServices(IAccountService accountService, IPasswordHasher passwordHasher, IProvideIBANService provideIBANService)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
            _provideIBANService = provideIBANService;
        }

        #endregion

        #region LoginCommand Logic
        public async Task<BankAccount> Login(string email, string Password)
        {
            BankAccount storedBankAccount = await _accountService.GetByUserEMAIL(email);
            if (storedBankAccount == null || string.IsNullOrEmpty(email)) //not found or wronlgly written !!!
            {
                throw new InvalidLoginRegiisterInputException(email);
            }

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(storedBankAccount.AccountHolder.PasswordHash, Password);
            if (result != PasswordVerificationResult.Success) //checking for password !!!
            {
                throw new InvalidPasswordException(Password);
            }
            return storedBankAccount;
    
        }

        #endregion


        public async Task<RegistrationResult> Register(string FirstName, string LastName, string Email, double TelephoneNumber, string password, string confirmPassword)
        {
            RegistrationResult registrationResult = RegistrationResult.Success;

            if (string.IsNullOrEmpty(FirstName) || 
                string.IsNullOrEmpty(LastName) || 
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(TelephoneNumber.ToString()) ||
                string.IsNullOrEmpty(password) || 
                string.IsNullOrEmpty(confirmPassword))
            {
                registrationResult = RegistrationResult.ObligatoyDataMissing;
                return registrationResult;
            }

            if (TelephoneNumber.ToString().Length < 10)
            {
                return RegistrationResult.WrongTelephone;
            }

            if (password != confirmPassword)
            {
                registrationResult = RegistrationResult.PasswordsDoNotMatch;
            }

            BankAccount emailCheck = await _accountService.GetByUserEMAIL(Email);
            if (emailCheck != null)
            {
                registrationResult = RegistrationResult.EmailAlreadyExists;
            }

            if (registrationResult == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                string newIban = _provideIBANService.CreateIBANid();
                string newid = await _provideIBANService.Finalid(newIban);
                AccountUser user = new AccountUser()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    TelephoneNumber = TelephoneNumber,
                    DateJoined = DateTime.Now,
                    PasswordHash = hashedPassword,
                    IBan_Id = newid
                                      
                };

                BankAccount bankAccount = new BankAccount()
                {
                    AccountHolder = user,
                    BankBalance = 0,
                };

                await _accountService.Create(bankAccount);

            }

            return registrationResult;
           

        }
    }
}
