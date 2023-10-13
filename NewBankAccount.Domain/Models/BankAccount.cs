namespace NewBankAccount.Domain.Models
{
    public class BankAccount : MainDomainObject
    {

        public AccountUser? AccountHolder { get; set; }

        public double? BankBalance { get; set; }


        public ICollection<BankTransaction>? BankTransactions { get; set; }

        public ICollection<InternationalMoneyTransfers>? BankTransfers { get; set; }



    }
}
