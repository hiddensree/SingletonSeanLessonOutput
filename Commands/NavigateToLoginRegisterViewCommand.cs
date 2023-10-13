using Microsoft.EntityFrameworkCore.Metadata;
using NewBankAccount.WPF.MVVM.Factories.Navigation;
using System.Threading.Tasks;

namespace NewBankAccount.WPF.Commands
{
    public class NavigateToLoginRegisterViewCommand : AsyncCommandBase
    {
        private readonly IViewModelNavigator _viewModelNavigator;

        public NavigateToLoginRegisterViewCommand(IViewModelNavigator viewModelNavigator)
        {
            _viewModelNavigator = viewModelNavigator;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
             _viewModelNavigator.NavigateTo();
        }
    }
}
