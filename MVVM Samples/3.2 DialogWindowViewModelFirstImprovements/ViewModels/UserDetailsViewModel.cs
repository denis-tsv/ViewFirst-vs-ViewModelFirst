using Common;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels
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
