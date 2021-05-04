using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    using Prism.Services.Dialogs;

    public class MessageBoxViewViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand OkButton { get; }
        public DelegateCommand CloseButton { get; }

        private string _message = "";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Title => throw new NotImplementedException();

        public MessageBoxViewViewModel(DialogResult dialogResult)
        {
            OkButton = new DelegateCommand(OkButtonExecute);
            CloseButton = new DelegateCommand(CloseButtonExecute);
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>(nameof(Message));
        }


        private void OkButtonExecute()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        private void CloseButtonExecute()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
    }
}
