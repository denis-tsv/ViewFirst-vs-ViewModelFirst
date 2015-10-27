using System;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;

namespace _3._1_DialogWindowViewModelFirstWindowManager.ViewModels
{
    public class UserDetailsWindowViewModel : ViewModel, IChildViewModel
    {
        private User _user;
        private ICommand _closeCommand;

        [Dependency]
        public IViewModelManager ViewModelManager { private get; set; }

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

            ViewModelManager.Close(this);

            RaiseClosed();
        }

        protected virtual void RaiseClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
