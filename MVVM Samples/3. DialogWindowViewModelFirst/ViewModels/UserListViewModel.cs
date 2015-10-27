using System.Collections.Generic;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;
using _3.DialogWindowViewModelFirst.Views;

namespace _3.DialogWindowViewModelFirst.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;
        private ICommand _showDetailsCommand;

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

        public ICommand ShowDetailsCommand
        {
            get { return _showDetailsCommand ?? (_showDetailsCommand = new SimpleCommand(OnShowDetails)); }
            
        }

        private void OnShowDetails(object obj)
        {
            var editWindow = new UserDetailsWindow();

            var editViewModel = new UserDetailsWindowViewModel();
            editViewModel.User = (User) obj;
            editViewModel.Closed += (sender, args) => editWindow.Close();

            
            editWindow.DataContext = editViewModel;
            editWindow.Show();
        }
    }
}
