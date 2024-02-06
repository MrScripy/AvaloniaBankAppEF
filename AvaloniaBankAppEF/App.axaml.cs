using System;
using Avalonia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.ViewModels;
using AvaloniaBankAppEF.Views;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using AvaloniaBankAppEF.Services.Navigation.Store;
using AvaloniaBankAppEF.Services.Navigation;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Services.DataCreationService;
using AvaloniaBankAppEF.Services.DialogService;
using AvaloniaBankAppEF.ViewModels.Dialogs;

namespace AvaloniaBankAppEF;

public partial class App : Application
{
    public static new App Current => (App)Application.Current;

    public IServiceProvider Services { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        InitializeServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Window window = Services.GetRequiredService<MainWindow>();
        DialogService dialogService = (DialogService)Services.GetRequiredService<IDialogService>();
        dialogService.ParentWindow = window;

        INavigationService navigationService = 
            Services.GetRequiredService<NavigationService<NavigationStore, LoginViewModel>>();
        navigationService.Navigate();

        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = window;
            desktop.MainWindow.Show();
        }

        window.Closing += OnWindow_Closing;
        base.OnFrameworkInitializationCompleted();
    }

    private void OnWindow_Closing(object? sender, WindowClosingEventArgs e)
    {
        Services.GetRequiredService<MainViewModel>().Dispose();
    }

    private void InitializeServices()
    {
        var host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.UseMicrosoftDependencyResolver();
                var resolver = Locator.CurrentMutable;
                resolver.InitializeSplat();

                ConfigureServices(services);
            })
            .UseEnvironment(Environments.Development)
            .Build()
            ;

        Services = host.Services;
        Services.UseMicrosoftDependencyResolver();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>();

        //ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddTransient<AddCustomerDialogViewModel>();
        services.AddTransient<AddOrderDialogViewModel>();
        services.AddTransient<ChangeCustomerInfoDialogViewModel>();

        //Services
        services.AddTransient<IDataCreator, DataCreator>();
        services.AddSingleton<IDialogService, DialogService>();

        //Window

        services.AddSingleton(s => new MainWindow()
        {
            DataContext = s.GetRequiredService<MainWindowViewModel>()
        });

        // Navigation
        services.AddSingleton<NavigationStore>();

        services.AddSingleton<NavigationService<NavigationStore, LoginViewModel>>();
        services.AddSingleton<Func<LoginViewModel>>(s => () => s.GetRequiredService<LoginViewModel>());

        services.AddSingleton<NavigationService<NavigationStore, MainViewModel>>();
        services.AddSingleton<Func<MainViewModel>>(s => () => s.GetRequiredService<MainViewModel>());

    }
}
