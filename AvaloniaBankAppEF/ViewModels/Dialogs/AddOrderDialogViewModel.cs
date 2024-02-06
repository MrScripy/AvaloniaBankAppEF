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
        [NotifyCanExecuteChangedFor(nameof(AddOrderCommand))]
        private string? _productName;

        [NotifyCanExecuteChangedFor(nameof(AddOrderCommand))]
        [ObservableProperty]
        private string? _productCode;

        private int _productCodeNum;

        [ObservableProperty]
        private Order _order;
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

        [RelayCommand(CanExecute = nameof(CanAddOrder))]
        private void AddOrder()
        {
            _order = new()
            {
                Name = ProductName,
                ItemCode = _productCodeNum
            };
            Close(_order);
        }

        private bool CanAddOrder()
        {
            return 
                !string.IsNullOrEmpty(ProductCode) &&
                !string.IsNullOrEmpty(ProductName) &&
                int.TryParse(ProductCode, out _productCodeNum);
        }
        
    }
}
