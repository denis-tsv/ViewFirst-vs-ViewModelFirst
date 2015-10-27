using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using _3._1_DialogWindowViewModelFirstWindowManager.ViewModels;

namespace _3._1_DialogWindowViewModelFirstWindowManager.Views
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
        }

        private void UserDetailsWindow_OnClosing(object sender, CancelEventArgs e)
        {
            var viewModel = (UserDetailsWindowViewModel) DataContext;

            if (!viewModel.IsClosed)
            {
                e.Cancel = true;
                Application.Current.Dispatcher.BeginInvoke(new Action(() => viewModel.CloseCommand.Execute(null)), null);
            }
        }
    }
}
