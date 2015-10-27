using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter
{
public class MappingViewTypeResolver : IViewTypeResolver
{
    private Dictionary<Type, Type> _typesMapping = new Dictionary<Type, Type>();
    public Type ResolveViewType(Type viewModelType)
    {
        return _typesMapping[viewModelType];
    }

    public void Register<T1, T2>()
    {
        _typesMapping.Add(typeof(T2), typeof(T1));
    }
}
}
