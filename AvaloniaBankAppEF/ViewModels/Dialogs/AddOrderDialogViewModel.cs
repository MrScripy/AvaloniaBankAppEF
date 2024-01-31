using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class AddOrderDialogViewModel : ParamDialogViewModelBase<Order, Order?>
    {
        public override Task Activate(Order? param)
        {
            throw new System.NotImplementedException();
        }

        public override Task ActivateAsync(Order? param, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        [RelayCommand]
        private void AddOrder()
        {

        }
    }
}
