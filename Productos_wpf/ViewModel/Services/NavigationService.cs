﻿using Productos_wpf.Stores;
using Productos_wpf.ViewModel.Base;
using System;

namespace Productos_wpf.ViewModel.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<TViewModel> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate()
            => navigationStore.CurrentViewModel = createViewModel();
    }
}
