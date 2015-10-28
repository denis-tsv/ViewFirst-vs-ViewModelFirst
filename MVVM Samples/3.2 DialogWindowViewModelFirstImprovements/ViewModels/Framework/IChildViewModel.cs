using System;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;
using _3._2_DialogWindowViewModelFirstImprovements.ViewModels.Framework;

namespace _3._2_DialogWindowViewModelFirstImprovements.ViewModels
{
    public interface IChildViewModel
    {
        void Show();

        void ShowDialog();
    }

    public abstract class ChildViewModel : ViewModel, IChildViewModel
    {
        private ICommand _closeCommand;

        [Dependency]
        public IChildViewModelManager ChildViewModelManager { private get; set; }

        public bool IsClosed { get; private set; }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new SimpleCommand(_ => Close())); }
        }

        protected void Close()
        {
            if (IsClosed)
            {
                throw  new InvalidOperationException("Already closed");
            }

            OnClosed();

            IsClosed = true;

            ChildViewModelManager.Close(this);

            RaiseClosed();
        }

        protected virtual void OnClosed()
        {
        }

        public event EventHandler Closed;

        private void RaiseClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        public void Show()
        {
            ChildViewModelManager.Show(this);
        }

        public void ShowDialog()
        {
            ChildViewModelManager.ShowDialog(this);
        }
    }
}
