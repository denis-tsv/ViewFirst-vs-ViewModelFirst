using System.Collections.Generic;
using Common;
using Microsoft.Practices.Unity;

namespace _2._1_MasterDetailViewModelFirstUnityReactiveUI.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;

        [Dependency]
        public UserProvider UserProvider { private get; set; }

        public IEnumerable<User> Users
        {
            get { return _users ?? (_users = UserProvider.GetUsers()); }
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
