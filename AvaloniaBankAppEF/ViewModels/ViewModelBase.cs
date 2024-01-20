using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AvaloniaBankAppEF.ViewModels;

public class ViewModelBase : ObservableObject, IDisposable
{
    public void Dispose() { }
}
