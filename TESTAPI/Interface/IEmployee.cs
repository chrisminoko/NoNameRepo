using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTAPI.Models;

namespace TESTAPI.Interface
{
    public interface IEmployee
    {
        Task<Employee> GetByIdAsync(int id);
        Task<IReadOnlyList<Employee>> GetAllAsync();
        Task<int> AddAsync(Employee entity);
        Task<int> UpdateAsync(Employee entity);
        Task<int> DeleteAsync(int id);
    }
}
