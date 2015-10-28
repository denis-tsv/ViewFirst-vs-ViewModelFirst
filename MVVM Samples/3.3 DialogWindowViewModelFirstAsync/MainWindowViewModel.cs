using System;
using Microsoft.Practices.Unity;
using ReactiveUI;
using _3._3_DialogWindowViewModelFirstAsync.ViewModels;
using _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework;

namespace _3._3_DialogWindowViewModelFirstAsync
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
