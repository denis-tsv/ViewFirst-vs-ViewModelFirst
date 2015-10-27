using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._2_MasterDetailViewModelFirstViewModelPresenter.Views;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter
{
public class NamingConventionViewTypeResolver : IViewTypeResolver
{
    public Type ResolveViewType(Type viewModelType)
    {
        var viewTypeName = viewModelType.Name.Replace("ViewModel", "View");
        var fullName = string.Format("{0}.{1}, {2}", "_2._2_MasterDetailViewModelFirstViewModelPresenter.Views", viewTypeName, "2.2 MasterDetailViewModelFirstViewModelPresenter");
        return Type.GetType(fullName);
    }
}
}
