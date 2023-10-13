using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InsufficientFundException : Exception
    {

        public double BankBalance { get; set; }
        public InsufficientFundException(double bankBalance)
        {
            BankBalance = bankBalance;
        }

        public InsufficientFundException(string? message, double bankBalance) : base(message)
        {
            BankBalance = bankBalance;
        }

        public InsufficientFundException(string? message, Exception? innerException, double bankBalance) : base(message, innerException)
        {
            BankBalance = bankBalance;
        }


    }
}
