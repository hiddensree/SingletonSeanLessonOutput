using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBankAccount.Domain.Services
{   
    public class ProvideIBANServices : IProvideIBANService
    {
        private IAccountService _accountService;

        public ProvideIBANServices(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string CreateIBANid()
        {
            Random random = new Random(); 
            string prefix = "ICBV5001";
            string pureID = Math.Abs(random.Next(1000000, 9999999)).ToString();
            string middleID = Math.Abs(random.Next(2000, 2025)).ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Insert(0, prefix);
            stringBuilder.Insert(stringBuilder.Length, middleID);
            stringBuilder.Insert(stringBuilder.Length, pureID);
            return stringBuilder.ToString();
        }

        public async Task<string> Finalid(string id)
        {
            BankAccount account = await _accountService.GetByUserIBAN(id);
            string anotherid;

            if (account == null)
            {
                return id;
            }

            do
            {
                anotherid = CreateIBANid();

            }
            while (account != null);
            return anotherid;
        }
    }
}
