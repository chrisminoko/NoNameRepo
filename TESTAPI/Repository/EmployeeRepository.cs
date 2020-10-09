using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTAPI.Interface;
using TESTAPI.Models;

namespace TESTAPI.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly IConfiguration configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Employee entity)
        {
            var sql = "INSERT INTO Employees (Name,Department,Age,City,Country ) Values  (@Name,@Department,@Age,@City,@Country)";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees Where Id=@Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var sql = "SELECT TOP 10 * FROM Employees WITH (NOLOCK)";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var results = await connection.QueryAsync<Employee>(sql);
            return results.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM  Employees WHERE Id=@Id";
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
            return result;
        }

        public Task<int> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
