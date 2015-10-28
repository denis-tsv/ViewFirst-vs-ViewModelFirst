using Common;
using _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework;

namespace _3._3_DialogWindowViewModelFirstAsync.ViewModels
{
    public class UserDetailsWindowViewModel : DialogChildViewModel
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
