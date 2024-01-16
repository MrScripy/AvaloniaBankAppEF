using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace AvaloniaBankAppEF.ViewModels
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }

    internal class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    internal partial class MainViewModel : ViewModelBase, IDisposable
    {

        MainViewModel() 
        {
        
        }

        public void Dispose()
        {

        }
    }
}
