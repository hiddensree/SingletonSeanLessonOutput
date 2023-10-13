using System;
using NewBankAccount.Domain.Exceptions;
using System.Threading.Tasks;
using static NewBankAccount.Domain.Interfaces.IAuthenticationService;

namespace NewBankAccount.WPF.MVVM.Factories.Authentication
{
    public interface IAuthenticationControl
    {

        void Logout();  

        bool IsLoggedIn {  get; }

        event Action StateChanged;

        /// <summary>
        /// Main Login Helper Function with Logic - Created for LoginCommand 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Password"></param>
        /// <exception cref="InvalidPasswordException"> Throws when the provided password is incorrect or invalid </exception>
        /// <exception cref="InvalidLoginRegiisterInputException">Throws when the email is not found or is written in an incorrect format</exception>
        /// <exception cref="Exception"> Unknown Errors </exception>
        /// <returns></returns>
        Task Login(string email, string password);

        Task<RegistrationResult> Register(string firstName, string lastName, string email, double telephoneNumber, string password, string confirmPassword);


    }
}
