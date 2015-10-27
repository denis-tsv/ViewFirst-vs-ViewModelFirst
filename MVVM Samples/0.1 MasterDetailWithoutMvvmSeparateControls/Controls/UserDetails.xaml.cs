using System;
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
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UserProperty = DependencyProperty.Register(
            "User", typeof (User), typeof (UserDetails), new PropertyMetadata(default(User)));

        public User User
        {
            get { return (User) GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }
    }
}
