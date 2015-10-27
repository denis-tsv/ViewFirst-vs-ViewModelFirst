using System.Collections.Generic;
using Common;

namespace _2.MasterDetailViewModelFirst.ViewModels
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
            }
        }
    }
}
