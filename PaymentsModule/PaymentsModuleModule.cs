using PaymentsModule.ViewModels;
using PaymentsModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace PaymentsModule
{
    public class PaymentsModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PaymentsView, PaymentsViewModel>();
        }
    }
}
