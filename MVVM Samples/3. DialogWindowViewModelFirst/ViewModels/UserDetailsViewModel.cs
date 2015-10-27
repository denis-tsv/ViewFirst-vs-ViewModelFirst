using Common;

namespace _3.DialogWindowViewModelFirst.ViewModels
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
