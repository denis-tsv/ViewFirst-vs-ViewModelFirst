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
using _1.MasterDetailViewFirst.ViewModels;

namespace _1.MasterDetailViewFirst.View
{
    /// <summary>
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();

            DataContext = new UserListViewModel();
        }
    }
}
