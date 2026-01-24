using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services
{
    internal interface IUserService
    {
        Task<User> Create(User user);
        Task<User?> GetById(int id);

        Task<List<User>> GetAll();
        Task<bool> Remove(int id);
        Task<User> Update(int id, string name);

        Task<List<User>> GetUsersOlderThan(int age);

        Task<List<User>> GetAllSortedByLastName();

        Task<List<User>> GetActiveUsersSortedByAge();

        Task<List<string>> GetUserEmails();

        Task<Dictionary<string, List<User>>> GroupUsersByDepartment();

        Task<int> CountAdmins();

        Task<User?> GetUserByEmail(string email);

        Task<int> GetMaxAge();

        Task<double> GetAverageAge();

        Task<List<string>> GetDistinctDepartments();
    }
}
