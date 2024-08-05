using ADO.NET.Task1.Exceptions;
using ADO.NET.Task1.Helpers;
using ADO.NET.Task1.Models;
using ADO.NET.Task1.Services.Implementations;

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
                    string name = Console.ReadLine().Trim();
                    Console.Write("User Email: ");
                    string email = Console.ReadLine().Trim();
                    if (!Validations.IsEmailCorrect(email))
                        goto restart;

                    var doesEmailExist = userService.GetAll().FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
                    if (doesEmailExist is not null)
                    {
                        Colored.WriteLine("User with this email already exist", ConsoleColor.Blue);
                        goto restart;
                    }

                    userService.Create(new User(name, email));
                    goto restart;
                case "2":
                    try
                    {
                        Console.Write("Id of user that you want update: ");
                        int updateId = int.Parse(Console.ReadLine());

                        Console.Write("New Name: ");
                        string newName = Console.ReadLine().Trim();
                        Console.Write("New Email: ");
                        string newEmail = Console.ReadLine().Trim();
                        if (!Validations.IsEmailCorrect(newEmail))
                            goto restart;
                        var doesEmailExist2 = userService.GetAll().FirstOrDefault(x => x.Email.ToUpper() == newEmail.ToUpper());
                        if(doesEmailExist2 is not null)
                        {
                            Colored.WriteLine("User with this email already exist", ConsoleColor.Blue);
                            goto restart;
                        }
                        userService.Update(updateId, new User(newName, newEmail));
                    }
                    catch (NotFoundException ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    catch (CommandIsFailedException ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    catch (Exception ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    goto restart;
                case "3":
                    Console.WriteLine("--- Users List ---");
                    foreach (User user in userService.GetAll())
                    {
                        Colored.WriteLine(user.ToString(), ConsoleColor.Cyan);
                    }
                    try
                    {
                        Console.Write("Id of user that you want delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        userService.Delete(deleteId);

                    }
                    catch (NotFoundException ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    catch (CommandIsFailedException ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    catch (Exception ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    goto restart;
                case "4":
                    try
                    {
                        Console.Write("Id: ");
                        int getId = int.Parse(Console.ReadLine());
                        var foundUser = userService.GetById(getId);
                        Colored.WriteLine(foundUser.ToString(), ConsoleColor.Magenta);
                    }
                    catch (NotFoundException ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }
                    catch (Exception ex)
                    {
                        Colored.WriteLine(ex.Message, ConsoleColor.DarkRed);
                        goto restart;
                    }

                    goto restart;
                case "5":
                    Console.WriteLine("--- Users List ---");
                    foreach (var user in userService.GetAll())
                    {
                        Console.WriteLine(user);
                    }
                    goto restart;
                case "0":
                    Colored.WriteLine("Goodbye...", ConsoleColor.DarkYellow);
                    return;
                default:
                    Colored.WriteLine("Invalid input", ConsoleColor.DarkYellow);
                    goto restart;
            }

        }
    }
}
