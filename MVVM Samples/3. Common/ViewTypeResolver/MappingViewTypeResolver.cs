using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Common;

namespace _3.Common.ViewTypeResolver
{
    public class MappingViewTypeResolver : IViewTypeResolver
    {
        private readonly Dictionary<Type, Type> _typesMapping = new Dictionary<Type, Type>();
        public Type ResolveViewType(Type viewModelType)
        {
            return _typesMapping[viewModelType];
        }

        public void RegisterTypeMapping(Type viewType, Type viewModelType)
        {
            _typesMapping.Add(viewModelType, viewType);
        }

        public void RegisterTypeMapping<T1, T2>() where T1 : Control where T2 : ViewModel
        {
            _typesMapping.Add(typeof(T2), typeof(T1));
        }
    }
}
