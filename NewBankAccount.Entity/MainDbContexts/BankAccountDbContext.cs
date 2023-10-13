using Microsoft.EntityFrameworkCore;
using NewBankAccount.Domain.Models;

namespace NewBankAccount.Entity.MainDbContexts
{
    public class BankAccountDbContext : DbContext
    {

        public BankAccountDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        /// <summary>
        /// Remember the classes that you created !!!!
        /// Refer here!!! Main Actions Happens here !!!!
        /// </summary>
        public DbSet<AccountUser> Users { get; set; }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<BankTransaction> BankTransaction { get; set; }

        public DbSet<InternationalMoneyTransfers> InternationalMoneyTransfers { get; set; }



    }
}
