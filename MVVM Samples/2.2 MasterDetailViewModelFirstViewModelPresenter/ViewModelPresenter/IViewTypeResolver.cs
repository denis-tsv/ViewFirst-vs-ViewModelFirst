using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_MasterDetailViewModelFirstViewModelPresenter.ViewModelPresenter
{
public interface IViewTypeResolver
{
    Type ResolveViewType(Type viewModelType);
}
}
