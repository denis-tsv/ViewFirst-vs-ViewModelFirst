using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using _3.Common.ViewTypeResolver;
using _3._1_DialogWindowViewModelFirstWindowManager.ViewModels;
using _3._1_DialogWindowViewModelFirstWindowManager.Views;

namespace _3._1_DialogWindowViewModelFirstWindowManager
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
            _container.RegisterInstance<IUnityContainer>(_container);
            var locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager());
            
            _container.RegisterType<IViewModelManager, ViewModelManager>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IWindowManager, WindowManager>(new ContainerControlledLifetimeManager());
            
            _container.RegisterType<UserDetailsViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<UserListViewModel>(new ContainerControlledLifetimeManager());


            var mappingResolver = new MappingViewTypeResolver();
            mappingResolver.RegisterTypeMapping<UserDetailsView, UserDetailsViewModel>();
            mappingResolver.RegisterTypeMapping<UserListView, UserListViewModel>();
            mappingResolver.RegisterTypeMapping<UserDetailsWindow, UserDetailsWindowViewModel>();
            _container.RegisterInstance<IViewTypeResolver>(mappingResolver);
            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();

            var windowManager = _container.Resolve<IWindowManager>();
            windowManager.StartEventsMonitoring();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}
