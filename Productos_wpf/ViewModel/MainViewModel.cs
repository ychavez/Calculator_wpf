using Productos_wpf.Stores;
using Productos_wpf.ViewModel.Base;

namespace Productos_wpf.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;
  
        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged() 
        {
            ExecPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
