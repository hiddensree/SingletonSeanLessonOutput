using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBankAccount.Domain.Interfaces
{
    /// <summary>
    /// Provide IBAN CODE for each user !!!
    /// </summary>
    public interface IProvideIBANService
    {
        Task<string> Finalid(string id);
        string CreateIBANid();
    }
}
