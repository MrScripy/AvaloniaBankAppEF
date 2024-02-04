using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class AddCustomerDialogViewModel : ParamDialogViewModelBase<Customer, Customer?>
    {
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

        public override async Task Activate(Customer param)
        {
            if (param != null) this.Customer = param;
        }

        public override async Task ActivateAsync(Customer? param, CancellationToken token = default)
        {
            if (param != null) this.Customer = param;
        }

        [RelayCommand(CanExecute = nameof(CanAddCustomer))]
        private void AddCustomer()
        {
            Customer.Name = Name;
            Customer.Surname = Surname;
            Customer.Patronymic = Patronymic;
            Customer.Phone = Phone;
            Customer.Mail = Mail;

            Close(Customer);
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
