using EM.Core;
using EM.Core.interfaces;
using EM.Core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMContext _context;
        public EmployeeRepository(EMContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Employee employee)
        {

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                employeeToDelete.Active = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        

        public  List<Employee> GetAll()
        {
            //return _context.Roles.Include(r => r.Employee).Include(r => r.Role);
            return  _context.Employees.Include(r=>r.Roles).ToList();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(r=>r.Roles).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Employees.AnyAsync(e => e.Id==id&&e.Active);
        }

        public async Task<bool> Update(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.Include(e => e.Roles).FirstOrDefaultAsync(e => e.Id == id);
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.TZ = employee.TZ;
            existingEmployee.StartDate = employee.StartDate;
            existingEmployee.Active = employee.Active;
            existingEmployee.BirthDate = employee.BirthDate;
            existingEmployee.Male = employee.Male;
            existingEmployee.Roles = employee.Roles;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
