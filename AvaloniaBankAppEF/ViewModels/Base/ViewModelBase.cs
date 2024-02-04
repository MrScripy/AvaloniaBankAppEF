using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBankAppEF.ViewModels.Base;

public class ViewModelBase : ObservableObject, IDisposable
{
    public virtual void Dispose() { }
}
