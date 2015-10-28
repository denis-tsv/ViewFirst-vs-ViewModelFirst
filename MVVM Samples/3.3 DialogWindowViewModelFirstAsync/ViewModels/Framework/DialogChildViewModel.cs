using System.Windows.Input;
using Common;

namespace _3._3_DialogWindowViewModelFirstAsync.ViewModels.Framework
{
    public class DialogChildViewModel : ChildViewModel
    {
        private ICommand _okCommand;
        private ICommand _cancelCommand;
        public ICommand OkCommand
        {
            get { return _okCommand ?? (_okCommand = new SimpleCommand(_ => Close(true))); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new SimpleCommand(_ => Close(false))); }
        }
    }
}
