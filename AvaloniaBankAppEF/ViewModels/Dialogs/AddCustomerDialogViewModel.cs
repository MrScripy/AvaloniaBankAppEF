using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class AddCustomerDialogViewModel : ParamDialogViewModelBase<Customer, Customer?>
    {
        private IDbContextFactory<ApplicationDbContext> _dbFactory;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCustomerCommand))]
        private string _name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCustomerCommand))]
        private string _surname;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCustomerCommand))]
        private string _patronymic;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCustomerCommand))]
        private string _phone;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCustomerCommand))]
        private string _mail;

        [ObservableProperty]
        private Customer? _customer = new Customer();

        public AddCustomerDialogViewModel(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbFactory = dbContextFactory;
        }

        public override async Task Activate(Customer param)
        {
            if (param != null) this.Customer = param;
        }

        public override async Task ActivateAsync(Customer? param, CancellationToken token = default)
        {
            if (param != null) this.Customer = param;
        }

        [RelayCommand(CanExecute = nameof(CanAddCustomer))]
        private async Task AddCustomer()
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                var checkDB = await db.Customers.AnyAsync(c => c.Mail == Mail);

                if (checkDB)
                {
                    var box = MessageBoxManager
                        .GetMessageBoxStandard("Error", "User with this e-mail exists already!",
                        ButtonEnum.Ok, Icon.Error, Avalonia.Controls.WindowStartupLocation.CenterOwner);

                    _ = await box.ShowAsync();
                }
                else
                {
                    Customer.Name = Name;
                    Customer.Surname = Surname;
                    Customer.Patronymic = Patronymic;
                    Customer.Phone = Phone;
                    Customer.Mail = Mail;

                    Close(Customer);
                }
            }

        }

        private bool CanAddCustomer()
        {
            return
                 !string.IsNullOrEmpty(Surname) &&
                 !string.IsNullOrEmpty(Name) &&
                 !string.IsNullOrEmpty(Patronymic) &&
                 !string.IsNullOrEmpty(Phone) &&
                 !string.IsNullOrEmpty(Mail);
        }

    }
}
