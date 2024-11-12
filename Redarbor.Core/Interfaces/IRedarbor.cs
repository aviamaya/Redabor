using Redarbor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Core.Interfaces
{
    public interface IRedarbor
    {
        //Task<List<Employee>> GetEmployees(int? id);
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeesById(int id);
        Task<Employee> PostEmployees(Employee employee);
        Task<bool> PutEmployees(Employee employee);
        Task<bool> DeleteEmployees(int id);
    }
}
