namespace NewBankAccount.Domain.Models
{
    public class BankTransaction : MainDomainObject
    {

        public BankAccount? BankAccount { get; set; }

        public double? AmtTransacted { get; set; }

        public string? TransactionType { get; set; }

        // this time no booleans to check the type of transaction !!!! 
        // separating deposits from withdrawal 

        public DateTime? TransDate { get; set; }


    }
}
