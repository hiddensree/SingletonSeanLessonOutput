using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.Entity.MainDbContexts;

namespace NewBankAccount.Entity.Services
{
    /// <summary>
    /// Specific DataServices dedicated for only Accounts  !!!!
    /// Used for Account Modifications
    /// </summary>
    public class AccountServices : IAccountService
    {
        #region Fields and Constructor

        private readonly BankAccountDbContextFactory _dbContextFactory;
        private readonly NonQueryDataServices<BankAccount> _nonQueryDataServicesBankAccount;

        public AccountServices(
            BankAccountDbContextFactory dbContextFactory)
        { 
            _nonQueryDataServicesBankAccount = new NonQueryDataServices<BankAccount>(dbContextFactory);
            _dbContextFactory = dbContextFactory;
        }

        #endregion



        #region Non Query Elements 


        public async Task<BankAccount> Create(BankAccount entity)
        {
            return await _nonQueryDataServicesBankAccount.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataServicesBankAccount.Delete(id);
        }

        public async Task<BankAccount> Update(int id, BankAccount entity)
        {
            return await _nonQueryDataServicesBankAccount.Update(id, entity);
        }

        #endregion



        #region Get Operations On Bank Account
        public async Task<BankAccount> Get(int id)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                //find the entity
                BankAccount bankAccountEntity = await context.BankAccount.
                    Include(a => a.AccountHolder).
                    Include(b => b.BankTransactions).
                    Include(a => a.BankTransfers).
                    FirstOrDefaultAsync(e => e.Id == id);
                return bankAccountEntity;
            }
        }

        /// <summary>
        /// Remember that this function doesnt include bank transfers but only transactions !!
        /// </summary>
        /// <returns> Returns a list of operations with accounts</returns>
        public async Task<IEnumerable<BankAccount>> GetAll()
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<BankAccount> bankAccountsEntities = await context.BankAccount.
                    Include(a => a.AccountHolder).
                    Include(c => c.BankTransactions).ToListAsync();
                return bankAccountsEntities;
            }
        }



        public  async Task<BankAccount> GetByUserEMAIL(string email)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.BankAccount.
                    Include(a => a.AccountHolder).
                    Include(a => a.BankTransactions).
                    Include(a => a.BankTransfers).
                    FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<BankAccount> GetByUserIBAN(string ibanid)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.BankAccount.
                    Include(a => a.AccountHolder).
                    Include(a => a.BankTransactions).
                    Include(a => a.BankTransfers).
                    FirstOrDefaultAsync(a => a.AccountHolder.IBan_Id == ibanid);
            }
        }

            #endregion




        #region Modify Operations On Bank Account
        public async Task<BankAccount> ModifyEmail(string email)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                BankAccount entity = await context.Set<BankAccount>().FirstOrDefaultAsync(e => e.AccountHolder.Email == email);
                entity.AccountHolder.Email = email;
                await context.SaveChangesAsync();
                return entity;
            }

        }

        public async Task<BankAccount> ModifyFirstName(string email, string newfirstname)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                BankAccount entity = await context.Set<BankAccount>().FirstOrDefaultAsync(e => e.AccountHolder.Email == email);
                entity.AccountHolder.FirstName = newfirstname;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<BankAccount> ModifyLastName(string email, string newlastname)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                BankAccount entity = await context.Set<BankAccount>().FirstOrDefaultAsync(e => e.AccountHolder.Email == email);
                entity.AccountHolder.LastName = newlastname;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        #endregion

    }
}
