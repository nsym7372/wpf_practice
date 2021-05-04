using Prism.Mvvm;
using System;
using Prism.Commands;

namespace PrismSample.ViewModels
{
    using Views;
    using Prism.Regions;
    using Prism.Services.Dialogs;
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _systemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string SystemDateLabel
        {
            get { return _systemDateLabel; }
            set { SetProperty(ref _systemDateLabel, value); }
        }

        public DelegateCommand SystemDataUpdateButton { get; }
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogSearvice = dialogService;
            SystemDataUpdateButton = new DelegateCommand(SystemDataUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute);
            ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
            ShowViewCButton = new DelegateCommand(ShowViewCButtonExecute);
            ShowViewDButton = new DelegateCommand(ShowViewDButtonExecute);
        }

        private void SystemDataUpdateButtonExecute()
        {
            SystemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }


        private readonly IRegionManager _regionManager;
        public DelegateCommand ShowViewAButton { get; }
        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }


        public DelegateCommand ShowViewBButton { get; }
        private void ShowViewBButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewBViewModel.MyLabel), SystemDateLabel);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB), p);
        }

        private readonly IDialogService _dialogSearvice;
        public DelegateCommand ShowViewCButton { get; }
        private void ShowViewCButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCViewModel.ViewCTextBox), SystemDateLabel);
            _dialogSearvice.ShowDialog(nameof(ViewC),p,ViewCClose);
        }

        private void ViewCClose(IDialogResult result)
        {
            if(result.Result == ButtonResult.OK)
            {
                SystemDateLabel = result.Parameters.GetValue<string>(nameof(ViewCViewModel.ViewCTextBox));
            }

        }

        public DelegateCommand ShowViewDButton { get; }
        private void ShowViewDButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewD));
        }
    }
}
