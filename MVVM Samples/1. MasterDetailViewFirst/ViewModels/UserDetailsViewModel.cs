using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _1.MasterDetailViewFirst.ViewModels
{
    public class UserDetailsViewModel : ViewModel
    {
        public UserDetailsViewModel()
        {
            MessageBus.Instance.SelectedUserChanged += OnSelectedUserChanged;
        }

        private void OnSelectedUserChanged(object sender, UserChangedEventArgs userChangedEventArgs)
        {
            User = userChangedEventArgs.User;
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
    }
}
