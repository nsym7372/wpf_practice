using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    using Prism.Regions;
    using Services;
    public class ViewBViewModel : BindableBase, INavigationAware, IConfirmNavigationRequest
    {
        IMessageService _messageService;
        private string _myLabel = "";
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }


        public ViewBViewModel() : this (new MessageService())
        {

        }

        public ViewBViewModel(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if(_messageService.Question("保存せず閉じますか？") == System.Windows.MessageBoxResult.OK)
            {
                continuationCallback(true);
            }
        }
    }
}
