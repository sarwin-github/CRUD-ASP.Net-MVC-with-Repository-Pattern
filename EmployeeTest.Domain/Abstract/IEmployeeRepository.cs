using EmployeeTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest.Domain.Abstract
{
    public interface IEmployeeRepository: IDisposable
    {
        IEnumerable<Employee> Employees { get; }
        void SaveEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        Employee SearchEmployeeID(int? id);

    }
}
