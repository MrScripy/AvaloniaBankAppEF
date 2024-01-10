
using CommunityToolkit.Mvvm.ComponentModel;
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

    internal partial class MainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>
        {
            new Customer 
            { 
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },
             new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },
              new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            }, new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },new Customer
            {
                Id = 1,
                Name = "Foo",
                Patronymic = "Bar",
                Surname = "Bar",
                Phone = "Bar",
                Mail = "Bar"
            },
        };

        [ObservableProperty]
        private ObservableCollection<Order> _orders = new ObservableCollection<Order>
        {
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },
            new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            }, new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },new Order
            {
                Id= 1,
                Name = "Foo",
                Code = "Bar"
            },

        };

        [ObservableProperty]
        private string _test = "Test";

    }
}
