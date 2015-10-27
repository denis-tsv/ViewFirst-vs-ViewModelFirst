using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _1.MasterDetailViewFirst.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;

        public IEnumerable<User> Users
        {
            get { return _users ?? (_users = new UserProvider().GetUsers()); }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();

                MessageBus.Instance.OnSelectedUserChanged(value);
            }
        }
    }
}
