using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Exceptions.ModifyAccountExceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.MVVM.ViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace NewBankAccount.WPF.Commands
{
    public class ModifyPasswordCommand : AsyncCommandBase
    {

        private readonly IAccountStore _accountStore;
        private readonly AccountSettingsViewModel _viewModel;
        private readonly IModifyAccountDetails _modifyAccountDetails;

        public ModifyPasswordCommand(IAccountStore accountStore, AccountSettingsViewModel viewModel, IModifyAccountDetails modifyAccountDetails)
        {
            _accountStore = accountStore;
            _viewModel = viewModel;
            _modifyAccountDetails = modifyAccountDetails;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _viewModel.StatusMessage = string.Empty;
            _viewModel.ErrorMessage = string.Empty;
            try
            {
                BankAccount changedPassaccount = await _modifyAccountDetails.ModifyAccountDetails(
                       _accountStore.CurrentBankAccount,
                       IModifyAccountDetails.ModificationType.PasswordModification,
                       _viewModel.FirstName,
                       _viewModel.LastName,
                       _viewModel.Email,
                       _viewModel.Telephone,
                       _viewModel.Password,
                       _viewModel.NewPassword,
                       _viewModel.ConfirmNewPassword);
                _accountStore.CurrentBankAccount = changedPassaccount;
                _viewModel.StatusMessage = "Operation Successfull !!";
            }
            catch (InvalidPasswordException)
            {
                _viewModel.ErrorMessage = "Invalid Password";

            }
            catch (PasswordMisMatchException)
            {
                _viewModel.ErrorMessage = "Concentrate";

            }
            catch (Domain.Exceptions.ModifyAccountExceptions.InvalidInputException)
            {
                _viewModel.ErrorMessage = "Are you blind?";
            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "New Boss Battle";
            }




        }
    }
}
