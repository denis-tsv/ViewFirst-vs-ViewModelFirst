using System;
using Common;
using Microsoft.Practices.Unity;
using ReactiveUI;
using _3._2_DialogWindowViewModelFirstImprovements.ViewModels;

namespace _3._2_DialogWindowViewModelFirstImprovements
{
    public class MainWindowViewModel : ChildViewModel
    {
        [Dependency]
        public UserDetailsViewModel UserDetailsViewModel { get; set; }

        [Dependency]
        public UserListViewModel UserListViewModel { get; set; }

        public void Initialize()
        {
            UserListViewModel
                .ObservableForProperty(vm => vm.SelectedUser)
                .Subscribe(change => UserDetailsViewModel.User = change.Value);
        }
    }
}
