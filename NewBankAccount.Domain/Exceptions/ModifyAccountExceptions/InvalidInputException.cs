namespace NewBankAccount.Domain.Exceptions.ModifyAccountExceptions
{
    public class InvalidInputException : Exception
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewConfPassword { get; set; }

        public InvalidInputException(string password, string newPassword, string newConfPassword)
        {
            Password = password;
            NewPassword = newPassword;
            NewConfPassword = newConfPassword;
        }

        public InvalidInputException(string? message, string password, string newPassword, string newConfPassword) : base(message)
        {
            Password = password;
            NewPassword = newPassword;
            NewConfPassword = newConfPassword;
        }

        public InvalidInputException(string? message, Exception? innerException, string password, string newPassword, string newConfPassword) : base(message, innerException)
        {
            Password = password;
            NewPassword = newPassword;
            NewConfPassword = newConfPassword;
        }


    }
}
