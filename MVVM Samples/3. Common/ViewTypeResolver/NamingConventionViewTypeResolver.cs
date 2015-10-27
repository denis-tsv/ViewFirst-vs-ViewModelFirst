using System;

namespace _3.Common.ViewTypeResolver
{
    public class NamingConventionViewTypeResolver : IViewTypeResolver
    {
        public Type ResolveViewType(Type viewModelType)
        {
            //TODO Implement
            var viewTypeName = viewModelType.Name.Replace("ViewModel", "View");
            var fullName = string.Format("{0}.{1}, {2}", "_2._2_MasterDetailViewModelFirstViewModelPresenter.Views", viewTypeName, "2.2 MasterDetailViewModelFirstViewModelPresenter");
            return Type.GetType(fullName);
        }
    }
}
