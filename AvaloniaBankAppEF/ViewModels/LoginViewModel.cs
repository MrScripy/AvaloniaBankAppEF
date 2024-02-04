﻿using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.Services.DataCreationService;
using AvaloniaBankAppEF.Services.Navigation;
using AvaloniaBankAppEF.Services.Navigation.Store;
using AvaloniaBankAppEF.ViewModels.Base;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
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
        using (var db = dbContextFactory.CreateDbContext())
        {
            db.Database.Migrate();
        }

        //Task.Run(() =>
        //CheckDBExistance(_dbContextFactory));
    }

    [RelayCommand]
    private void Login()
    {
        _navigationService.Navigate();
    }

    private async Task CheckDBExistance(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        using (var db = dbContextFactory.CreateDbContext())
        {
            try
            {
                await _dataCreator.FillDB();

            }
            catch (Exception e)
            {
                Trace.WriteLine($"problems with filing DB. Error {e.Message}");
            }

        }
    }


}
