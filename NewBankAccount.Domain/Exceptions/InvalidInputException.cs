using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InvalidInputException : Exception
    {
        public double Deposit {  get; set; }
       
        public InvalidInputException(double deposit)
        {
            Deposit = deposit;
       
        }

        public InvalidInputException(string? message, double deposit) : base(message)
        {
            Deposit = deposit;
        
        }

        public InvalidInputException(string? message, Exception? innerException, double deposit) : base(message, innerException)
        {
            Deposit = deposit;
     
        }


    }
}
