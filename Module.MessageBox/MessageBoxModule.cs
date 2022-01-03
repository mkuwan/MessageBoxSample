using Module.MessageBox.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Module.MessageBox
{
    public class MessageBoxModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<MessageDialog>();
        }
    }
}