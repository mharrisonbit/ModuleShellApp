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
        public DelegateCommand CallModulePaymentsBtn { get; }
        public DelegateCommand LoadModuleBtn { get; }
        public DelegateCommand LoadPaymentsModuleBtn { get; }

        public MainVIewModel(INavigationService navigationService, IModuleManager moduleManager) : base(navigationService)
        {
            this.moduleManager = moduleManager;
            CallModuleBtn = new DelegateCommand(async () => await CallModuleCmd());
            CallModulePaymentsBtn = new DelegateCommand(async () => await CallPaymentsModuleCmd());
            LoadModuleBtn = new DelegateCommand(LoadModuleCmd);
            LoadPaymentsModuleBtn = new DelegateCommand(LoadPaymentsCmd);

            PaymentsModuleLoaded = false;
        }
        public enum Guys
        {
            bob,
            john,
            jim
        }

        bool _PaymentsModuleLoaded;
        public bool PaymentsModuleLoaded
        {
            get { return _PaymentsModuleLoaded; }
            set { SetProperty(ref _PaymentsModuleLoaded, value); }
        }

        private void LoadModuleCmd()
        {
            this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this.moduleManager.LoadModule("TestModuleModule");
        }

        private void LoadPaymentsCmd()
        {
            this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this.moduleManager.LoadModule("PaymentsModuleModule");
            PaymentsModuleLoaded = true;
        }


        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(e);
        }

        private async Task CallModuleCmd()
        {
            await navigationService.NavigateAsync("TestModuleHomeView");
        }

        private async Task CallPaymentsModuleCmd()
        {
            await navigationService.NavigateAsync("PaymentsView");
        }

    }
}
