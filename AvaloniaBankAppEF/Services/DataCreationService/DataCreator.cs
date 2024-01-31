using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvaloniaBankAppEF.DbContexts;
using AvaloniaBankAppEF.Entities;

namespace AvaloniaBankAppEF.Services.DataCreationService
{
    internal class DataCreator : IDataCreator
    {
        private IEnumerable<Customer> _customers;
        private IEnumerable<Deal> _deals;

        private Random _random = new();

        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public DataCreator(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task FillDB()
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                if (db.Database.EnsureCreated())
                {
                    await GenerateData();

                    await db.Customers.AddRangeAsync(_customers);
                    await db.Deals.AddRangeAsync(_deals);
                    await db.SaveChangesAsync();

                    await Console.Out.WriteLineAsync("Filled DB");
                }
            }
        }

        private async Task GenerateData()
        {
            _customers = Enumerable.Range(1, 50)
              .Select(i => new Customer
              {
                  Name = $"Name {i}",
                  Patronymic = $"Patronymic {i}",
                  Surname = $"Surname {i}",
                  Phone = $"Phone {i}",
                  Mail = $"mail{i}.@mail.ru"
              });

            var mails = _customers.Select(i => i.Mail).ToArray();

            _deals = Enumerable.Range(1, 100)
                .Select(i => new Deal
                {
                    Name = $"Item name {i}",
                    ItemCode = _random.Next(0, 100),
                    Mail = _random.NextItem(mails)
                });
        }

    }
}
