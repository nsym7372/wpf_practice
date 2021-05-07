using Prism.Mvvm;

namespace ValidationSample.ViewModels
{
    using System.Windows.Controls;
    using System.Linq;
    using Prism.Commands;
    using Services;

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

        private bool _hasError;
        public bool HasError
        {
            get { return _hasError; }
            set { SetProperty(ref _hasError, value); }
        }

        public DelegateCommand SubmitCommand { get; }


        public MainWindowViewModel(IMessageService messageService)
        {
            SubmitCommand = new DelegateCommand(ButtonClick);
            _messageService = messageService;
        }

        private IMessageService _messageService;
        private void ButtonClick()
        {
            _messageService.ShowDialog("clicked");

        }
    }

    public class StringLengthValidationRule : ValidationRule
    {
        public int MaxLength { get; set; }
        public StringLengthValidationRule()
        {
            MaxLength = 10;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var v = value as string;
            if (v == null)
                return new ValidationResult(false, "input value should be a string");

            if (v.Count() > MaxLength)
                return new ValidationResult(false, "string is larger than MaxLength");

            return ValidationResult.ValidResult;
        }
    }
}
