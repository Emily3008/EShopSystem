using EShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EShopSystem.DAL
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryName = "Mobile"},
                new Category{CategoryName = "Sport"},
                new Category{CategoryName = "Books"},
            };

            //context.Categories.AddRange(categories);
            //categories.ForEach(c => context.Categories.Add(c));

            foreach (var c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product{ ProductName = "Galaxy Note 20", ProductPrice = 2500f, ProductStock = 2100, CategoryId = 1},
                new Product{ ProductName = "Asus Note N73", ProductPrice = 11800f, ProductStock = 9100, CategoryId = 1},
                new Product{ ProductName = "Samsung Buds S4", ProductPrice = 500f, ProductStock = 350, CategoryId = 1},
                new Product{ ProductName = "Ball", ProductPrice = 500f, ProductStock = 350, CategoryId = 2},
                new Product{ ProductName = "T-Shirt", ProductPrice = 100f, ProductStock = 70, CategoryId = 2},
                new Product{ ProductName = "Box Gloves", ProductPrice = 820f, ProductStock = 750, CategoryId = 2},
                new Product{ ProductName = "War Z", ProductPrice = 220f, ProductStock = 150, CategoryId = 3},
                new Product{ ProductName = "Putin and others", ProductPrice = 320f, ProductStock = 250, CategoryId = 3},
                new Product{ ProductName = "SSSR 2.0 Origin", ProductPrice = 520f, ProductStock = 450, CategoryId = 3},
            };

            context.Products.AddRange(products);

            var departments = new List<Department>
            {
                new Department{DepartmentName = "IT", DepartmentIsActive = true },
                new Department{DepartmentName = "Administration", DepartmentIsActive = true },
                new Department{DepartmentName = "Sales", DepartmentIsActive = true },
                new Department{DepartmentName = "Security", DepartmentIsActive = true },
                new Department{DepartmentName = "Accountinf", DepartmentIsActive = true }

            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var employees = new List<Employee>()
            {
                new Employee{ EmployeeName = "Jon Doe", EmployeeMobile = "12345", EmployeeEmail = "JonD@mail.ru", DepartmentId = 2},
                new Employee{ EmployeeName = "Will Smith", EmployeeMobile = "78345", EmployeeEmail = "WillS@mail.ru", DepartmentId = 1},
                new Employee{ EmployeeName = "Julia Dove", EmployeeMobile = "22387", EmployeeEmail = "JuliaD@mail.ru", DepartmentId = 3},
                new Employee{ EmployeeName = "Grace Dolloris", EmployeeMobile = "57945", EmployeeEmail = "GraceD@mail.ru", DepartmentId = 4},
                new Employee{ EmployeeName = "Kristof Kraft", EmployeeMobile = "93345", EmployeeEmail = "KristofK@mail.ru", DepartmentId = 5},
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}