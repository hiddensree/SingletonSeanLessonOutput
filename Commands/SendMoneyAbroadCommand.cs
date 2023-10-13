using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.MVVM.ViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Threading.Tasks;

namespace NewBankAccount.WPF.Commands
{
    public class SendMoneyAbroadCommand : AsyncCommandBase
    {
        #region Constructors and Fields
        private readonly IAccountStore _accountStore;
        private readonly ITransactionService _transactionServices;
        private readonly GlobalTransactionViewModel _viewModel;

        public SendMoneyAbroadCommand(IAccountStore accountStore, ITransactionService transactionServices, GlobalTransactionViewModel viewModel)
        {
            _accountStore = accountStore;
            _transactionServices = transactionServices;
            _viewModel = viewModel;
        }

        #endregion



        public override async Task ExecuteAsync(object? parameter)
        {
            #region Initialize the Value
            string targetCountry = _viewModel.TargetCountry;
            double sendAmt = _viewModel.SendMoney;
            double exchange = 0;
            double taxamt = 0;
            if (targetCountry == "India")
            {
                exchange = _viewModel.IndianCurrency;
                taxamt = 0.10;

            } else if (targetCountry == "Australia")
            {
                exchange = _viewModel.AustralianCurrency;
                taxamt = 0.15;

            } else if (targetCountry == "Canada")
            {
                exchange = _viewModel.CanadianCurrency;
                taxamt = 0.25;
                
            } else if (targetCountry == "European Union Countries")
            {
                exchange = _viewModel.EuroCurrency;
                taxamt = 0.20;

            } else if (targetCountry == "Japan")
            {
                exchange = _viewModel.JapaneseCurrency;
                taxamt = 0.12;

            } else if (targetCountry == "United Kingdom")
            {
                exchange = _viewModel.UKCurrency;
                taxamt = 0.27;

            } else if (targetCountry == "China")
            {
                exchange = _viewModel.ChineseCurrency;
                taxamt = 0.17;
            }

            #endregion


            _viewModel.StatusMessage = string.Empty;
            _viewModel.ErrorMessage = string.Empty;

            try
            {
                //future validation check for valid target account id 
                BankAccount account = _accountStore.CurrentBankAccount;
                BankAccount bankAccount = await _transactionServices.TransactionAction(account, ITransactionService.TransactionType.SendMoney, sendAmt, taxamt, exchange, targetCountry);
                _accountStore.CurrentBankAccount = bankAccount;
                _viewModel.StatusMessage = "Successfully Transfered";
                _viewModel.SendMoney = 0;
            }
            catch (InvalidTargetCountryException)
            {
                _viewModel.ErrorMessage = "Invalid Country, Not Mars !";

            }
            catch (InsufficientFundException)
            {
                _viewModel.ErrorMessage = "Not Rich Enough !!";

            }
            catch (InvalidInputException)
            {
                _viewModel.ErrorMessage = "Concentrate !!!";

            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "Something's Wrong with YOU";
            }



        }

       
    }
}
