using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class ChangeCustomerInfoDialogViewModel : ParamDialogViewModelBase<Customer, Customer?>
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private string _name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private string _surname;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private string _patronymic;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private string _phone;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ChangeCustomerCommand))]
        private string _mail;

        private Customer? _customer = new();
        private Customer? _changedCustomer;

        public override async Task Activate(Customer? param)
        {
            if (param == null) throw new InvalidOperationException("param can't be null");
            _changedCustomer = param;
            await CustomerBinding();

        }

        public override async Task ActivateAsync(Customer? param, CancellationToken token = default)
        {
            if (param == null) throw new InvalidOperationException("param can't be null");
            _changedCustomer = param;
            await CustomerBinding();

        }

        [RelayCommand(CanExecute = nameof(CanChangeCustomer))]
        private void ChangeCustomer()
        {
            _customer.Id = _changedCustomer.Id;
            _customer.Name = Name;
            _customer.Surname = Surname;
            _customer.Patronymic = Patronymic;
            _customer.Phone = Phone;
            _customer.Mail = Mail;

            Close(_customer);
        }
        private bool CanChangeCustomer()
        {
            return
                 !string.IsNullOrEmpty(Surname) &&
                 !string.IsNullOrEmpty(Name) &&
                 !string.IsNullOrEmpty(Patronymic) &&
                 !string.IsNullOrEmpty(Phone) &&
                 !string.IsNullOrEmpty(Mail);
        }

        private async Task CustomerBinding()
        {
            Name = _changedCustomer.Name;
            Surname = _changedCustomer.Surname;
            Patronymic = _changedCustomer.Patronymic;
            Phone = _changedCustomer.Phone;
            Mail = _changedCustomer.Mail;
        }

    }
}
