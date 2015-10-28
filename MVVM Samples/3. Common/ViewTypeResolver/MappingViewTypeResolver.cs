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

        public void RegisterTypeMapping<TView, TViewModel>() where TView : Control where TViewModel : ViewModel
        {
            _typesMapping.Add(typeof(TViewModel), typeof(TView));
        }
    }
}
