using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface ICompanyData
    {
        /// <summary>
        ///Adding a company to the database.
        /// </summary>
        Task<int> AddAsync(Company company, CancellationToken token);

        /// <summary>
        ///Deleting a company from the database.
        /// </summary>
        Task<int> DeleteAsync(int id, CancellationToken token);

        /// <summary>
        ///Changing company data in the database.
        /// </summary>
        Task<int> UpdateAsync(Company company, CancellationToken token);

        /// <summary>
        ///Getting a company by identifier for editing.
        /// </summary>
        Task<Company> GetByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///Getting all companies from the database.
        /// </summary>
        Task<IEnumerable<Company>> GetAllAsync(CancellationToken token);
    }
}
