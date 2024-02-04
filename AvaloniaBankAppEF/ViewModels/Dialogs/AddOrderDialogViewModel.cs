using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class AddOrderDialogViewModel : ParamDialogViewModelBase<Order, Order?>
    {
        [ObservableProperty]
        private Order? _order;
        public override async Task Activate(Order? param)
        {
            if (param == null) this.Order = new Order();
            else this.Order = param;
        }

        public override async Task ActivateAsync(Order? param, CancellationToken token = default)
        {
            if (param == null) this.Order = new Order();
            else this.Order = param;
        }

        [RelayCommand]
        private void AddOrder()
        {

        }
    }
}
