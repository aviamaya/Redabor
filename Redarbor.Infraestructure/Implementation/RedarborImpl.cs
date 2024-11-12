using Microsoft.EntityFrameworkCore;
using Redarbor.Core.Entities;
using Redarbor.Core.Interfaces;
using Redarbor.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Infraestructure.Implementation
{
    public class RedarborImpl : IRedarbor
    {
        private readonly RedarborContext _db;
        public RedarborImpl(RedarborContext db) { _db = db; }

        //public async Task<List<Employee>> GetEmployees(int? id)
        //{
        //    return id.HasValue == 0 ? await _db.Employees.ToListAsync() : await _db.Employees.Where(x => x.CompanyId == id).ToListAsync();
        //}

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                return await _db.Employee.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            try
            {
                return await _db.Employee.Where(x => x.CompanyId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> PostEmployees(Employee employee)
        {
            try
            {
                Employee empl = new Employee();
                if (employee != null)
                {

                    empl = new Employee
                    {
                        CreatedOn = employee.CreatedOn,
                        DeletedOn = employee.DeletedOn,
                        Email = employee.Email,
                        Fax = employee.Fax,
                        Name = employee.Name,
                        Lastlogin = employee.Lastlogin,
                        Password = employee.Password,
                        PortalId = employee.PortalId,
                        RoleId = employee.RoleId,
                        StatusId = employee.StatusId,
                        Telephone = employee.Telephone,
                        UpdatedOn = employee.UpdatedOn,
                        Username = employee.Username,
                    };
                    _db.Employee.Add(empl);
                    await _db.SaveChangesAsync();
                }

                return empl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PutEmployees(Employee employee)
        {
            try
            {
                Employee employeelOld = await _db.Employee.Where(x => x.CompanyId == employee.CompanyId).FirstAsync();
                if (employeelOld != null)
                {
                    employeelOld.CreatedOn = employee.CreatedOn;
                    employeelOld.DeletedOn = employee.DeletedOn;
                    employeelOld.Email = employee.Email;
                    employeelOld.Fax = employee.Fax;
                    employeelOld.Name = employee.Name;
                    employeelOld.Lastlogin = employee.Lastlogin;
                    employeelOld.Password = employee.Password;
                    employeelOld.PortalId = employee.PortalId;
                    employeelOld.RoleId = employee.RoleId;
                    employeelOld.StatusId = employee.StatusId;
                    employeelOld.Telephone = employee.Telephone;
                    employeelOld.UpdatedOn = employee.UpdatedOn;
                    employeelOld.Username = employee.Username;
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEmployees(int id)
        {
            try
            {
                Employee employeelOld = await _db.Employee.FirstOrDefaultAsync(x => x.CompanyId == id);
                if (employeelOld != null)
                {
                    _db.Employee.Remove(employeelOld);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
