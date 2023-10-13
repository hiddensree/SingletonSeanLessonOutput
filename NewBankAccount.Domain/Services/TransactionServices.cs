using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using static NewBankAccount.Domain.Interfaces.ITransactionService;

namespace NewBankAccount.Domain.Services
{
    /// <summary>
    /// This Service is used for 3 commands 
    /// LocalDepositCommand
    /// LocalWithdrawalCommand
    /// SendMoneyAbroadCommand
    /// </summary>
    public class TransactionServices : ITransactionService
    {

        #region Constructors and Fields

        private readonly IDataService<BankAccount> _dataservice;
      
        public TransactionServices(IDataService<BankAccount> dataservice)
        {
            _dataservice = dataservice;
        }

        #endregion


        #region Transaction Logic

        public async Task<BankAccount> TransactionAction(BankAccount account, TransactionType type,  double amount, double taxamt, double exchange, string targetcountry)
        {
            if (amount <= 0 || string.IsNullOrEmpty(amount.ToString()))
            {
                throw new InvalidInputException(amount);
            }

            //MAIN OPERATIONS BASED ON THE TRANSACTION TYPE LOGIC !!! NEED TO RETURN A NEW BANK ACCOUNT WITH MODIFIED VALUE
            //FOR CLARITY, WE COULD DEAL WITH AN ADDITIONAL COLUMN FOR BANK TRANSACIONS AND BANK TRANSFERS !!
            if ( type == TransactionType.LocalWithdrawal)
            {
                if (account.BankBalance < amount)
                {
                    throw new InsufficientFundException(amount);
                }

                BankTransaction bankTransaction = new BankTransaction()
                {
                    BankAccount = account,
                    TransactionType = nameof(TransactionType.LocalWithdrawal),
                    AmtTransacted = -amount,
                    TransDate = DateTime.Now,
                };

                account.BankTransactions?.Add(bankTransaction);
                account.BankBalance -= amount;
                await _dataservice.Update(account.Id, account);
                return account;
            }
            else if (type == TransactionType.LocalDeposit) 
            {
                BankTransaction bankTransaction = new BankTransaction()
                {
                    BankAccount = account,
                    TransactionType = nameof(TransactionType.LocalDeposit),
                    AmtTransacted = amount,
                    TransDate = DateTime.Now,
                };

                account.BankTransactions?.Add(bankTransaction);
                account.BankBalance += amount;
                await _dataservice.Update(account.Id, account);
                return account;

            }
            else if (type == TransactionType.SendMoney)
            {
                if (targetcountry == "")
                {
                    throw new InvalidTargetCountryException(targetcountry);
                }
                if (account.BankBalance < (amount - (amount * taxamt)))
                {
                    throw new InsufficientFundException(amount);
                }
                InternationalMoneyTransfers internationalMoneyTransfers = new InternationalMoneyTransfers()
                {
                    BankAccount = account,
                    TransactionType = nameof(TransactionType.SendMoney),
                    TransAmount = -amount,
                    taxAmount = taxamt,
                    exchangeRate = exchange,
                    TransDate = DateTime.Now,
                    TargetCountry = targetcountry
                   
                };
                account.BankTransfers?.Add(internationalMoneyTransfers);
                account.BankBalance -= amount;
                await _dataservice.Update(account.Id, account);
                return account;

            }
            else
            {
                throw new Exception();

            }

        }
        #endregion



    }
}
