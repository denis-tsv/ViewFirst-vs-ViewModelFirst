using Common;
using Microsoft.Practices.Unity;

namespace _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework
{
    public interface IViewModelFactory
    {
        T Resolve<T>() where T : ViewModel;
    }

    public class ViewModelFactory : IViewModelFactory
    {
        [Dependency]
        public IUnityContainer Container { private get; set; }

        public T Resolve<T>() where T : ViewModel
        {
            return Container.Resolve<T>();
        }
    }
}
