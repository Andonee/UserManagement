using System;
using UserManagement;

class Program
{
    static void Main(string[] args)
    {

        List<User> users = new List<User>();


        while (true)
        {
            ShowMenu();
            int option = ReadMenuOption();
            switch (option)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    User user = CreateUser();
                    users.Add(user);
                    break;
                case 3:
                    ShowUser(users);
                    break;
                case 4:
                    ShowAllUsers(users);
                    break;
                case 5:
                    RemoveUser(users);
                   
                    break;
                case 6:
               UpdateUser(users);
            
                    break;
                default: break;
            }

           
        }


    }

    static int ReadMenuOption()
    {
        while (true)
        {
            string input = ReadRequiredInput("Enter option (1-6): ");
            Console.WriteLine("");
            if (int.TryParse(input, out int option) && option >= 1 && option <= 6)
                return option;

            Console.WriteLine("Invalid option. Please enter a number between 1 and 6.");
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("------");
        Console.WriteLine("");
        Console.WriteLine("Select option: ");
        Console.WriteLine("menu - 1");
        Console.WriteLine("create user - 2");
        Console.WriteLine("Show user - 3");
        Console.WriteLine("Show all users - 4");
        Console.WriteLine("remove a user - 5");
        Console.WriteLine("update a user - 6");
        Console.WriteLine("");
        Console.WriteLine("------");
    }

    static User CreateUser()
    {
        int id = ReadRequiredInt("User ID: ");
        string Name = ReadRequiredInput("First Name: ");
        string LastName = ReadRequiredInput("LastName: ");
        string Email = ReadRequiredInput("Email: ");
   
        int Age = ReadRequiredInt("User age: ");
        string Status = ReadRequiredInput("Status: ");
        string Role = ReadRequiredInput("Role: ");
        string Department = ReadRequiredInput("Department: ");

        User user = new User(id, Name, LastName, Email, Age, Status, Role, Department);
       
        Console.WriteLine("New user has been created");
        return user;
    }

    static void UpdateUser(List<User> users)
    {
        int userId = ReadRequiredInt("User ID: ");

        var userToUpdate = users.Find(u => u.id == userId);

        if (userToUpdate is null)
        {

            Console.Write("There is no user with provided ID");
        }
        else
        {
            string Name = ReadRequiredInput("First Name: ");
            string LastName = ReadRequiredInput("LastName: ");
            string Email = ReadRequiredInput("Email: ");
            int.TryParse(ReadRequiredInput("User age: "), out int age);
            int Age = age;
            string Status = ReadRequiredInput("Status: ");
            string Role = ReadRequiredInput("Role: ");
            string Department = ReadRequiredInput("Department: ");

            userToUpdate.name = Name;   
            userToUpdate.lastName = LastName;
            userToUpdate.email = Email;
            userToUpdate.age = Age;
            userToUpdate.status = Status;
            userToUpdate.role = Role;
            userToUpdate.department = Department;

            Console.WriteLine("New user has been updated");

            
        }
        
    }

    static void RemoveUser(List<User> users)
    {
        int userId = ReadRequiredInt("User ID: ");

        var userToRemove = users.Find(u => u.id == userId);

        if (userToRemove != null)
        {

            Console.WriteLine("Removing user: " + userToRemove);
        }else
        {
            
            Console.Write("\nThere is no user with provided ID\n");
        }

            // RemoveAll returns the number of removed items, not a new list.
            // To return the updated list, remove in-place and return the same list.
            users.RemoveAll(u => u.id == userId);
    }

    static void ShowUser(List<User> users)
    {
        string IdAsString = ReadRequiredInput("User ID: ");

        int.TryParse(IdAsString, out int number);
        int userId = number;

        var userToRemove = users.Find(u => u.id == userId);

        if (userToRemove != null)
        {

            Console.WriteLine(userToRemove.ToString());
        }else
        {
            Console.Write("There is no user with provided ID");
        }

  
    }

    static void ShowAllUsers(List<User> users)
    {
        if(users.Count == 0)
        {
            Console.WriteLine("There are no users");
            
        }else
        {
            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
           
}

    static string ReadRequiredInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim(); // remove leading/trailing spaces
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: This field is required. Please enter a value.");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    static int ReadRequiredInt(string prompt)
    {
        while (true)
        {
            string input = ReadRequiredInput(prompt);
            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Error: Please enter a valid number.");
        }
    }
}
