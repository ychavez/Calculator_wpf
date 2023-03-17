using Productos_wpf.ViewModel.Base;

namespace Productos_wpf.ViewModel.Services
{
    public class NavigateCommand<TViewModel> : CommandHandler where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService) 
            : base(() => { }, () => true)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            navigationService.Navigate();
        }

    }
}
