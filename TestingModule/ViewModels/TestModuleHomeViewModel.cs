using Prism.Commands;
using Prism.Navigation;

namespace TestingModule.ViewModels
{
    public class TestModuleHomeViewModel : ViewModelBase
    {
        public TestModuleHomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoBackBtn = new DelegateCommand(GoBackCmd);
        }

        private DelegateCommand GoBackBtn { get; set; }

        private void GoBackCmd()
        {
            this.NavigationService.GoBackAsync();
        }
    }
}
