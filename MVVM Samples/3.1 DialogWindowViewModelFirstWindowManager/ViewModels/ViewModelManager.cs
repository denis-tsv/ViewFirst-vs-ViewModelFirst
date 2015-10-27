using Common;
using Microsoft.Practices.Unity;

namespace _3._1_DialogWindowViewModelFirstWindowManager.ViewModels
{
    public delegate void ShowViewModelEventHandler(IChildViewModel viewModel);
    public delegate void ShowDialogViewModelEventHandler(IChildViewModel viewModel);
    public delegate void CloseViewModelEventHandler(IChildViewModel viewModel);

    public interface IViewModelManager
    {
        event ShowViewModelEventHandler ViewModelShowed;
        event ShowDialogViewModelEventHandler ViewModelShowedDialog;
        event CloseViewModelEventHandler ViewModelClosed;

        void Show(IChildViewModel viewModel);
        void ShowDialog(IChildViewModel viewModel);
        void Close(IChildViewModel viewModel);
    }
    public class ViewModelManager : IViewModelManager
    {
        public event ShowViewModelEventHandler ViewModelShowed;
        public event ShowDialogViewModelEventHandler ViewModelShowedDialog;
        public event CloseViewModelEventHandler ViewModelClosed;
        
        public void Show(IChildViewModel viewModel)
        {
            RaiseViewModelShowed(viewModel);
        }

        public void ShowDialog(IChildViewModel viewModel)
        {
            RaiseViewModelShowedDialog(viewModel);
        }

        public void Close(IChildViewModel viewModel)
        {
            RaiseViewModelClosed(viewModel);
        }
        
        protected virtual void RaiseViewModelShowed(IChildViewModel viewmodel)
        {
            ViewModelShowed?.Invoke(viewmodel);
        }

        protected virtual void RaiseViewModelShowedDialog(IChildViewModel viewmodel)
        {
            ViewModelShowedDialog?.Invoke(viewmodel);
        }

        protected virtual void RaiseViewModelClosed(IChildViewModel viewmodel)
        {
            ViewModelClosed?.Invoke(viewmodel);
        }
    }
}
