using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Common;
using Microsoft.Practices.Unity;

namespace _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework
{
    public interface IChildViewModel
    {
        Task Show();

        Task<bool?> ShowDialog();
    }

    public abstract class ChildViewModel : ViewModel, IChildViewModel
    {
        private ICommand _closeCommand;

        [Dependency]
        public IChildViewModelManager ChildViewModelManager { private get; set; }

        public bool IsClosed { get; private set; }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new SimpleCommand(_ => Close(null))); }
        }

        protected void Close(bool? result)
        {
            if (IsClosed)
            {
                throw  new InvalidOperationException("Already closed");
            }

            OnClosed();

            IsClosed = true;

            ChildViewModelManager.Close(this, result);
        }

        protected virtual void OnClosed()
        {
        }

        
        public Task Show()
        {
            return ChildViewModelManager.Show(this);
        }

        public Task<bool?> ShowDialog()
        {
            return ChildViewModelManager.ShowDialog(this);
        }
    }
}
