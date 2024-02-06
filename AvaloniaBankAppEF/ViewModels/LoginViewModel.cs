using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.Services.DataCreationService;
using AvaloniaBankAppEF.Services.Navigation;
using AvaloniaBankAppEF.Services.Navigation.Store;
using AvaloniaBankAppEF.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private const string user = "admin";
    private const string pass = "admin123";


    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _userName;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password;

    private INavigationService _navigationService;
    private IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private IDataCreator _dataCreator;

    public LoginViewModel(
        NavigationService<NavigationStore,
        MainViewModel> navigationService,
        IDbContextFactory<ApplicationDbContext> dbContextFactory,
        IDataCreator dataCreator
        )
    {
        _navigationService = navigationService;
        _dbContextFactory = dbContextFactory;
        _dataCreator = dataCreator;


        Task.Run(() =>
        CheckDBExistance(_dbContextFactory));
    }


    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task LoginAsync()
    {
        if (UserName == user && Password == pass)
        {
            _navigationService.Navigate();
        }
        else
        {
            var box = MessageBoxManager
            .GetMessageBoxStandard("Error", "Wrong login or/and password. Try again!",
                ButtonEnum.Ok, Icon.Error, Avalonia.Controls.WindowStartupLocation.CenterOwner);

            _ = await box.ShowAsync();
        }
    }

    private bool CanLogin()
    {
        return
            !string.IsNullOrEmpty(UserName) &&
            !string.IsNullOrEmpty(Password);
    }

    private async Task CheckDBExistance(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        using (var db = dbContextFactory.CreateDbContext())
        {
            try
            {
                await db.Database.MigrateAsync();
            }
            catch (Exception e)
            {
                Trace.WriteLine($"problems with DB migration. Error {e.Message}");
            }
        }
    }


}
