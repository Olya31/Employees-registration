using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ICompanyManager
    {
        //a method to get all employees that links the controller and the database
        Task<IEnumerable<Company>> GetAllCompaniesAsync(CancellationToken token);

        //a method for getting an employee by identifier that links the controller and the database
        Task<Company> GetCompanyByIdAsync(int id, CancellationToken token);

        //an update method that binds the controller and the database
        Task<int> UpdateCompanyAsync(Company company, CancellationToken token);

        //an delete method that binds the controller and the database
        Task<int> DeleteCompanyAsync(int id, CancellationToken token);

        //an add method that binds the controller and the database
        Task<int> AddCompanyAsync(Company company, CancellationToken token);
    }
}
