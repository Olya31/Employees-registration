﻿using DAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ICompanyManager
    {
        /// <summary>
        ///A method to get all employees that links the controller and the database.
        /// </summary>
        Task<IEnumerable<Company>> GetAllCompaniesAsync(CancellationToken token);

        /// <summary>
        ///A method for getting an employee by identifier that links the controller and the database.
        /// </summary>
        Task<Company> GetCompanyByIdAsync(int id, CancellationToken token);

        /// <summary>
        ///An update method that binds the controller and the database.
        /// </summary>
        Task<int> UpdateCompanyAsync(Company company, CancellationToken token);

        /// <summary>
        ///An delete method that binds the controller and the database.
        /// </summary>
        Task<int> DeleteCompanyAsync(int id, CancellationToken token);

        /// <summary>
        ///An add method that binds the controller and the database.
        /// </summary>
        Task<int> AddCompanyAsync(Company company, CancellationToken token);
    }
}
