using EmployeeApplication.Core.Interfaces;

using EmployeeApplication.DataAccess;
using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Core.Repositary
{
    public class EmployeeRepositary:IEmployeeRepositary
    {
       
        
            private readonly EmployeeDbContext _context;
            public EmployeeRepositary(EmployeeDbContext context)
            {
                _context = context;
            }
            public List<Employee> GetEmployee()
            {
                var list = _context.employees.ToList();
                return list;
            }
            public Employee InsertEmployee(Employee model)
            {
                _context.employees.AddAsync(model);
                _context.SaveChangesAsync();
                return model;
            }
            public Employee UpdateEmployee(Employee model)
            {
                var employeeToEdit = _context.employees.Where(x => x.Id == model.Id).FirstOrDefault();
                employeeToEdit.Name = model.Name;
                employeeToEdit.Salary = model.Salary;
                _context.SaveChangesAsync();
                return employeeToEdit;
            }
            public Employee DeleteEmployee(int id)
            {
                var employee = _context.employees.Where(x => x.Id == id).FirstOrDefault();
                _context.employees.Remove(employee);
                _context.SaveChangesAsync();
                return employee;
            }


        }
    }

