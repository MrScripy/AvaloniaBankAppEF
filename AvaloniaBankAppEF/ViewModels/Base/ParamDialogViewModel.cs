using AvaloniaBankAppEF.ViewModels.Dialogs;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.ViewModels.Base
{
    public abstract class ParamDialogViewModelBase<TResult, TParam> : DialogViewModelBase<TResult>
    {
        public abstract Task Activate(TParam param);
        public abstract Task ActivateAsync(TParam param, CancellationToken token = default);
    }
}
