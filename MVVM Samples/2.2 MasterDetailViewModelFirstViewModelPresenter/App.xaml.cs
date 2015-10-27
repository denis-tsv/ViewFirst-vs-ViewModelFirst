using System.Windows;
using Common;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModels;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.Views;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter
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
            var locator = new UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);

            _container.RegisterType<UserProvider>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IViewTypeResolver, NamingConventionViewTypeResolver>(new ContainerControlledLifetimeManager());

            _container.RegisterType<UserDetailsViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<UserListViewModel>(new ContainerControlledLifetimeManager());

            var mappingResolver = new MappingViewTypeResolver();
            mappingResolver.Register<UserDetailsView, UserDetailsViewModel>();
            mappingResolver.Register<UserListView, UserListViewModel>();
            _container.RegisterInstance<IViewTypeResolver>(mappingResolver);
            
            var mainVM = _container.Resolve<MainWindowViewModel>();
            mainVM.Initialize();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainVM;
            mainWindow.Show();
        }
    }
}
