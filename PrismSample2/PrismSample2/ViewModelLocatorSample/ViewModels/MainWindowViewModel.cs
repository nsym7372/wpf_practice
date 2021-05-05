using Prism.Mvvm;

namespace ViewModelLocatorSample.ViewModels
{
    using Models;
    using Services;
    using Unity;
    using Prism.Commands;
    using Prism.Services.Dialogs;
    using Prism.Events;
    public class MainWindowViewModel : BindableBase
    {
        
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        [Dependency]
        public MessageProvider MessageProvider { get; set; }

        public DelegateCommand AlertCommand { get; }

        public MainWindowViewModel(MessageService messageService)
        {
            Message = "Hello World";
            AlertCommand = new DelegateCommand(() =>
            {
                messageService.ShowDialog("hello world");
            });
        }
    }
}
