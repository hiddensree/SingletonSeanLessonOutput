

using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InvalidLoginRegiisterInputException : Exception
    {
        public string EmailorName { get; set; }
        public InvalidLoginRegiisterInputException(string emailorName)
        {
            EmailorName = emailorName;
        }

        public InvalidLoginRegiisterInputException(string? message, string emailorName) : base(message)
        {
            EmailorName = emailorName;
        }

        public InvalidLoginRegiisterInputException(string? message, Exception? innerException, string emailorName) : base(message, innerException)
        {
            EmailorName = emailorName;
        }


    }
}
