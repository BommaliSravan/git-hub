using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Interfaces
{
  
   public interface IEmployeeRepositary
    {
        List<Employee> GetEmployee();

        Employee InsertEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int Id);

    }
}
