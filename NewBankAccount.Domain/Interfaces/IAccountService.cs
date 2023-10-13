using NewBankAccount.Domain.Models;
namespace NewBankAccount.Domain.Interfaces
{
    public interface IAccountService : IDataService<BankAccount>
    {
        /// <summary>
        /// Negligible Functions !!! We could modify using accessors !!!!
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newfirstname"></param>
        /// <returns></returns>
        Task<BankAccount> ModifyFirstName(string email, string newfirstname);

        Task<BankAccount> ModifyLastName(string email, string newlastname);

        Task<BankAccount> ModifyEmail(string email);

        Task<BankAccount> GetByUserIBAN(string ibanid);

        Task<BankAccount> GetByUserEMAIL(string email);
    }
}
