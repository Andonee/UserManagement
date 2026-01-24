using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    internal record User
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string LastName { get; init; } = "";
        public string Email { get; init; } = "";
        public int Age { get; init; }
        public string Status { get; init; } = "";
        public string Role { get; init; } = "";
        public string Department { get; init; } = "";
    }
}
