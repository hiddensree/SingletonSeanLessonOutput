using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions.ModifyAccountExceptions
{
    public class PasswordMisMatchException : Exception
    {

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public PasswordMisMatchException(string password, string confirmPassword)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public PasswordMisMatchException(string? message, string password, string confirmPassword) : base(message)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public PasswordMisMatchException(string? message, Exception? innerException, string password, string confirmPassword) : base(message, innerException)
        {
            Password = password;
            ConfirmPassword = confirmPassword;
        }

    }
}
