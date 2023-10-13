using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewBankAccount.Domain.Models;
using NewBankAccount.Entity.MainDbContexts;

namespace NewBankAccount.Entity.Services
{
    /// <summary>
    /// Does Generic Non Query Operations - Focus on (Bank Account, Bank Transactions and Bank Transfers)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NonQueryDataServices<T> where T : MainDomainObject //ACCESSED THROUGH PRIMARY KEY
    {
        #region Fields and Constructor

        private readonly BankAccountDbContextFactory _dbContextFactory;

        public NonQueryDataServices(BankAccountDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #endregion



        #region Non Query Operations 

        /// <summary>
        /// Create an Entity (Bank Account , Bank Transactions, Bank Transfers
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Returns an Entity , Could be BankAccount , Bank Transaction, Bank Transfers</returns>
        public async Task<T> Create(T entity) //returns an account
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                //ADD OUR ENTITY TO DBCONTEXT -- WORKS FOR EVERY CLASSES IN THE MAIN DOMAIN !!!
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        /// <summary>
        /// Deletes an Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A bool which denotes the status </returns>
        public async Task<bool> Delete(int id) //returns a bool
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                //find the entity and remove it !!!
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id); //last id
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Update Function !!!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns> Updated Bank Account </returns>
        public async Task<T> Update(int id, T entity)
        {
            using (BankAccountDbContext context = _dbContextFactory.CreateDbContext())
            {
                //take the enitity which passed in
                entity.Id = id; //the role of main id - last id 
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        #endregion



    }
}
