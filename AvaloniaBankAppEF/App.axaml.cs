﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.ViewModels;
using AvaloniaBankAppEF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;

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
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<LoginViewModel>();


        services.AddSingleton(s => new MainWindow()
        {
            DataContext = s.GetRequiredService<MainViewModel>()
        });


    }
}
