using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface ICompanyData
    {
        //adding a company to the database
        Task<int> AddAsync(Company company, CancellationToken token);

        //deleting a company from the database
        Task<int> DeleteAsync(int id, CancellationToken token);

        //changing company data in the database
        Task<int> UpdateAsync(Company company, CancellationToken token);

        //getting a company by identifier for editing
        Task<Company> GetByIdAsync(int id, CancellationToken token);

        //getting all companies from the database
        Task<IEnumerable<Company>> GetAllAsync(CancellationToken token);
    }
}
