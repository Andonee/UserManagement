using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    internal class User
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string lastName { get; set; } = "";
        public string email { get; set; } = "";
        public int age { get; set; } = 0;
        public string status { get; set; } = "";
        public string role { get; set; } = "";
        public string department { get; set; } = "";

        public User(int id,string Name, string LastName, string Email, int Age, string Status, string Role, string Department)
        {
            this.id = id;
            this.name = Name;
            this.lastName = LastName;
            this.email = Email;
            this.age = Age;
            this.status = Status;
            this.role = Role;
            this.department = Department;
        }

        public override string ToString()
        {
            return $"ID: {id},User: {name} {lastName}, Email: {email}, Age: {age}, Status: {status}, Role: {role}, Department: {department}";
        }

    }
}
