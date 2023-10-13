using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions.ModifyAccountExceptions
{
    public class InvalidTelephoneException : Exception
    {
        public double Telephone { get; set; }
        public InvalidTelephoneException(double telephone)
        {
            Telephone = telephone;
        }

        public InvalidTelephoneException(string? message, double telephone) : base(message)
        {
            Telephone = telephone;
        }

        public InvalidTelephoneException(string? message, Exception? innerException, double telephone) : base(message, innerException)
        {
            Telephone = telephone;
        }

    }
}
