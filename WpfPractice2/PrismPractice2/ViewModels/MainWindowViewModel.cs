using Prism.Mvvm;

namespace PrismPractice2.ViewModels
{
    using PrismPractice2.Models;
    using System.ComponentModel;
    using Prism.Commands;
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string lhs;
        public string Lhs
        {
            get { return this.lhs; }
            set
            {
                SetProperty(ref lhs, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private string rhs;
        public string Rhs
        {
            get { return this.rhs; }
            set
            {
                SetProperty(ref rhs, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private double answer;
        public double Answer
        {
            get { return this.answer; }
            set { SetProperty(ref this.answer, value); }
        }

        private string message;
        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref message, value); }
        }

        public OperatorTypeViewModel[] OperatorTypes { get; private set; }

        private OperatorTypeViewModel selectedOperatorType;
        public OperatorTypeViewModel SelectedOperatorType
        {
            get { return this.selectedOperatorType; }
            set
            {
                this.SetProperty(ref this.selectedOperatorType, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private AppContext appContext = new AppContext();
        public DelegateCommand ExecuteCommand { get; private set; }

        public MainWindowViewModel()
        {
            this.OperatorTypes = OperatorTypeViewModel.OperatorTypes;
            this.ExecuteCommand = new DelegateCommand(this.Execute, this.CanExecute);

            this.appContext.PropertyChanged += this.AppContextPropertyChanged;
            this.appContext.Calc.PropertyChanged += this.CalcPropertyChagned;
        }

        private void CalcPropertyChagned(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Answer")
            {
                this.Answer = this.appContext.Calc.Answer;
            }
        }

        private void AppContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Message")
            {
                this.Message = this.appContext.Message;
            }
        }

        private void Execute()
        {
            this.appContext.Calc.Lhs = double.Parse(this.Lhs);
            this.appContext.Calc.Rhs = double.Parse(this.Rhs);
            this.appContext.Calc.OperatorType = this.SelectedOperatorType.OperatorType;
            this.appContext.Calc.Execute();
        }

        private bool CanExecute()
        {

            foreach (var value in new string[] { this.Lhs, this.Rhs })
            { 
                if (double.TryParse(value, out double _) == false)
                {
                    return false;
                }
            }

            if(this.SelectedOperatorType == null)
            {
                return false;
            }
            return true;
        }
    }
}
