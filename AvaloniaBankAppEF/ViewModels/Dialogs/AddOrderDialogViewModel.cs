using AvaloniaBankAppEF.Entities;
using AvaloniaBankAppEF.Services.DialogService;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Dialogs
{
    public partial class AddOrderDialogViewModel : ParamDialogViewModelBase<Deal, Deal?>
    {
        public override Task Activate(Deal? param)
        {
            throw new System.NotImplementedException();
        }

        public override Task ActivateAsync(Deal? param, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        [RelayCommand]
        private void AddOrder()
        {

        }
    }
}
