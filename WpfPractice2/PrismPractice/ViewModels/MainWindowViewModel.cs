using Prism.Mvvm;

namespace PrismPractice.ViewModels
{
    using Prism.Commands;
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string input;
        public string Input
        {
            get { return input; }
            set 
            { 
                SetProperty(ref this.input, value);
                this.ConvertCommand.RaiseCanExecuteChanged();
            }
        }

        private string output;
        public string Output
        {
            get { return output; }
            set { SetProperty(ref this.output, value); }
        }

        public DelegateCommand ConvertCommand { get; private set; }

        public MainWindowViewModel()
        {
            ConvertCommand = new DelegateCommand(
                ConvertExecute, 
                CanConvertExecute
                );
        }

        private void ConvertExecute()
        {
            this.Output = this.Input.ToUpper();
        }

        private bool CanConvertExecute()
        {
            return (string.IsNullOrWhiteSpace(this.Input) == false);
        }
    }
}
