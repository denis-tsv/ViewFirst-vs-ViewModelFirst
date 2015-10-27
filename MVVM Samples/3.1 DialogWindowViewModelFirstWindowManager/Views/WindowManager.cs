using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using _3.Common.ViewTypeResolver;
using _3._1_DialogWindowViewModelFirstWindowManager.ViewModels;

namespace _3._1_DialogWindowViewModelFirstWindowManager.Views
{
    public interface IWindowManager
    {
        void StartEventsMonitoring();
    }

    public class WindowManager : IWindowManager
    {
        private readonly Dictionary<Type, Window> _openedWindows = new Dictionary<Type, Window>();

        [Dependency]
        public IViewTypeResolver ViewTypeResolver { private get; set; }

        [Dependency]
        public IViewModelManager ViewModelManager { get; set; }

        public void StartEventsMonitoring()
        {
            ViewModelManager.ViewModelShowed += ShowWindow;
            ViewModelManager.ViewModelShowedDialog += ShowDialogWindow;
            ViewModelManager.ViewModelClosed += CloseWindow;
        }

        private void ShowWindow(IChildViewModel viewModel)
        {
            ShowWindowInternal(viewModel, false);
        }

        private void ShowDialogWindow(IChildViewModel viewModel)
        {
            ShowWindowInternal(viewModel, true);
        }

        private void CloseWindow(IChildViewModel viewModel)
        {
            var window = _openedWindows[viewModel.GetType()];
            _openedWindows.Remove(viewModel.GetType());
            
            Application.Current.Dispatcher.BeginInvoke(new Action(() => window.Close()), null);
        }

        private void ShowWindowInternal(IChildViewModel viewModel, bool showDialog)
        {
            var windowType = ViewTypeResolver.ResolveViewType(viewModel.GetType());
            var window = (Window) Activator.CreateInstance(windowType);

            _openedWindows.Add(viewModel.GetType(), window);

            window.DataContext = viewModel;
            if (showDialog)
                window.ShowDialog();
            else
                window.Show();
        }
    }
}
