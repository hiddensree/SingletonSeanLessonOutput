using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public double Deposit {  get; set; }
        public double Withdraw {  get; set; }
        public InvalidOperationException(double deposit, double withdraw)
        {
            Deposit = deposit;
            Withdraw = withdraw;
        }

        public InvalidOperationException(string? message, double deposit, double withdraw) : base(message)
        {
            Deposit = deposit;
            Withdraw = withdraw;
        }

        public InvalidOperationException(string? message, Exception? innerException, double deposit, double withdraw) : base(message, innerException)
        {
            Deposit = deposit;
            Withdraw = withdraw;
        }


    }
}
