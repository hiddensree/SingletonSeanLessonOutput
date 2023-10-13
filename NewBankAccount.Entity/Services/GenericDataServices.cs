using Microsoft.EntityFrameworkCore;
using NewBankAccount.Domain.Models;
using NewBankAccount.Entity.MainDbContexts;

namespace NewBankAccount.Entity.Services
{
    public class GenericDataServices<T> where T : MainDomainObject
    {

        #region Fields and Constructors

        private readonly NonQueryDataServices<T> _nonQueryDataServices;
        private readonly BankAccountDbContextFactory _bankAccountDbContextFactory;

        public GenericDataServices(NonQueryDataServices<T> nonQueryDataServices, BankAccountDbContextFactory bankAccountDbContextFactory)
        {
            _nonQueryDataServices = nonQueryDataServices;
            _bankAccountDbContextFactory = bankAccountDbContextFactory;
        }

        #endregion


        #region NonQuery Actions

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataServices.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataServices.Delete(id);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataServices.Update(id, entity);
        }

        #endregion


        #region Generic Queries
        //Query Actions using dbcontextFactory 

        public async Task<T> Get(int id) //gets the entity or bankaccount !!! access through id !!!
        {
            using (BankAccountDbContext context = _bankAccountDbContextFactory.CreateDbContext())
            {
                //find the entity
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }


        /// <summary>
        /// Remember that this gets only the bank transactions for now !!!
        /// </summary>
        /// <returns> Returns an Entity </returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using (BankAccountDbContext context = _bankAccountDbContextFactory.CreateDbContext())
            {
                //find entities -->> bankaccounts !!!!
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        #endregion



    }
}
