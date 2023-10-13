using NewBankAccount.Domain.Interfaces;
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.Factories.Authentication;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using NewBankAccount.WPF.Store;
using NewBankAccount.WPF.Store.AccountStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        private readonly GetCurrentBankAccount _getCurrentBankAccount;


        #region Public Fields

        public string Iban_Id => _getCurrentBankAccount.Iban_Id;
        public double AccountBalance => _getCurrentBankAccount.AccountBalance;
        public double AccountTelephone => _getCurrentBankAccount.AccountTelephone;
        public string AccountFirstName => _getCurrentBankAccount.AccountFirstName;
        public string AccountLastName => _getCurrentBankAccount.AccountLastName;
        public string AccountEmail => _getCurrentBankAccount.AccountEmail;


        //need to convert localrecords -->> reference video 19

        public FilteringViewModel FilteringViewModel { get; }

        public IEnumerable<BankTransaction> FilteredList => FilteringViewModel.Filter;
        public IEnumerable<InternationalMoneyTransfers> FilteredGlobalList => FilteringViewModel.FilterGlobal;

        /*public ICommand LogoutCommand { get; } *///for testing purposes, we need to create accounts 

        #endregion



        #region Constructors

        public HomeViewModel(
            GetCurrentBankAccount getCurrentBankAccount, 
            FilteringViewModel filteringViewModel)
        {
            FilteringViewModel = filteringViewModel;
            _getCurrentBankAccount = getCurrentBankAccount;
            _getCurrentBankAccount.StateChanged += CurrentAccountChanged;


        }

        #endregion



        #region OnpropState
        private void CurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Iban_Id));
            OnPropertyChanged(nameof(AccountBalance));
            OnPropertyChanged(nameof(AccountTelephone));
            OnPropertyChanged(nameof(AccountFirstName));
            OnPropertyChanged(nameof(AccountLastName));
            OnPropertyChanged(nameof(AccountEmail));

        }

        #endregion





    }
}
