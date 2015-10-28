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
using _3._3_DialogWindowViewModelFirstAsync.ViewModels;
using _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework;
using _3._3_DialogWindowViewModelFirstAsync.Views;
using _3._3_DialogWindowViewModelFirstAsync.Views.Framework;

namespace _3._3_DialogWindowViewModelFirstAsync
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

            _container.RegisterType<IChildViewModelManager, ChildViewModelManager>(new ContainerControlledLifetimeManager());

            _container.RegisterType<UserDetailsViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<UserListViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IViewModelFactory, ViewModelFactory>(new ContainerControlledLifetimeManager());

            var mappingResolver = new MappingViewTypeResolver();
            mappingResolver.RegisterTypeMapping<UserDetailsView, UserDetailsViewModel>();
            mappingResolver.RegisterTypeMapping<UserListView, UserListViewModel>();
            mappingResolver.RegisterTypeMapping<UserDetailsWindow, UserDetailsWindowViewModel>();
            mappingResolver.RegisterTypeMapping<MainWindow, MainWindowViewModel>();
            _container.RegisterInstance<IViewTypeResolver>(mappingResolver);

            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();
            mainVM.Show();

        }
    }
}
