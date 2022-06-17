using EShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EShopSystem.DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopConnection")
        {
             Database.SetInitializer<ShopDbContext>(new ShopInitializer());
            //Database.SetInitializer<ShopDbContext>(new CreateDatabaseIfNotExists<ShopDbContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove convention for pluralise table name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<EShopSystem.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<EShopSystem.Models.InvoiceDetail> InvoiceDetails { get; set; }
    }
}