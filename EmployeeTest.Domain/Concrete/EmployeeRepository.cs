using EmployeeTest.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTest.Domain.Entities;

namespace EmployeeTest.Domain.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDBContext dbcontext = new EmployeeDBContext();
        public IEnumerable<Employee> Employees
        {
            get
            {
                return dbcontext.Employees;
            }
        }

        public Employee DeleteEmployee(int id)
        {
            Employee dataEntry = dbcontext.Employees.Find(id);
            if(dataEntry != null)
            {
                dbcontext.Employees.Remove(dataEntry);
                dbcontext.SaveChanges();
            }
            return dataEntry;
        }

        public void SaveEmployee(Employee employee)
        {
            if(employee.EmployeeID == 0)
            {
                dbcontext.Employees.Add(employee);
            } else {
                Employee dataEntry = dbcontext.Employees.Find(employee.EmployeeID);
                if(dataEntry != null)
                {
                    dataEntry.FirstName = employee.FirstName;
                    dataEntry.LastName = employee.LastName;
                    dataEntry.Age = employee.Age;
                    dataEntry.Birthday = employee.Birthday;
                    dataEntry.Department = dataEntry.Department;
                }
            }
            dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            dbcontext.Dispose();
        }

        public Employee SearchEmployeeID(int? id)
        {
            Employee employee = dbcontext.Employees.Find(id);
            return employee;
        }
    }
}
