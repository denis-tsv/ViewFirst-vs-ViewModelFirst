using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using _3.Common.ViewTypeResolver;

namespace _3.Common
{
    public class ViewModelPresenter : ContentControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof (object), typeof (ViewModelPresenter), new PropertyMetadata(default(object), OnViewModelChanged));

        public object ViewModel
        {
            get { return (object) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ViewModelPresenter)d).RefreshContentPresenter();
        }

        private void RefreshContentPresenter()
        {
            if (ViewModel == null)
            {
                Content = null;
                return;
            }

            var viewTypeResolver = ServiceLocator.Current.GetInstance<IViewTypeResolver>();
            var viewType = viewTypeResolver.ResolveViewType(ViewModel.GetType());

            if (viewType == null)
            {
                Content = null;
            }
            else
            {
                var viewObject = Activator.CreateInstance(viewType);
                Debug.Assert(viewObject is FrameworkElement);

                var view = (FrameworkElement)viewObject;
                view.DataContext = ViewModel;
                Content = view;
            }
        }



    }
}
