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
    public sealed class EmployeeData : IEmployeeData
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public EmployeeData(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("sqlConnection").Value;
        }

        public async Task<int> AddAsync(Employee employee, CancellationToken token)
        {
            var sqlExpression = String.Format(
                "INSERT INTO Employees " +
                "(Surname, Name, MiddleName, EmploymentDate, CompanyId, Position)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                employee.Surname,
                employee.Name,
                employee.MiddleName,
                employee.EmploymentDate,
                employee.CompanyId,
                employee.Position);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken token)
        {
            var sqlExpression = String.Format("Delete FROM Employees WHERE Id='{0}'", id);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<int> UpdateAsync(Employee employee, CancellationToken token)
        {
            var sqlExpression = String.Format(
                "UPDATE Employees SET Surname='{0}', Name ='{1}', MiddleName ='{2}', EmploymentDate ='{3}'," +
                " CompanyId ='{4}'," +
                " Position ='{5}'" +
                " WHERE Id='{6}'",
                employee.Surname,
                employee.Name,
                employee.MiddleName,
                employee.EmploymentDate,
                employee.CompanyId,
                employee.Position,
                employee.Id);

            return await GetConnectionAsync(sqlExpression, token);
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken token)
        {
            var sqlExpression = String.Format("SELECT e.*, c.Name as CompanyName " +
                "FROM Employees AS e " +
                "INNER JOIN Companies as c ON (e.CompanyId=c.id) " +
                "WHERE e.Id='{0}'", id);

            var employee = new Employee(0, "", "", "", DateTime.Now, 0, "", "");

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
                            var Surname = reader.GetString(1);
                            var Name = reader.GetString(2);
                            var MiddleName = reader.GetString(3);
                            var EmploymentDate = reader.GetDateTime(4);
                            var CompanyId = reader.GetInt32(5);
                            var Position = reader.GetString(6);
                            var CompanyName = reader.GetString(7);
                            var employeeItem = new Employee(
                                Id,
                                Surname,
                                Name,
                                MiddleName,
                                EmploymentDate,
                                CompanyId,
                                Position,
                                CompanyName);
                            employee = employeeItem;
                        }
                    }
                }
            }

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken token)
        {
            string sqlExpression = "SELECT e.*, c.Name as CompanyName " +
                "FROM Employees AS e " +
                "INNER JOIN Companies as c ON (e.CompanyId=c.id)";

            var employees = new List<Employee>();

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
                            var Surname = reader.GetString(1);
                            var Name = reader.GetString(2);
                            var MiddleName = reader.GetString(3);
                            var EmploymentDate = reader.GetDateTime(4);
                            var CompanyId = reader.GetInt32(5);
                            var Position = reader.GetString(6);
                            var CompanyName = reader.GetString(7);
                            var employee = new Employee(
                                Id,
                                Surname,
                                Name,
                                MiddleName,
                                EmploymentDate,
                                CompanyId,
                                Position,
                                CompanyName);
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
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
