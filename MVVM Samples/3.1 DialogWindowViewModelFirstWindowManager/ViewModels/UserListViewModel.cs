using System.Collections.Generic;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;
using _3._1_DialogWindowViewModelFirstWindowManager.Views;

namespace _3._1_DialogWindowViewModelFirstWindowManager.ViewModels
{
    public class UserListViewModel : ViewModel
    {
        private IEnumerable<User> _users;
        private User _selectedUser;
        private ICommand _showDetailsCommand;

        [Dependency]
        public UserProvider UserProvider { private get; set; }

        [Dependency]
        public IViewModelManager ViewModelManager { private get; set; }

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

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
            var detailsWindowViewModel = UnityContainer.Resolve<UserDetailsWindowViewModel>();
            detailsWindowViewModel.User = (User) obj;
            
            ViewModelManager.Show(detailsWindowViewModel);
        }
    }
}
