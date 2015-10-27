using System.ComponentModel;
using Common;
using _2.MasterDetailViewModelFirst.ViewModels;

namespace _2.MasterDetailViewModelFirst
{
    public class MainWindowViewModel : ViewModel
    {
        public UserDetailsViewModel UserDetailsViewModel { get; private set; }
        public UserListViewModel UserListViewModel { get; private set; }

        public void Initialize()
        {
            UserListViewModel = new UserListViewModel();
            UserDetailsViewModel = new UserDetailsViewModel();

            UserListViewModel.PropertyChanged += UserListViewModelOnPropertyChanged;
        }

        private void UserListViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedUser")
            {
                UserDetailsViewModel.User = UserListViewModel.SelectedUser;
            }
        }
    }
}
