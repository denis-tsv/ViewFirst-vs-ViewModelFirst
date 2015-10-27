using Common;

namespace _2._1_MasterDetailViewModelFirstUnityReactiveUI.ViewModels
{
    public class UserDetailsViewModel : ViewModel
    {
        

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
    }
}
