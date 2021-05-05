using Prism.Ioc;
using Prism.Modularity;
using PrismSample2.Views;
using System.Windows;

namespace PrismSample2
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

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
