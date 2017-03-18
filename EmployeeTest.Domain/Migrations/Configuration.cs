namespace EmployeeTest.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeTest.Domain.Concrete.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeTest.Domain.Concrete.EmployeeDBContext context)
        {
            var employee = new List<Employee>
            {
                new Employee {FirstName = "Jonathan", LastName="Sunders", Age=32, Birthday=DateTime.Parse("02/09/1985"), Department = "Science" },
                new Employee {FirstName = "Michael", LastName="Mayers", Age=29, Birthday=DateTime.Parse("01/05/1988"), Department = "Information Technology" },
                new Employee {FirstName = "George", LastName="Summers", Age=30, Birthday=DateTime.Parse("12/24/1987"), Department = "English" },
                new Employee {FirstName = "Angela", LastName="Tuning", Age=29, Birthday=DateTime.Parse("08/20/1988"), Department = "Math" },
                new Employee {FirstName = "Mary", LastName="Mendez", Age=31, Birthday=DateTime.Parse("04/13/1986") , Department = "English"},
            };
            employee.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }
    }
}
