namespace NewBankAccount.Domain.Models
{
    public class InternationalMoneyTransfers : MainDomainObject
    {

        public BankAccount? BankAccount { get; set; }

        public double? TransAmount { get; set; }

        public double? taxAmount { get; set; }

        public double? exchangeRate { get; set; }
        public string? TransactionType { get; set; }

        public string? TargetCountry { get; set; }

        public DateTime? TransDate { get; set; }






    }
}
