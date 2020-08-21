using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation;

namespace ModuleShellApp.ViewModels
{
    public class MainVIewModel : ViewModelBase
    {
        private readonly IModuleManager moduleManager;

        public DelegateCommand CallModuleBtn { get; }
        public DelegateCommand LoadModuleBtn { get; }

        public MainVIewModel(INavigationService navigationService, IModuleManager moduleManager) : base(navigationService)
        {
            this.moduleManager = moduleManager;
            CallModuleBtn = new DelegateCommand(async () => await CallModuleCmd());
            LoadModuleBtn = new DelegateCommand(LoadModuleCmd);

            ModuleLoaded = false;
        }

        private void LoadModuleCmd()
        {
            this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this.moduleManager.LoadModule("TestModuleModule");
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(e);
        }

        bool _ModuleLoaded;
        public bool ModuleLoaded
        {
            get { return _ModuleLoaded; }
            set { SetProperty(ref _ModuleLoaded, value); }
        }

        private async Task CallModuleCmd()
        {
            await navigationService.NavigateAsync("TestModuleHomeView");
        }
    }
}
