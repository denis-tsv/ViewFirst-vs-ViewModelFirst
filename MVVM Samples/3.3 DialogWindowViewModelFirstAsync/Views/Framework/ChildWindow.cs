using System;
using System.ComponentModel;
using System.Windows;
using _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework;

namespace _3._3_DialogWindowViewModelFirstAsync.Views.Framework
{
    public abstract class ChildWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            var viewModel = (ChildViewModel)DataContext;

            if (!viewModel.IsClosed)
            {
                e.Cancel = true;
                Application.Current.Dispatcher.BeginInvoke(new Action(() => viewModel.CloseCommand.Execute(null)), null);
            }
        }
    }
}
