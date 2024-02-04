using System;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Input;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Services.DialogService;
using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.ViewModels.Dialogs;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels
{
    public partial class MainViewModel : ViewModelBase, IDisposable
    {
        private IDialogService _dialogService;
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public MainViewModel() { }

        public MainViewModel(IDbContextFactory<ApplicationDbContext> dbContextFactory, IDialogService dialogService) 
        {
            _dbContextFactory = dbContextFactory;
            _dialogService = dialogService;
        }

        [RelayCommand]
        private async Task AddCustomer()
        {
            var customer = await _dialogService.ShowDialogAsync<Customer, Customer?>(nameof(AddCustomerDialogViewModel), null);

            //if (true)
            //    ;
            //using (var db = _dbContextFactory.CreateDbContext())
            //{

            //    db.Customers.Add(new Entities.Customer
            //    {
            //        Name = "Name",
            //        Patronymic = "Patro",
            //        Surname = "Surname",
            //        Mail = "Mail",
            //        Phone = "123"                   

            //    });
            //    db.SaveChanges();
            //    Trace.WriteLine("Added customer");
            //}
        }

        [RelayCommand]
        private async Task ChangeCustomer()
        {
            var customer = await _dialogService.ShowDialogAsync<Customer, Customer?>(nameof(ChangeCustomerInfoDialogViewModel), null);
        }

        [RelayCommand]
        private async Task AddOrder()
        {
            var customer = await _dialogService.ShowDialogAsync<Order, Order?>(nameof(ChangeCustomerInfoDialogViewModel), null);
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
