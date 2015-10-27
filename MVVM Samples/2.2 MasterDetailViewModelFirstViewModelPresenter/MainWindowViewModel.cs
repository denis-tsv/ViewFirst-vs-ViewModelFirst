using System;
using Common;
using Microsoft.Practices.Unity;
using ReactiveUI;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModels;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter
{
    public class MainWindowViewModel : ViewModel
    {
        [Dependency]
        public UserDetailsViewModel UserDetailsViewModel { get; set; }

        [Dependency]
        public UserListViewModel UserListViewModel { get; set; }

        public void Initialize()
        {
            UserListViewModel.ObservableForProperty(vm => vm.SelectedUser)
            .Subscribe(change => UserDetailsViewModel.User = change.Value);
        }
    }
}
