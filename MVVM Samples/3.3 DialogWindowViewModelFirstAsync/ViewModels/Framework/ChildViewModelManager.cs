using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using _3.Common.ViewTypeResolver;

namespace _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework
{
    public interface IChildViewModelManager
    {
        Task Show(IChildViewModel viewModel);
        Task<bool?> ShowDialog(IChildViewModel viewModel);
        void Close(IChildViewModel viewModel, bool? result);
    }

    public class ChildViewModelManager : IChildViewModelManager
    {
        private readonly Dictionary<Type, Tuple<Window, TaskCompletionSource<bool?>>> _openedWindows = new Dictionary<Type, Tuple<Window, TaskCompletionSource<bool?>>>();

        [Dependency]
        public IViewTypeResolver ViewTypeResolver { private get; set; }
        
        public Task Show(IChildViewModel viewModel)
        {
            return ShowWindowInternal(viewModel, false);
        }

        public Task<bool?> ShowDialog(IChildViewModel viewModel)
        {
            return ShowWindowInternal(viewModel, true);
        }

        public void Close(IChildViewModel viewModel, bool? result)
        {
            var tuple = _openedWindows[viewModel.GetType()];
            _openedWindows.Remove(viewModel.GetType());
            
            Application.Current.Dispatcher.BeginInvoke(new Action(() => tuple.Item1.Close()), null);

            tuple.Item2.SetResult(result);
        }

        private Task<bool?> ShowWindowInternal(IChildViewModel viewModel, bool showDialog)
        {
            var tcs = new TaskCompletionSource<bool?>();

            var windowType = ViewTypeResolver.ResolveViewType(viewModel.GetType());
            var window = (Window) Activator.CreateInstance(windowType);

            _openedWindows.Add(viewModel.GetType(), new Tuple<Window, TaskCompletionSource<bool?>>(window, tcs));

            window.DataContext = viewModel;
            if (showDialog)
                window.ShowDialog();
            else
                window.Show();

            return tcs.Task;
        }
    }
}
