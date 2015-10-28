using System.Collections.Generic;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;
using _3._2_DialogWindowViewModelFirstImprovements.ViewModels.Framework;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;
        private ICommand _showDetailsCommand;

        [Dependency]
        public UserProvider UserProvider { private get; set; }
        
        [Dependency]
        public IViewModelFactory ViewModelFactory { private get; set; }

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
            get { return _showDetailsCommand ?? (_showDetailsCommand = new SimpleCommand(arg => OnShowDetails(arg as User))); }
            
        }

        private void OnShowDetails(User user)
        {
            var detailsWindowViewModel = ViewModelFactory.Resolve<UserDetailsWindowViewModel>();
            detailsWindowViewModel.User = user;

            detailsWindowViewModel.Closed += 
                (s, e) => { /* что-то делаем на закрытии окна */ };

            detailsWindowViewModel.Show();
        }
    }
}
