using System;
using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string? Password { get; set; }
        public InvalidPasswordException(string password)
        {
            Password = password;
        }

        public InvalidPasswordException(string? message, string password) : base(message)
        {
            Password = password;
        }

        public InvalidPasswordException(string? message, Exception? innerException, string password) : base(message, innerException)
        {
            Password = password;
        }

    }
}
