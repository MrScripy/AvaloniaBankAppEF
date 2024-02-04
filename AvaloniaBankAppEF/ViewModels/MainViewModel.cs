using System;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Input;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Services.DialogService;
using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.ViewModels.Dialogs;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaBankAppEF.ViewModels
{
    public partial class MainViewModel : ViewModelBase, IDisposable
    {
        private IDialogService _dialogService;
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private Customer? _selectedCustomer;


        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        public MainViewModel() { }

        public MainViewModel(IDbContextFactory<ApplicationDbContext> dbContextFactory, IDialogService dialogService)
        {
            _dbContextFactory = dbContextFactory;
            _dialogService = dialogService;

            using (var db = _dbContextFactory.CreateDbContext())
            {
                Customers = new(db.Customers.ToArray<Customer>());
                Orders = new(db.Deals.ToArray<Order>());
            }
        }

        [RelayCommand]
        private async Task AddCustomer()
        {
            var customer = await _dialogService.ShowDialogAsync<Customer, Customer?>(nameof(AddCustomerDialogViewModel), null);
            if (customer != null)
            {
                Customers.Add(customer);
                using (var db = _dbContextFactory.CreateDbContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
            }

        }

        [RelayCommand (CanExecute = nameof(CanCgangeCustomer))]
        private async Task ChangeCustomer()
        {
            // var customer = await _dialogService.ShowDialogAsync<Customer, Customer?>(nameof(ChangeCustomerInfoDialogViewModel), null);
        }

        private bool CanCgangeCustomer() => SelectedCustomer != null;
        

        [RelayCommand]
        private async Task AddOrder()
        {
            var order = await _dialogService.ShowDialogAsync<Order, Order?>(nameof(AddOrderDialogViewModel), null);
        }

        [RelayCommand]
        private async Task ClearDB()
        {

        }

        public void Dispose()
        {

        }
    }
}
