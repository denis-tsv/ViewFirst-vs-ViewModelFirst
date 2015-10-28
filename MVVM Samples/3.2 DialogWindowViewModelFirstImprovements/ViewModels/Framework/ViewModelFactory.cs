using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.Practices.Unity;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels.Framework
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
