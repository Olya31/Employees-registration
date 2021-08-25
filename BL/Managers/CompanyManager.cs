using BL.Managers.Interfaces;
using DAL.Data.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers
{
    public sealed class CompanyManager : ICompanyManager
    {
        private readonly ICompanyData _companyData;

        public CompanyManager(ICompanyData companyData)
        {
            _companyData = companyData;
        }

        public async Task<int> AddCompanyAsync(Company company, CancellationToken token)
        {
            return await _companyData.AddAsync(company, token);
        }

        public async Task<int> DeleteCompanyAsync(int id, CancellationToken token)
        {
            return await _companyData.DeleteAsync(id, token);
        }

        public async Task<int> UpdateCompanyAsync(Company company, CancellationToken token)
        {
            return await _companyData.UpdateAsync(company, token);
        }

        public async Task<Company> GetCompanyByIdAsync(int id, CancellationToken token)
        {
            return await _companyData.GetByIdAsync(id, token);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(CancellationToken token)
        {
            return await _companyData.GetAllAsync(token);
        }
    }
}
