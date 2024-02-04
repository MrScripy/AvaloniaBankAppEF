using System;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Services.Navigation.Store;

namespace AvaloniaBankAppEF.Services.Navigation
{
    public class NavigationService <TNavigationStore, TViewModel> : INavigationService
        where TNavigationStore : NavigationStore
        where TViewModel : ViewModelBase
    {
        private readonly TNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(TNavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
