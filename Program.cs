using System;
using UserManagement;
using UserManagement.Models;
using UserManagement.Services;
using UserManagement.Utils;

class Program
{
    static void Main(string[] args)
    {
        IUserService userService = new UserService();
        var ReadRequiredInt = ConsoleInputHelper.ReadRequiredInt;
        var ReadRequiredInput = ConsoleInputHelper.ReadRequiredInput;

        List<User> users = new List<User>();


        while (true)
        {
            ShowMenu();
            int input = ReadRequiredInt("Enter option (1-21): ");
            int option = ReadMenuOption(input);
            switch (option)
            {
                case 1:
                    ShowMenu();
                    break;
                case 2:
                    var user = new User
                    {
                        Name = ReadRequiredInput("First Name: "),
                        LastName = ReadRequiredInput("Last Name: "),
                        Email = ReadRequiredInput("Email: "),
                        Age = ReadRequiredInt("User age: "),
                        Status = ReadRequiredInput("Status: "),
                        Role = ReadRequiredInput("Role: "),
                        Department = ReadRequiredInput("Department: ")
                    };

                    var created = userService.Create(user);

                    Console.WriteLine($"User created with ID: {created.Id}");
                //User user = CreateUser();
                //users.Add(user);
                break;
                case 3:
                    int id = ReadRequiredInt("User ID: ");

                    User? foundedUser = userService.GetById(id);
                    if (foundedUser is not null)
                    {
                        Console.WriteLine(foundedUser.ToString());
                    }
                    break;
                case 4:
                    List<User> allUsers = userService.GetAll();

                    foreach (User u in allUsers)
                    {
                        Console.WriteLine(u.ToString());
                    }
                    break;
                case 5:
                    int userId = ReadRequiredInt("User ID: ");

                    bool removed = userService.Remove(userId);

                    if (removed)
                    {
                        Console.WriteLine("User has been removed");
                    }else
                    {
                        Console.WriteLine("User does not exist" );
                    }

                    break;
                case 6:
                    int userID = ReadRequiredInt("User ID: ");
                    string name = ReadRequiredInput("Name: ");

                    User updatedUser = userService.Update(userID, name);
                    Console.WriteLine("User has been updated.");
                    break;
                case 7:
                    int age = ReadRequiredInt("User age: ");
                    List<User> usersOlder = userService.GetUsersOlderThan(age);

                    foreach (User u in usersOlder)
                    {
                        Console.WriteLine(u.ToString());
                    }
                    break;
                case 8:
                    List<User> sortedByLastName = userService.GetAllSortedByLastName();

                    foreach (User u in sortedByLastName)
                    {
                        Console.WriteLine(u.ToString());
                    }
                    break;
                case 9:
                    List<User> activeUsersSortedByAge = userService.GetActiveUsersSortedByAge();

                    foreach(User u in activeUsersSortedByAge)
                    {
                        Console.WriteLine(u.ToString());
                    }
                    break;
                case 10:
                    List<string> emails = userService.GetUserEmails();

                    foreach(string e in emails)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                case 11:
                    var grouped = userService.GroupUsersByDepartment();

                    foreach (var kvp in grouped)
                    {
                        Console.WriteLine($"Department: {kvp.Key}");
                        foreach (var u in kvp.Value)
                        {
                            Console.WriteLine($"- {u.Name} {u.LastName}");
                        }
                    }
                    break;
                case 12:
                int adminAmount = userService.CountAdmins();
                Console.WriteLine($"Admins amount {adminAmount}");
                break;

                case 13:
                    string email = ReadRequiredInput("Email: ");
                    User? userByEmail = userService.GetUserByEmail(email);

                    if(userByEmail is not null)
                    {
                        Console.WriteLine($"This is user you were looking for: {userByEmail}");
                    }
                    break;

                case 14:
                    int maxAgedUser = userService.GetMaxAge();
                    Console.WriteLine($"Max age is", maxAgedUser);
                    break;

                case 15:
                    Console.WriteLine($"Average age is: {userService.GetAverageAge()}");
                    break;
                case 16:
                    List<string> distinctDepartments = userService.GetDistinctDepartments();

                    foreach(string department in distinctDepartments)
                        { Console.WriteLine(department); }
                    break;

                default: break;
            }

           
        }


    }

