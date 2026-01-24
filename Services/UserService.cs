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

        public async Task<User> Create(User user)
        {
            await Task.Delay(800);
            var createdUser = user with { Id = _nextId++ };
            _users.Add(createdUser);
            return createdUser;

        }

        public async Task<User?> GetById(int id)
        {
            await Task.Delay(100);
            return  _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            await Task.Delay(1000);
            return _users;
        }

        public async Task<User> Update(int id, string name)
        {
            await Task.Delay(800);
            var index = _users.FindIndex(u => u.Id == id);
            if (index == -1)
                throw new InvalidOperationException("User not found");

            var updatedUser = _users[index] with { Name = name };
            _users[index] = updatedUser;

            return updatedUser;
        }

        public async Task<bool> Remove(int id)
        {
            await Task.Delay(800);
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user is null)
                return false;

            _users.Remove(user);
            return true;
        }

        public async Task<List<User>> GetUsersOlderThan(int age)
        {
            await Task.Delay(800);
            return _users.Where(u => u.Age > age).ToList();
        }

        public async Task<List<User>> GetAllSortedByLastName()
        {
            await Task.Delay(1200);
            return _users.OrderBy(u => u.LastName).ToList();
        }

        public async Task<List<User>> GetActiveUsersSortedByAge()
        {
            await Task.Delay(800);
            return _users.Where(u => u.Status == "Active").OrderBy(u => u.Age).ToList();
        }

        public async Task<List<string>> GetUserEmails()
        {
            await Task.Delay(800);
            return _users.Select(u => u.Email).ToList();
        }

        public async Task<Dictionary<string, List<User>>> GroupUsersByDepartment()
        {
            await Task.Delay(800);
            return _users.GroupBy(u => u.Department).ToDictionary(g => g.Key, g => g.ToList());
        }

        public async Task<int> CountAdmins()
        {

            await Task.Delay(2000);
            return _users.Count(u => u.Role == "Admin");
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            await Task.Delay(800);
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<int> GetMaxAge()
        {
            await Task.Delay(800);
            return _users.Max(u => u.Age);
        }

        public async Task<double> GetAverageAge()
        {
            await Task.Delay(800);
            return _users.Average(u => u.Age);
        }

        public async Task<List<string>> GetDistinctDepartments()
        {
            await Task.Delay(800);
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
