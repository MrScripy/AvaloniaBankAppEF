using AvaloniaBankAppEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AvaloniaBankAppEF.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Deals { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=Bank.db");
        //}
    }
}
