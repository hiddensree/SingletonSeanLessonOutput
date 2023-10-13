namespace NewBankAccount.Domain.Models
{
    public class AccountUser : MainDomainObject
    {

        /// <summary>
        /// Details of an user !!!
        /// </summary>
        /// 

        public string? IBan_Id { get; set; } //login id (randomly generated) cross checked with database 

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public double TelephoneNumber { get; set; }

        public DateTime? DateJoined { get; set; }


    }
}
