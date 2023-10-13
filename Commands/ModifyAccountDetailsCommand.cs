using NewBankAccount.Domain.Exceptions.ModifyAccountExceptions;
using NewBankAccount.Domain.Exceptions;
using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.MVVM.ViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Threading.Tasks;

namespace NewBankAccount.WPF.Commands
{
    public class ModifyAccountDetailsCommand : AsyncCommandBase
    {
        private readonly IAccountStore _accountStore;
        private readonly AccountSettingsViewModel _viewModel;
        private readonly IModifyAccountDetails _modifyAccountDetails;

        public ModifyAccountDetailsCommand(IAccountStore accountStore, AccountSettingsViewModel viewModel, IModifyAccountDetails modifyAccountDetails)
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
                       IModifyAccountDetails.ModificationType.AccountDetailsModification,
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
            catch (InvalidNameException)
            {
                _viewModel.ErrorMessage = "Who are you really?";

            }
            catch (Domain.Exceptions.ModifyAccountExceptions.InvalidInputException)
            {
                _viewModel.ErrorMessage = "Concentrate";
            }
            catch (InvalidEmailException)
            {
                _viewModel.ErrorMessage = "Invalid Email";
            }
            catch (InvalidTelephoneException)
            {
                _viewModel.ErrorMessage = "Invalid Telephoe Number";
            }
            catch (Exception)
            {

                _viewModel.ErrorMessage = "New Boss Battle";
            }
        }
    }
}
