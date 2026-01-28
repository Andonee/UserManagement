using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Services
{
    internal class UserService:IUserService
    {

        private int _nextId = 1;
        //private readonly List<User> _users = new();
        private readonly AppDbContext _context = new();

        public UserService()
        {
            //SeedUsers(); // wypełnia listę 100 userami przy starcie
        }

        public async Task<User> Create(User user)
        {
            //var created = user with { Id = 0 }; //EF ustawi Id
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Saved user, Id = {user.Id}");
            return user;

        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(int id, string name)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) return null;


            var updatedUser = user with { Name = name };
            _context.Users.Remove(user);
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return updatedUser;
        }

        public async Task<bool> Remove(int id)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                return false;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetUsersOlderThan(int age)
        {
            var users = await _context.Users.Where(u => u.Age > age).ToListAsync();
            return users;
        }

        public async Task<List<User>> GetAllSortedByLastName()
        {

            var users = await _context.Users.OrderByDescending(u => u.LastName).ToListAsync();
            return users;
        }

        public async Task<List<User>> GetActiveUsersSortedByAge()
        {
            var users = await _context.Users.Where(u => u.Status == "Active").OrderByDescending(u => u.Age).ToListAsync();
            return users;
        }

        public async Task<List<string>> GetUserEmails()
        {
            var emails = await _context.Users.Select(u => u.Email).ToListAsync();
            return emails;
        }

        public async Task<Dictionary<string, List<User>>> GroupUsersByDepartment()
        {
            var users = await _context.Users.GroupBy(u => u.Department).ToDictionaryAsync(g => g.Key, g=>g.ToList());
            return users;
        }

        public async Task<int> CountAdmins()
        {

            var admins = await _context.Users.Where(u => u.Role == "Admin").ToListAsync();
            return admins.Count();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<int?> GetMaxAge()
        {
            var maxAge = await _context.Users.Select(u => (int?)u.Age).MaxAsync();
            return maxAge;
        }

        public async Task<double> GetAverageAge()
        {
            var average = await _context.Users.AverageAsync(u => u.Age);
            return average;
        }

        public async Task<List<string>> GetDistinctDepartments()
        {
            var departments = await _context.Users.Select(u => u.Department).Distinct().ToListAsync();
            return departments;
        }






        private async Task SeedUsers()
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
                    //Id = _nextId++, // auto-increment ID
                    Name = firstNames[random.Next(firstNames.Length)],
                    LastName = lastNames[random.Next(lastNames.Length)],
                    Email = $"user{i + 1}@example.com",
                    Age = random.Next(18, 65), // losowy wiek 18-64
                    Status = statuses[random.Next(statuses.Length)],
                    Role = roles[random.Next(roles.Length)],
                    Department = departments[random.Next(departments.Length)]
                };

                //_users.Add(user);
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();

        }
    }
}
