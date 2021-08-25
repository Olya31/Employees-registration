using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ICompanyManager
    {
        /// <summary>
        ///a method to get all employees that links the controller and the database
        /// </summary>
        Task<IEnumerable<Company>> GetAllCompaniesAsync(CancellationToken token);

        /// <summary>
        ///a method for getting an employee by identifier that links the controller and the database
        /// </summary>
        Task<Company> GetCompanyByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///an update method that binds the controller and the database
        /// </summary>
        Task<int> UpdateCompanyAsync(Company company, CancellationToken token);

        /// <summary>
        ///an delete method that binds the controller and the database
        /// </summary>
        Task<int> DeleteCompanyAsync(int id, CancellationToken token);

        /// <summary>
        ///an add method that binds the controller and the database
        /// </summary>
        Task<int> AddCompanyAsync(Company company, CancellationToken token);
    }
}
