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
using System.Diagnostics;

namespace AvaloniaBankAppEF.ViewModels
{
    public partial class MainViewModel : ViewModelBase, IDisposable
    {
        private IDialogService _dialogService;
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        [NotifyCanExecuteChangedFor(nameof(AddOrderCommand))]
        private Customer _selectedCustomer;


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

        [RelayCommand(CanExecute = nameof(CanCgangeCustomerOrAddOrder))]
        private async Task ChangeCustomer()
        {
            var customer = await _dialogService.ShowDialogAsync<Customer, Customer?>(nameof(ChangeCustomerInfoDialogViewModel), SelectedCustomer);
            var changedCustomer = Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (changedCustomer != null)
                Customers.Remove(changedCustomer);
            Customers.Add(customer);
            using (var db = _dbContextFactory.CreateDbContext())
            {
                Customer customerDB = db.Customers.FirstOrDefault(c => c.Id == customer.Id);

                customerDB.Name = customer.Name;
                customerDB.Surname = customer.Surname;
                customerDB.Patronymic = customer.Patronymic;
                customerDB.Mail = customer.Mail;
                customerDB.Phone = customer.Phone;

                db.SaveChanges();
            }
        }

        private bool CanCgangeCustomerOrAddOrder() => SelectedCustomer != null;


        [RelayCommand(CanExecute = nameof(CanCgangeCustomerOrAddOrder))]
        private async Task AddOrder()
        {
            var order = await _dialogService.ShowDialogAsync<Order, Order?>(nameof(AddOrderDialogViewModel), null);

            if (order != null)
            {
                using (var db = _dbContextFactory.CreateDbContext())
                {
                    try
                    {
                        var customer = db.Customers.FirstOrDefault<Customer>(c => c.Id == SelectedCustomer.Id);
                        order.Mail = customer.Mail;

                        customer.Deals.Add(order);

                        var customerView = Customers.First<Customer>(c => c.Id == customer.Id);
                        customerView.Deals.Add(order);

                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine($"Add customer error {e.Message}");
                    }
                }
            }
        }

        [RelayCommand]
        private async Task ClearDB()
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                try
                {
                   
                    await db.Customers.ExecuteDeleteAsync<Customer>();
                    Customers.Clear();
                    Trace.WriteLine($"Removed customers");
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Remove customers error {e.Message}");
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