    static int ReadMenuOption(int input)
    {
        while (true)
        {

            Console.WriteLine("");
            if (input >= 1 && input <= 21)
                return input;

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
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("GetAllSortedByLastName... - 8");
        Console.WriteLine("GetActiveUsersSortedByAge... - 9");
        Console.WriteLine("GetUserEmails... - 10");
        Console.WriteLine("GroupUsersByDepartment... - 11");
        Console.WriteLine("CountAdmins... - 12");
        Console.WriteLine("GetUserByEmail... - 13");
        Console.WriteLine("GetMaxAge... - 14");
        Console.WriteLine("GetAverageAge... - 15");
        Console.WriteLine("GetDistinctDepartments... - 16");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("users older than age... - 7");
        Console.WriteLine("");
        Console.WriteLine("------");
    }

//    static User CreateUser()
//    {
//        string Name = ReadRequiredInput("First Name: ");
//        string LastName = ReadRequiredInput("LastName: ");
//        string Email = ReadRequiredInput("Email: ");
   
//        int Age = ReadRequiredInt("User age: ");
//        string Status = ReadRequiredInput("Status: ");
//        string Role = ReadRequiredInput("Role: ");
//        string Department = ReadRequiredInput("Department: ");

//        User user = new User(Name, LastName, Email, Age, Status, Role, Department);
       
//        Console.WriteLine("New user has been created");
//        return user;
//    }

//    static void UpdateUser(List<User> users)
//    {
//        int UserId = ReadRequiredInt("User ID: ");

//        var userToUpdate = users.Find(u => u.UserId == UserId);

//        if (userToUpdate is null)
//        {

//            Console.Write("There is no user with provided ID");
//        }
//        else
//        {
//            string Name = ReadRequiredInput("First Name: ");
//            string LastName = ReadRequiredInput("LastName: ");
//            string Email = ReadRequiredInput("Email: ");
//            int.TryParse(ReadRequiredInput("User age: "), out int age);
//            int Age = age;
//            string Status = ReadRequiredInput("Status: ");
//            string Role = ReadRequiredInput("Role: ");
//            string Department = ReadRequiredInput("Department: ");

//            userToUpdate.name = Name;   
//            userToUpdate.lastName = LastName;
//            userToUpdate.email = Email;
//            userToUpdate.age = Age;
//            userToUpdate.status = Status;
//            userToUpdate.role = Role;
//            userToUpdate.department = Department;

//            Console.WriteLine("New user has been updated");

            
//        }
        
//    }

//    static void RemoveUser(List<User> users)
//    {
//        int UserId = ReadRequiredInt("User ID: ");

//        var userToRemove = users.Find(u => u.UserId == UserId);

//        if (userToRemove != null)
//        {

//            Console.WriteLine("Removing user: " + userToRemove);
//        }else
//        {
            
//            Console.Write("\nThere is no user with provided ID\n");
//        }

//            // RemoveAll returns the number of removed items, not a new list.
//            // To return the updated list, remove in-place and return the same list.
//            users.RemoveAll(u => u.UserId == UserId);
//    }

//    static void ShowUser()
//    {
//        string IdAsString = ReadRequiredInput("User ID: ");

//        int.TryParse(IdAsString, out int number);
//        int UserId = number;

//        var userToRemove = users.Find(u => u.UserId == UserId);

//        if (userToRemove != null)
//        {

//            Console.WriteLine(userToRemove.ToString());
//        }else
//        {
//            Console.Write("There is no user with provided ID");
//        }

  
//    }

//    static void ShowAllUsers(List<User> users)
//    {
//        if(users.Count == 0)
//        {
//            Console.WriteLine("There are no users");
            
//        }else
//        {
//            foreach (User user in users)
//            {
//                Console.WriteLine(user.ToString());
//            }
//        }
           
//}

   
}
