using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using _3.Common.ViewTypeResolver;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels.Framework
{
    public interface IChildViewModelManager
    {
        void Show(IChildViewModel viewModel);
        void ShowDialog(IChildViewModel viewModel);
        void Close(IChildViewModel viewModel);
    }
    public class ChildViewModelManager : IChildViewModelManager
    {

        private readonly Dictionary<Type, Window> _openedWindows = new Dictionary<Type, Window>();

        [Dependency]
        public IViewTypeResolver ViewTypeResolver { private get; set; }

        public void Show(IChildViewModel viewModel)
        {
            ShowWindowInternal(viewModel, false);
        }

        public void ShowDialog(IChildViewModel viewModel)
        {
            ShowWindowInternal(viewModel, true);
        }

        public void Close(IChildViewModel viewModel)
        {
            var window = _openedWindows[viewModel.GetType()];
            _openedWindows.Remove(viewModel.GetType());

            Application.Current.Dispatcher.BeginInvoke(new Action(() => window.Close()), null);
        }

        private void ShowWindowInternal(IChildViewModel viewModel, bool showDialog)
        {
            var windowType = ViewTypeResolver.ResolveViewType(viewModel.GetType());
            var window = (Window)Activator.CreateInstance(windowType);

            _openedWindows.Add(viewModel.GetType(), window);

            window.DataContext = viewModel;
            if (showDialog)
                window.ShowDialog();
            else
                window.Show();
        }


    }
}
