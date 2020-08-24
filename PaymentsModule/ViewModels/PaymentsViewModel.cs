using System;
using Prism.Commands;
using Prism.Navigation;

namespace PaymentsModule.ViewModels
{
    public class PaymentsViewModel : ViewModelBase
    {
        public DelegateCommand<string> PayBtnClk { get; }

        public PaymentsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Payments Module";

            PayBtnClk = new DelegateCommand<string>(x => PayCmd(x));
        }

        private void PayCmd(string x)
        {
            Console.WriteLine(x);
        }
    }
}