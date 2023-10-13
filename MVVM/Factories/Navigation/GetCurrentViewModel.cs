using NewBankAccount.WPF.MVVM.ViewModels;
using System;

namespace NewBankAccount.WPF.MVVM.Factories.Navigation
{
    /// <summary>
    /// Property Change for CurrentViewModel using ViewModelBase
    /// </summary>
    public class GetCurrentViewModel : IGetCurrentViewModel
    {
        private ViewModelBase _viewModel;
        public event Action StateChanged;
        public ViewModelBase CurrentViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                StateChanged?.Invoke();
            }

        }

        
    }
}
