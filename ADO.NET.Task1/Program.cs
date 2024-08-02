using ADO.NET.Task1.Models;
using ADO.NET.Task1.Services;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ADO.NET.Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            UserService userService = new UserService();

            restart:
            Console.WriteLine("----- User Menu ------");
            Console.Write("[1] Create User\n" +
                "[2] Update User\n" +
                "[3] Delete User\n" +
                "[4] Get User by Id\n" +
                "[5] Get all Users\n" +
                "[0] Exit\n" +
                ">>> ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("--- User Creation ---");
                    Console.Write("User Name: ");
                    string name = Console.ReadLine();
                    Console.Write("User Email: ");
                    string email = Console.ReadLine();
                    userService.CreateUser(new User(name, email));
                    goto restart;
                case "2":
                    Console.Write("Id of user that you want update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    if (!userService.GetById(updateId))
                    {
                        Console.WriteLine("User not found");
                        goto restart;
                    }
                    Console.Write("New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("New Email: ");
                    string newEmail = Console.ReadLine();
                    userService.UpdateUser(updateId,new User(newName, newEmail));
                    goto restart;
                case "3":
                    Console.WriteLine("--- Users List ---");
                    userService.GetAllUsers();
                    Console.Write("Id of user that you want delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    if (!userService.GetById(deleteId))
                    {
                        Console.WriteLine("User not found");
                        goto restart;
                    }
                    userService.DeleteById(deleteId);
                    goto restart;
                case "4":
                    Console.Write("Id: ");
                    int getId = int.Parse(Console.ReadLine());
                    if (!userService.GetById(getId))
                        Console.WriteLine("User not found");

                    goto restart;
                case "5":
                    Console.WriteLine("--- Users List ---");
                    userService.GetAllUsers();
                    goto restart;
                case "0":
                    Console.WriteLine("Goodbye...");
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    goto restart;
            }

        }
    }
}
