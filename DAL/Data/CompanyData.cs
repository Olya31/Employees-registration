using DAL.Data.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Data
{
    public sealed class CompanyData : ICompanyData
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public CompanyData(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;
        }

        public async Task<int> AddAsync(Company company, CancellationToken token)
        {
            var sqlExpression = String.Format(
                "INSERT INTO Companies (Name, OrganizationalAndLegalForm) VALUES ('{0}', '{1}')",
                company.Name,
                company.OrganizationalAndLegalForm);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken token)
        {
            var sqlExpression = String.Format("Delete FROM Companies WHERE Id='{0}'", id);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<int> UpdateAsync(Company company, CancellationToken token)
        {
            var sqlExpression = String.Format(
                "UPDATE Companies SET Name='{0}', OrganizationalAndLegalForm ='{1}' WHERE Id='{2}'",
                company.Name, company.OrganizationalAndLegalForm, company.Id);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<Company> GetByIdAsync(int id, CancellationToken token)
        {
            var sqlExpression = String.Format("SELECT c.Id, c.[Name], c.OrganizationalAndLegalForm, " +
                "COUNT(e.CompanyId) as CountEmployees " +
                "FROM Companies as c " +
                "left JOIN Employees as e ON e.CompanyId = c.Id " +
                "WHERE c.Id='{0}' " +
                "GROUP BY c.Id, c.[Name], c.OrganizationalAndLegalForm ", id);

            var company = new Company(0, "", "", 0);

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(token);
                var command = new SqlCommand(sqlExpression, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync(token))
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync(token))
                        {
                            var Id = reader.GetInt32(0);
                            var Name = reader.GetString(1);
                            var Description = reader.GetString(2);
                            var CountEmployees = reader.GetInt32(3);
                            var companyItem = new Company(Id, Name, Description, CountEmployees);
                            company = companyItem;
                        }
                    }
                }
            }

            return company;
        }

        public async Task<IEnumerable<Company>> GetAllAsync(CancellationToken token)
        {
            string sqlExpression = "SELECT c.Id, c.[Name], c.OrganizationalAndLegalForm, " +
                "COUNT(e.CompanyId) as CountEmployees " +
                "FROM Companies as c " +
                "LEFT JOIN Employees as e ON e.CompanyId = c.Id " +
                "GROUP BY c.Id, c.[Name], c.OrganizationalAndLegalForm";

            var companys = new List<Company>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(token);
                var command = new SqlCommand(sqlExpression, connection);

                using (var reader = await command.ExecuteReaderAsync(token))
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync(token))
                        {
                            var Id = reader.GetInt32(0);
                            var Name = reader.GetString(1);
                            var Description = reader.GetString(2);
                            var CountEmployees = reader.GetInt32(3);
                            var company = new Company(Id, Name, Description, CountEmployees);
                            companys.Add(company);
                        }
                    }
                }
            }

            return companys;
        }

        private async Task<int> GetConnectionAsync(string sqlExpression, CancellationToken token)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(token);
                var command = new SqlCommand(sqlExpression, connection);

                return command.ExecuteNonQuery();
            }
        }
    }
}
