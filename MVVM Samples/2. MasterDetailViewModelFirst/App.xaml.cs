using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using _2.MasterDetailViewModelFirst.ViewModels;

namespace _2.MasterDetailViewModelFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainVM = new MainWindowViewModel();
            mainVM.Initialize();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}
