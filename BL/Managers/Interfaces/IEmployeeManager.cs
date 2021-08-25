using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        /// <summary>
        ///An add method that binds the controller and the database.
        /// </summary>
        Task<int> AddEmployeeAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///An delete method that binds the controller and the database.
        /// </summary>
        Task<int> DeleteEmployeeAsync(int id, CancellationToken token);

        /// <summary>
        ///An update method that binds the controller and the database.
        /// </summary>
        Task<int> UpdateEmployeeAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///A method for getting an employee by identifier that links the controller and the database.
        /// </summary>
        Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///A method to get all employees that links the controller and the database.
        /// </summary>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken token);
    }
}
