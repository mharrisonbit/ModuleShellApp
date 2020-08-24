using Prism.Ioc;
using Prism.Modularity;
using TestingModule.ViewModels;
using TestingModule.Views;

namespace TestingModule
{
    public class TestModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TestModuleHomeView, TestModuleHomeViewModel>();
        }
    }
}
