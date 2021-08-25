using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IEmployeeData
    {
        //adding a employee to the database
        Task<int> AddAsync(Employee employee, CancellationToken token);

        //deleting a employee from the database
        Task<int> DeleteAsync(int id, CancellationToken token);

        //changing employee data in the database
        Task<int> UpdateAsync(Employee employee, CancellationToken token);

        //getting a employee by identifier for editing
        Task<Employee> GetByIdAsync(int id, CancellationToken token);

        //getting all employees from the database
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token);
    }
}
