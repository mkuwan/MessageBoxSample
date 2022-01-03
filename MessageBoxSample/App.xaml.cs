using MessageBoxSample.Views;
using Module.MessageBox;
using Module.MessageBox.Services;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace MessageBoxSample
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
            // Message Dialog Service
            containerRegistry.Register<IMessageDialogService, MessageDialogService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MessageBoxModule>();
        }
    }
}
//base.ConfigureModuleCatalog(moduleCatalog);
