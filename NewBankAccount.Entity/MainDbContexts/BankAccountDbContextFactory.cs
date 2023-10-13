using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewBankAccount.Entity.MainDbContexts
{
    public class BankAccountDbContextFactory : IDesignTimeDbContextFactory<BankAccountDbContext>
    {
        public BankAccountDbContext CreateDbContext(string[] args=null)
        {
            var options = new DbContextOptionsBuilder<BankAccountDbContext>();
            options.UseSqlite("Data Source= BankAccountTest.db");
            //"Server=localhost\\SQLEXPRESS;Database=ContoBancarioDB;Trusted_Connection=True;Encrypt=False;"

            return new BankAccountDbContext(options.Options);
        }
    }
}
