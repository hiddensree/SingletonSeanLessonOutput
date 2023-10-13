using System.Runtime.Serialization;

namespace NewBankAccount.Domain.Exceptions.ModifyAccountExceptions
{
    public class InvalidNameException : Exception
    {
        public string FnameOrLname { get; set; }
        public InvalidNameException(string fnameOrLname)
        {
            FnameOrLname = fnameOrLname;
        }

        public InvalidNameException(string? message, string fnameOrLname) : base(message)
        {
            FnameOrLname = fnameOrLname;
        }

        public InvalidNameException(string? message, Exception? innerException, string fnameOrLname) : base(message, innerException)
        {
            FnameOrLname = fnameOrLname;
        }

    }
}
