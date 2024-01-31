using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class ChangeCustomerInfoDialogViewModel : ParamDialogViewModelBase<Customer, Customer?>
    {
        public override Task Activate(Customer? param)
        {
            throw new System.NotImplementedException();
        }

        public override Task ActivateAsync(Customer? param, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        [RelayCommand]
        private void ChangeCustomer()
        {

        }
    }
}
