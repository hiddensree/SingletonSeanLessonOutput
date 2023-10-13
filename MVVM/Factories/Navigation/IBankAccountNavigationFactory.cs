using NewBankAccount.WPF.MVVM.ViewModels;

namespace NewBankAccount.WPF.MVVM.Factories.Navigation
{
    
    public interface IBankAccountNavigationFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);

    }
}
