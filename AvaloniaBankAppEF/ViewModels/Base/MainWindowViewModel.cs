using AvaloniaBankAppEF.Services.Navigation.Store;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBankAppEF.ViewModels.Base
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _test = "Test";

        private NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
        }

        private void _navigationStore_CurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));

        public override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= _navigationStore_CurrentViewModelChanged;
            base.Dispose();
        }
    }
}
