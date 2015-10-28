using System.Windows;
using Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using _3.Common.ViewTypeResolver;
using _3._2_DialogWindowViewModelFirstImprovements.ViewModels;
using _3._2_DialogWindowViewModelFirstImprovements.ViewModels.Framework;
using _3._2_DialogWindowViewModelFirstImprovements.Views;

namespace _3._2_DialogWindowViewModelFirstImprovements
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
