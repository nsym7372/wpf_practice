using Prism.Ioc;
using System.Windows;
using ViewModelLocatorSample.Views;

namespace ViewModelLocatorSample
{
    using Services;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            //containerRegistry.RegisterSingleton<MessageService>();
        }
    }
}
