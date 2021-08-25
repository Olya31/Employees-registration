using BL.Managers.Interfaces;
using DAL.Data.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers
{
    public sealed class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeManager(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        public async Task<int> AddEmployeeAsync(Employee employee, CancellationToken token)
        {
            return await _employeeData.AddAsync(employee, token);
        }

        public async Task<int> DeleteEmployeeAsync(int id, CancellationToken token)
        {
            return await _employeeData.DeleteAsync(id, token);
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee, CancellationToken token)
        {
            return await _employeeData.UpdateAsync(employee, token);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token)
        {
            return await _employeeData.GetByIdAsync(id, token);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken token)
        {
            return await _employeeData.GetAllAsync(token);
        }
    }
}
