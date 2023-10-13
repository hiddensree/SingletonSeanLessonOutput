using NewBankAccount.Domain.Models;
using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Exceptions.ModifyAccountExceptions;

namespace NewBankAccount.Domain.Interfaces
{
    public interface IModifyAccountDetails
    {

        public enum ModificationType
        {
            AccountDetailsModification,
            PasswordModification
        }
        /// <summary>
        /// Interface which focuses on Account Detail Modifications
        /// </summary>
        /// <param name="account"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="telephone"></param>
        /// <param name="password"></param>
        /// <param name="newpassword"></param>
        /// <param name="newconfpassword"></param>
        /// <exception cref="InvalidPasswordException"> Throws if the entered password is incorrect</exception>
        /// <exception cref="InvalidEmailException"> Throws if the email entered is not valid or not followed the format specified</exception>
        /// <exception cref="InvalidNameException"> Thrown if the name is invalid -- e.g. contains number or null or empty</exception>
        /// <exception cref="PasswordMisMatchException">Throws if the new password and new confirm password dont match</exception>
        /// <exception cref="InvalidTelephoneException">Throws if the telephone number doesnt follow the normal conventions</exception>
        /// <exception cref="Exceptions.ModifyAccountExceptions.InvalidInputException"> Throws at null values </exception>
        /// <returns>Returns the Current Account with Newly Updated Values</returns>
        Task<BankAccount> ModifyAccountDetails(BankAccount account, ModificationType type, string firstname, string lastname, string email, double telephone, string password, string newpassword, string newconfpassword);
    }
}
