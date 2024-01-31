using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Input;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.ViewModels.Base;
using AvaloniaBankAppEF.Services.DialogService;

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
        private void AddCustomer()
        {
            if (true)
                ;
            using (var db = _dbContextFactory.CreateDbContext())
            {

                db.Customers.Add(new Entities.Customer
                {
                    Name = "Name",
                    Patronymic = "Patro",
                    Surname = "Surname",
                    Mail = "Mail",
                    Phone = "123"                   

                });
                db.SaveChanges();
                Trace.WriteLine("Added customer");
            }
        }

        public void Dispose()
        {

        }
    }
}
