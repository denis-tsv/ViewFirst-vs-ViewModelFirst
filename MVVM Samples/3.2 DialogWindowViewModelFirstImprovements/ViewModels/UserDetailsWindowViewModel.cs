using Common;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels
{
    public class UserDetailsWindowViewModel : ChildViewModel
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

        protected override void OnClosed()
        {
            //здесь может быть долгая валидация, сохранение итд
        }
    }
}
