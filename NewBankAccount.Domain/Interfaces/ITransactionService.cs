using NewBankAccount.Domain.Models;
using NewBankAccount.Domain.Exceptions;

namespace NewBankAccount.Domain.Interfaces
{
    public interface ITransactionService
    {
        public enum TransactionType
        {
            LocalDeposit,
            LocalWithdrawal,
            SendMoney
        }

        /// <summary>
        /// Transaction Happens HERE !!
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="account"></param>
        /// <param name="exchange"></param>
        /// <param name="taxamt"></param>
        /// <returns></returns>
        /// <exception cref="InsufficientFundException"> Thrown if account withdraws more money with respect to the available balance.</exception>
        /// <exception cref="InvalidTargetCountryException"> Thrown if the target country is not specified</exception>
        /// <exception cref="InvalidInputException">Thrown if account tries to type negative numbers in the deposit or withdraw box</exception>
        /// <exception cref="Exception">Thrown for other failures </exception>  
        Task<BankAccount> TransactionAction(BankAccount account, TransactionType Type, double amount,double taxamt, double exchange, string targetcountry); //need to deal with exceptions later !!!
    }
}
