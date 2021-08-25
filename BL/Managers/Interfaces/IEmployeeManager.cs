using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        /// <summary>
        ///an add method that binds the controller and the database
        /// </summary>
        Task<int> AddEmployeeAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///an delete method that binds the controller and the database
        /// </summary>
        Task<int> DeleteEmployeeAsync(int id, CancellationToken token);

        /// <summary>
        ///an update method that binds the controller and the database
        /// </summary>
        Task<int> UpdateEmployeeAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///a method for getting an employee by identifier that links the controller and the database
        /// </summary>
        Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///a method to get all employees that links the controller and the database
        /// </summary>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken token);
    }
}
