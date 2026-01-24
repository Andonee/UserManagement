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
        User Create(User user);
        User? GetById(int id);

        List<User> GetAll();
        bool Remove(int id);
        User Update(int id, string name);

        List<User> GetUsersOlderThan(int age);

        List<User> GetAllSortedByLastName();

        List<User> GetActiveUsersSortedByAge();

        List<string> GetUserEmails();

        Dictionary<string, List<User>> GroupUsersByDepartment();

        int CountAdmins();

        User? GetUserByEmail(string email);

        int GetMaxAge();

        int GetAverageAge();

        List<string GetDistinctDepartments();
    }
}
