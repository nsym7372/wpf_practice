using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    using Prism.Services.Dialogs;
    using Views;
    using Services;
    public class ViewCViewModel : BindableBase
        , IDialogAware
    {
        IDialogService _dialogService;
        IMessageService _messageService;

        public ViewCViewModel(IDialogService dialogService)
            : this(dialogService, new MessageService())
        { }

        public ViewCViewModel(IDialogService dialogService, IMessageService messageService)
        {
            CloseButton = new DelegateCommand(CloseButtonExecute);
            _dialogService = dialogService;
            _messageService = messageService;
        }

        private string _viewCTextBox = "xxx";

        public event Action<IDialogResult> RequestClose;

        public string ViewCTextBox
        {
            get { return _viewCTextBox; }
            set { SetProperty(ref _viewCTextBox, value); }
        }

        public string Title => "View Cのタイトル";

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
            ViewCTextBox = parameters.GetValue<string>(nameof(ViewCTextBox));

            //MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
            //throw new NotImplementedException();
        }


        public DelegateCommand CloseButton { get; }
        private void CloseButtonExecute()
        {
            if(_messageService.Question("保存しますか？") == System.Windows.MessageBoxResult.OK)
            {
                _messageService.ShowDialog("保存しました");
            }

            var message = new DialogParameters();
            message.Add(nameof(MessageBoxViewViewModel.Message), "Saveします");
            _dialogService.ShowDialog(nameof(MessageBoxView), message, msgret);

        }

        private void msgret(IDialogResult ret)
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCTextBox), ViewCTextBox);
            RequestClose?.Invoke(new DialogResult(ret.Result, p));
        }
    }
}
