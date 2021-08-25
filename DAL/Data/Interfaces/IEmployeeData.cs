using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IEmployeeData
    {
        /// <summary>
        ///adding a employee to the database
        /// </summary>
        Task<int> AddAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///deleting a employee from the database
        /// </summary>
        Task<int> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        ///changing employee data in the database
        /// </summary>
        Task<int> UpdateAsync(Employee employee, CancellationToken token);

        /// <summary>
        ///getting a employee by identifier for editing
        /// </summary>
        Task<Employee> GetByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///getting all employees from the database
        /// </summary>
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token);
    }
}
