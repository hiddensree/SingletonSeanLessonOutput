using Microsoft.AspNet.Identity;
using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Exceptions.ModifyAccountExceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using static NewBankAccount.Domain.Interfaces.IModifyAccountDetails;

namespace NewBankAccount.Domain.Services
{
    public class SettingsService : IModifyAccountDetails
    {

        IPasswordHasher _passwordHasher;
        IAccountService _accountService;

        public SettingsService(IPasswordHasher passwordHasher, IAccountService accountService)
        {
            _passwordHasher = passwordHasher;
            _accountService = accountService;
        }
        
        public async Task<BankAccount> ModifyAccountDetails(
            BankAccount account,
            ModificationType type,
            string firstname, 
            string lastname, 
            string email, 
            double telephone, 
            string password, 
            string newpassword, 
            string newconfpassword)
        {
            string oldpassword = account.AccountHolder.PasswordHash;
            //exceptions then logic !!!

            PasswordVerificationResult validate = _passwordHasher.VerifyHashedPassword(oldpassword, password);
            if (validate != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(password); //Password is required for any kind of modifications !!!!

            }

            if (type == ModificationType.AccountDetailsModification)
            {
                if (
               String.IsNullOrEmpty(firstname) ||
               String.IsNullOrEmpty(lastname) ||
               String.IsNullOrEmpty(email) ||
               String.IsNullOrEmpty(telephone.ToString()))
                {
                    //NULL OR EMPTY STRINGS !!
                    throw new Exceptions.ModifyAccountExceptions.InvalidInputException(firstname, lastname, email);
                }

                if (firstname.Any(char.IsDigit) || lastname.Any(char.IsDigit))
                {
                    throw new InvalidNameException(firstname); //for both, one error message

                }

                if (!email.Contains("@"))
                {
                    throw new InvalidEmailException(email);
                }

                if (telephone.ToString().Length < 10)
                {
                    throw new InvalidTelephoneException(telephone);

                }


                account.AccountHolder.FirstName = firstname;
                account.AccountHolder.LastName = lastname;
                account.AccountHolder.Email = email;
                account.AccountHolder.TelephoneNumber = telephone;
                await _accountService.Update(account.Id, account);

            }
            else if (type == ModificationType.PasswordModification) {

                if (String.IsNullOrEmpty(newpassword) || String.IsNullOrEmpty(newconfpassword) || String.IsNullOrEmpty(password))
                {
                    throw new Exceptions.ModifyAccountExceptions.InvalidInputException(password, newpassword, newconfpassword);

                }
               
                PasswordVerificationResult oldpasscheck = _passwordHasher.VerifyHashedPassword(oldpassword, newpassword);
                if (oldpasscheck == PasswordVerificationResult.Success)
                {
                    throw new InvalidPasswordException(newpassword); //need a new exception !!! or combine both for one message !!!
                }

                if (newpassword != newconfpassword)
                {
                    throw new PasswordMisMatchException(newpassword, newconfpassword);
                }

                string hashednewpass = _passwordHasher.HashPassword(newpassword);
                account.AccountHolder.PasswordHash = hashednewpass;
                await _accountService.Update(account.Id, account);

            } else
            {
                throw new Exception();
            }

            return account;

            
        }
    }
}
