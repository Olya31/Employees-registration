using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        //an add method that binds the controller and the database
        Task<int> AddEmployeeAsync(Employee employee, CancellationToken token);

        //an delete method that binds the controller and the database
        Task<int> DeleteEmployeeAsync(int id, CancellationToken token);

        //an update method that binds the controller and the database
        Task<int> UpdateEmployeeAsync(Employee employee, CancellationToken token);

        //a method for getting an employee by identifier that links the controller and the database
        Task<Employee> GetEmployeeByIdAsync(int id, CancellationToken token);

        //a method to get all employees that links the controller and the database
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken token);
    }
}
