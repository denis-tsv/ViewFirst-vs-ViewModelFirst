using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Common;
using Microsoft.Practices.Unity;

namespace _2._1_MasterDetailViewModelFirstUnityReactiveUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer _container;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container = new UnityContainer();

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager());

            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}
