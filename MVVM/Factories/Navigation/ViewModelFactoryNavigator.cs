using NewBankAccount.WPF.MVVM.ViewModels;

namespace NewBankAccount.WPF.MVVM.Factories.Navigation
{
    /// <summary>
    /// Responsible for viewmodel navigation 
    /// </summary>
    /// <typeparam name="ViewModel"></typeparam>
    public class ViewModelFactoryNavigator<ViewModel> : IViewModelNavigator where ViewModel : ViewModelBase
    {

        private readonly CreateViewModel<ViewModel> _viewModelGenerator;
        private readonly IGetCurrentViewModel _getcurrentViewModel;

        /// <summary>
        /// Constructor serves the viewmodel instance and currentviewmodel -> so that it can be created !!!
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="currentViewModel"></param>
        public ViewModelFactoryNavigator(CreateViewModel<ViewModel> viewModel, IGetCurrentViewModel currentViewModel)
        {
            _viewModelGenerator = viewModel;
            _getcurrentViewModel = currentViewModel;
        }

        /// <summary>
        /// WIth the help of delegate function CreateViewModel 
        /// GetCurrentViewModel Holds the current view model from the facory BankAccountFactory
        /// </summary>
        public void NavigateTo()
        {
            _getcurrentViewModel.CurrentViewModel = _viewModelGenerator(); 
        }
    }
}
