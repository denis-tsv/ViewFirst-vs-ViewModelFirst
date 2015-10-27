using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;

namespace _0._1_MasterDetailWithoutMvvmSeparateControls
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UsersProperty = DependencyProperty.Register(
            "Users", typeof (IEnumerable<User>), typeof (UserList), new PropertyMetadata(default(IEnumerable<User>)));

        public static readonly DependencyProperty SelectedUserProperty = DependencyProperty.Register(
            "SelectedUser", typeof (User), typeof (UserList), new PropertyMetadata(default(User)));

        public User SelectedUser
        {
            get { return (User) GetValue(SelectedUserProperty); }
            set { SetValue(SelectedUserProperty, value); }
        }
        
        public IEnumerable<User> Users
        {
            get { return (IEnumerable<User>) GetValue(UsersProperty); }
            set { SetValue(UsersProperty, value); }
        }
    }
}
