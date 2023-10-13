﻿using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.Domain.Services;
using NewBankAccount.WPF.MVVM.ViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Threading.Tasks;
using System.Windows.Documents;
using InvalidOperationException = NewBankAccount.Domain.Exceptions.InvalidOperationException;

namespace NewBankAccount.WPF.Commands
{
    public class DepositCommand : AsyncCommandBase
    {
        #region Constructor and Fields

        private readonly IAccountStore _accountStore;
        private readonly ITransactionService _transactionServices;
        private readonly LocalTransactionViewModel _viewModel;

        public DepositCommand(IAccountStore accountStore, ITransactionService transactionServices, LocalTransactionViewModel viewModel)
        {
            _accountStore = accountStore;
            _transactionServices = transactionServices;
            _viewModel = viewModel;
        }

        #endregion


        public override async Task ExecuteAsync(object? parameter)
        {
            _viewModel.StatusMessage = string.Empty;
            _viewModel.ErrorMessage = string.Empty;

            try
            {
                if (_viewModel.Withdraw > 0)
                {
                    _viewModel.ErrorMessage = string.Empty;
                    _viewModel.ErrorMessage = "One Operation at a time !";
                    
                } else
                {
                    double deposit = _viewModel.Deposit;
                    BankAccount account = _accountStore.CurrentBankAccount;
                    BankAccount bankAccount = await _transactionServices.TransactionAction(account, ITransactionService.TransactionType.LocalDeposit, deposit, 0, 0, "");
                    _accountStore.CurrentBankAccount = bankAccount;
                    _viewModel.Deposit = 0;
                    _viewModel.StatusMessage = "You are more RICH now !!!";

                }
               
            }
            catch (InsufficientFundException)
            {
                _viewModel.Deposit = 0;
                _viewModel.ErrorMessage = "Not Enough Money Pal !!";

            }
            catch (InvalidInputException)
            {
                _viewModel.Deposit = 0;
                _viewModel.ErrorMessage = "On drugs ??";

            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "System Sucks Sometimes !!!";
            }
           
        }
    }
}
