using System;

namespace NewBankAccount.WPF.MVVM.ViewModels.HelperViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private string _message = string.Empty; //initial declaration !!! control session !!!

        public string Message
        {
            get => _message;

            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasNoMessage));
            }

        }

        public bool HasNoMessage => !string.IsNullOrEmpty(Message);
    }
}
