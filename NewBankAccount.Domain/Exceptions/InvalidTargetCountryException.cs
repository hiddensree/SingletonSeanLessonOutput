using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InvalidTargetCountryException : Exception
    {

        public string Country { get; set; }
        public InvalidTargetCountryException(string country)
        {
            Country = country;
        }

        public InvalidTargetCountryException(string? message, string country) : base(message)
        {
            Country = country;
        }

        public InvalidTargetCountryException(string? message, Exception? innerException, string country) : base(message, innerException)
        {
            Country = country;
        }


    }
}
