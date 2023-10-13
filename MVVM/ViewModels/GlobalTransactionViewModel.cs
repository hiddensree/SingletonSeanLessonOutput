using NewBankAccount.Domain.Interfaces;
using NewBankAccount.WPF.Commands;
using NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels;
using NewBankAccount.WPF.Store.AccountStore;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;
using System.Windows.Navigation;

namespace NewBankAccount.WPF.MVVM.ViewModels
{
    public class GlobalTransactionViewModel : ViewModelBase
    {

        private IExchangeRateService _exchangeRateService;


        #region Public Fields

        public LocalTransactionViewModel _localtransViewModel { get; }
        public double BankBalance => _localtransViewModel.BankBalance;

        public IEnumerable<string> AvailableCountries { get; }


        public double IndianCurrency => 1 / _exchangeRateService.GetExchangeRate("INR");
        public double EuroCurrency => 1 / _exchangeRateService.GetExchangeRate("EUR");
        public double UKCurrency => 1 /_exchangeRateService.GetExchangeRate("GBP");
        public double JapaneseCurrency => 1 / _exchangeRateService.GetExchangeRate("JPY");
        public double ChineseCurrency => 1 / _exchangeRateService.GetExchangeRate("CNY");
        public double AustralianCurrency => 1 / _exchangeRateService.GetExchangeRate("AUD");
        public double CanadianCurrency => 1 / _exchangeRateService.GetExchangeRate("CAD");

        #endregion


        #region PropChange

        public string _targetCountry { get; set; } //COMBOBOX SETUP
        public string TargetCountry
        {
            get
            {
                return _targetCountry;
            }
            set
            {
                _targetCountry = value;
                OnPropertyChanged(nameof(TargetCountry));
                OnPropertyChanged(nameof(ConvertedSendMoney));
                OnPropertyChanged(nameof(BalanceCalc));
            }
        }

        public string _targetId;
        public string TargetId
        {
            get
            {
                return _targetId;
            }
            set
            {
                _targetId = value;
                OnPropertyChanged(nameof(TargetId));
            }
        }

        private double _sendMoney;
        public double SendMoney
        {
            get
            {
                return _sendMoney;
            }
            set
            {
                _sendMoney = value;
                OnPropertyChanged(nameof(SendMoney));
                OnPropertyChanged(nameof(ConvertedSendMoney));
                OnPropertyChanged(nameof(BalanceCalc));
            }
        }

        public double BalanceCalc => BankBalance - SendMoney; //currently not used !!

    
        public double ConvertedSendMoney //MAKE THIS WORK !!!!!!
        {
            get
            {
                return CalculateSendMoneyinForeignCurrency(TargetCountry);

            }
        }

        #endregion


        #region Setters for MessageViewModel
        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage
        {
            set
            {
                StatusMessageViewModel.Message = value;
            }
        }


        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set
            {
                ErrorMessageViewModel.Message = value;
            }
        }

        #endregion




        public ICommand SendMoneyAbroadCommand { get; }


        #region Constructor

        public GlobalTransactionViewModel(
            IExchangeRateService exchangeRateService, 
            LocalTransactionViewModel localTransactionViewModel, 
            ITransactionService transactionService,
            IAccountStore accountStore)
        {

            _exchangeRateService = exchangeRateService;

            AvailableCountries = new ObservableCollection<string>
            {
                "Australia",
                "Canada",
                "China",
                "European Union Countries",
                "Japan",
                "India",
                "United Kingdom"
            };

            SendMoneyAbroadCommand = new SendMoneyAbroadCommand(accountStore, transactionService, this);

            //command doesnt need any exchange rate value
            _localtransViewModel = localTransactionViewModel;
            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion



        #region Helper Function for Converted Money

        public double CalculateSendMoneyinForeignCurrency(string TargetCountry)
        {
            switch (TargetCountry)
            {
                case ("India"):
                    return SendMoney * (1 / IndianCurrency);
                case ("United Kingdom"):
                    return SendMoney * (1 / UKCurrency);
                case ("European Union Countries"):
                    return SendMoney * (1 / EuroCurrency);
                case ("Australia"):
                    return SendMoney * (1 / AustralianCurrency);
                case ("Canada"):
                    return SendMoney * (1 / CanadianCurrency);
                case ("China"):
                    return SendMoney * (1 / ChineseCurrency);
                case ("Japan"):
                    return SendMoney * (1 / JapaneseCurrency);
                default:
                    return SendMoney * 0;
            }
        }

        #endregion
    }
}
