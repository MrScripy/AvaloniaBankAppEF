using AvaloniaBankAppEF.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaBankAppEF.Services.DialogService
{
    public abstract class ParamDialogViewModelBase<TResult, TParam>:DialogViewModelBase<TResult>
    {
        public abstract Task Activate(TParam param);
        public abstract Task ActivateAsync(TParam param, CancellationToken token = default);
    }
}
