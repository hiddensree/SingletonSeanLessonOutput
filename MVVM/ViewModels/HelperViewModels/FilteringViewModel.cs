
using NewBankAccount.Domain.Models;
using NewBankAccount.WPF.Store;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels
{
    public class FilteringViewModel : ViewModelBase
    {

        #region Fields and Constructors
        private readonly GetCurrentBankAccount _filteringHelper;

        private readonly ObservableCollection<BankTransaction> _filter;
        private readonly ObservableCollection<InternationalMoneyTransfers> _filter2;


        public IEnumerable<BankTransaction> Filter => _filter;
        public IEnumerable<InternationalMoneyTransfers> FilterGlobal => _filter2;

        public FilteringViewModel(GetCurrentBankAccount filteringHelper)
        {
            _filteringHelper = filteringHelper;

            _filter = new ObservableCollection<BankTransaction>();
            _filter2 = new ObservableCollection<InternationalMoneyTransfers>();

            _filteringHelper.StateChanged += _filteringHelper_StateChanged;

            ResetList();
        }

        #endregion


        #region Filter Functions

        private void ResetList()
        {
            IEnumerable<BankTransaction> _filterOneViewModels = _filteringHelper.BankTransactions
                .OrderByDescending(t => t.TransDate)
                .Take(5);
            _filter.Clear();
            foreach (BankTransaction viewmodel in _filterOneViewModels)
            {
                _filter.Add(viewmodel);
            }

            IEnumerable<InternationalMoneyTransfers> _filterTwoViewModels = _filteringHelper.BankTransfers
                .OrderByDescending (t => t.TransDate)
                .Take(5);
            _filter2.Clear();
            foreach (InternationalMoneyTransfers viewmodel in _filterTwoViewModels)
            {
                _filter2.Add(viewmodel);
            }

        }

        private void _filteringHelper_StateChanged()
        {
            OnPropertyChanged(nameof(Filter));
            OnPropertyChanged(nameof(FilterGlobal));
            ResetList();
        }

        #endregion


    }
}
