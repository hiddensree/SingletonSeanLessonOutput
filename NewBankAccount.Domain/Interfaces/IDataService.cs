namespace NewBankAccount.Domain.Interfaces
{
    public interface IDataService<T>
    {

        /// <summary>
        /// This interface directly connects with core entity services for database manipulations 
        /// It is essential making database edits /search 
        /// It should be Generic since we deal with multiple entities such as accounts, bank transactions and money transfers !!!
        /// Custom interfaces are derived from this one based on requests !!!
        /// </summary>
        /// <returns></returns>
        /// 

        
        Task<T> Create(T entity); //entity is account or transactions !!!

        Task<bool> Delete(int id);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();
           
        Task<T> Update(int id, T entity);
        
      


    }
}
