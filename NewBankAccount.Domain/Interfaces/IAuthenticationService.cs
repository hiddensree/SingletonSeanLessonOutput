using NewBankAccount.Domain.Models;
using NewBankAccount.Domain.Exceptions;

namespace NewBankAccount.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        public enum RegistrationResult
        {
            Success,
            PasswordsDoNotMatch,
            EmailAlreadyExists,
            WrongTelephone,
            ObligatoyDataMissing
        }
        //exceptions unhandled currently

        Task<RegistrationResult> Register(string FirstName, string LastName, string Email, double TelephoneNumber, string password, string confirmPassword);

        /// <summary>
        /// Main Login Helper Function with Logic - Created for LoginCommand 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Password"></param>
        /// <exception cref="InvalidPasswordException"> Throws when the provided password is incorrect or invalid </exception>
        /// <exception cref="InvalidLoginRegiisterInputException">Throws when the email is not found or is written in an incorrect format</exception>
        /// <exception cref="Exception"> Unknown Errors </exception>
        /// <returns></returns>
        Task<BankAccount> Login(string email, string Password);


    }
}
