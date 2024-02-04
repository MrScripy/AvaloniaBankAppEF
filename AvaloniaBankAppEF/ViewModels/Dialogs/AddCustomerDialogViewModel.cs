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
        private Customer? _customer;
        public override async Task Activate(Customer param)
        {
            if(param == null) this.Customer = new Customer();
            else this.Customer = param;
        }

        public override async Task ActivateAsync(Customer? param, CancellationToken token = default)
        {
            if (param == null) this.Customer = new Customer();
            else this.Customer = param;
        }

        [RelayCommand]
        private void AddCustomer()
        {

        }
    }
}
