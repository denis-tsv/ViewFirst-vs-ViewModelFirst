using System;
using System.Windows.Input;
using Common;

namespace _3.DialogWindowViewModelFirst.ViewModels
{
    public class UserDetailsWindowViewModel : ViewModel
    {
        private User _user;
        private ICommand _closeCommand;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public bool IsClosed { get; private set; }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new SimpleCommand(OnClose)); }
        }

        public event EventHandler Closed;
        
        private void OnClose(object obj)
        {
            //здесь может быть долгая асинхронная задача: валидация, сохранение итд

            IsClosed = true;
            RaiseClosed();
        }

        protected virtual void RaiseClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
