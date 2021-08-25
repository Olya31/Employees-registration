using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IEmployeeData
    {
        /// <summary>
        ///Adding a employee to the database.
        /// </summary>
        Task<int> AddAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///Deleting a employee from the database.
        /// </summary>
        Task<int> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        ///Changing employee data in the database.
        /// </summary>
        Task<int> UpdateAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///Getting a employee by identifier for editing.
        /// </summary>
        Task<Employee> GetByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///Getting all employees from the database.
        /// </summary>
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token);
    }
}
