using System;

namespace _3.Common.ViewTypeResolver
{
    public interface IViewTypeResolver
    {
        Type ResolveViewType(Type viewModelType);
    }
}
