using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserManagement.Models;

namespace UserManagement.Services
{
    internal class UserService:IUserService
    {

        private int _nextId = 1;
        private readonly List<User> _users = new();

        public UserService()
        {
            SeedUsers(); // wypełnia listę 100 userami przy starcie
        }

        public User Create(User user)
        {
            var createdUser = user with { Id = _nextId++ };
            _users.Add(createdUser);
            return createdUser;

        }

        public User? GetById(int id)
        {

            return  _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User Update(int id, string name)
        {
            var index = _users.FindIndex(u => u.Id == id);
            if (index == -1)
                throw new InvalidOperationException("User not found");

            var updatedUser = _users[index] with { Name = name };
            _users[index] = updatedUser;

            return updatedUser;
        }

        public bool Remove(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user is null)
                return false;

            _users.Remove(user);
            return true;
        }

        public List<User> GetUsersOlderThan(int age)
        {
            return _users.Where(u => u.Age > age).ToList();
        }

        public List<User> GetAllSortedByLastName()
        {
            return _users.OrderBy(u => u.LastName).ToList();
        }

        public List<User> GetActiveUsersSortedByAge()
        {
            return _users.Where(u => u.Status == "Active").OrderBy(u => u.Age).ToList();
        }

        public List<string> GetUserEmails()
        {
            return _users.Select(u => u.Email).ToList();
        }

        public Dictionary<string, List<User>> GroupUsersByDepartment()
        {
            return _users.GroupBy(u => u.Department).ToDictionary(g => g.Key, g => g.ToList());
        }

        public int CountAdmins()
        {
            return _users.Count(u => u.Role == "Admin");
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public int GetMaxAge()
        {
            return _users.Max(u => u.Age);
        }

        public double GetAverageAge()
        {
            return _users.Average(u => u.Age);
        }

        public List<string> GetDistinctDepartments()
        {
            return _users.Select(u =>u.Department).Distinct().ToList();
        }






        private void SeedUsers()
        {
            var firstNames = new[] { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Ivan", "Jack" };
            var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Wilson", "Taylor", "Anderson" };
            var departments = new[] { "IT", "HR", "Finance", "Marketing", "Sales" };
            var roles = new[] { "Admin", "User", "Manager", "Guest" };
            var statuses = new[] { "Active", "Inactive", "Pending" };

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var user = new User
                {
                    Id = _nextId++, // auto-increment ID
                    Name = firstNames[random.Next(firstNames.Length)],
                    LastName = lastNames[random.Next(lastNames.Length)],
                    Email = $"user{i + 1}@example.com",
                    Age = random.Next(18, 65), // losowy wiek 18-64
                    Status = statuses[random.Next(statuses.Length)],
                    Role = roles[random.Next(roles.Length)],
                    Department = departments[random.Next(departments.Length)]
                };

                _users.Add(user);
            }
        }
    }
}
