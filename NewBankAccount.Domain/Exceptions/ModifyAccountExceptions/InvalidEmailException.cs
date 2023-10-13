using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions.ModifyAccountExceptions
{
    public class InvalidEmailException : Exception
    {
        public string Email { get; set; }
        public InvalidEmailException(string email)
        {
            Email = email;
        }

        public InvalidEmailException(string? message, string email) : base(message)
        {
            Email = email;
        }

        public InvalidEmailException(string? message, Exception? innerException, string email) : base(message, innerException)
        {
            Email = email;
        }


    }
}
