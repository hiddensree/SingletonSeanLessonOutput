using NewBankAccount.WPF.MVVM.ViewModels;
using System;

namespace NewBankAccount.WPF.MVVM.Factories.Navigation
{
    /// <summary>
    /// Consists Switch Statment for ViewModel Factory
    /// </summary>
    public class BankAccountNavigationFactory : IBankAccountNavigationFactory
    {

        private readonly CreateViewModel<HomeViewModel> _homeview;
        private readonly CreateViewModel<LocalTransactionViewModel> _localtransview;
        private readonly CreateViewModel<GlobalTransactionViewModel> _globaltransview;
        private readonly CreateViewModel<AccountSettingsViewModel> _accountsettingsview;

        public BankAccountNavigationFactory(
            CreateViewModel<HomeViewModel> homeview, 
            CreateViewModel<LocalTransactionViewModel> localtransview, 
            CreateViewModel<GlobalTransactionViewModel> globaltransview, 
            CreateViewModel<AccountSettingsViewModel> accountsettingsview)
        {
            _homeview = homeview;
            _localtransview = localtransview;
            _globaltransview = globaltransview;
            _accountsettingsview = accountsettingsview;
        }

        /// <summary>
        /// View Model Switch Statement - Factory
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeview();
                case ViewType.LocalTransaction:
                    return _localtransview();
                case ViewType.GlobalTransaction:
                    return _globaltransview();
                case ViewType.AccountSettings:
                    return _accountsettingsview();

                default:
                    throw new ArgumentException("");
            }
        }
    }
}
