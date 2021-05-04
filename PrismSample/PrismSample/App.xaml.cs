using Prism.Ioc;
using PrismSample.Views;
using System.Windows;

namespace PrismSample
{
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
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC, ViewModels.ViewCViewModel>();
            containerRegistry.RegisterForNavigation<MessageBoxView, ViewModels.MessageBoxViewViewModel>();
            containerRegistry.RegisterForNavigation<ViewD>();

            containerRegistry.RegisterSingleton<ViewModels.MainWindowViewModel>();
        }
    }
}
