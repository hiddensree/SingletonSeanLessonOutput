using NewBankAccount.WPF.MVVM.ViewModels;
using System;

namespace NewBankAccount.WPF.MVVM.Factories.Navigation
{
    public enum ViewType
    {
        Home,
        LocalTransaction,
        GlobalTransaction,
        AccountSettings


    }
    public interface IGetCurrentViewModel
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action StateChanged;
    }
}
