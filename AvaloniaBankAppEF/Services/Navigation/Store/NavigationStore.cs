using System;
using AvaloniaBankAppEF.ViewModels.Base;

namespace AvaloniaBankAppEF.Services.Navigation.Store
{
    internal class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanging();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanging()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
