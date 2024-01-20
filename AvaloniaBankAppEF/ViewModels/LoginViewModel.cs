using AvaloniaBankAppEF.Services.Navigation;
using AvaloniaBankAppEF.Services.Navigation.Store;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaBankAppEF.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private INavigationService _navigationService;
    public string Greeting => "Fuck you, Avalonia!";

    public LoginViewModel (NavigationService<NavigationStore, MainViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private void Login()
    {
        _navigationService.Navigate();
    }


}
