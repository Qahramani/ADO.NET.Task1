using ADO.NET.Task1.DAL;
using ADO.NET.Task1.Exceptions;
using ADO.NET.Task1.Helpers;
using ADO.NET.Task1.Models;
using ADO.NET.Task1.Services.Interfaces;
using System.Data;

namespace ADO.NET.Task1.Services.Implementations;

public class UserService : IUserService
{
    public void Create(User user)
    {
        string command = $"insert into Users values('{user.Name}','{user.Email}')";
        int result = AppDbContext.NonQueryExecute(command);
        if (result == 0)
        {
            throw new CommandIsFailedException();
        }
        Colored.WriteLine("User succesfully created", ConsoleColor.DarkGreen);
    }

    public void Update(int Id,User user)
    {
        var tempUser = GetAll().FirstOrDefault(x => x.Id == Id);
        if (tempUser is null)
            throw new NotFoundException("User not found");
        string command = $"update Users set Name = '{user.Name}', Email = '{user.Email}' where Id = {tempUser.Id}";
        int result = AppDbContext.NonQueryExecute(command);
        if(result == 0)
        {
            throw new CommandIsFailedException();
        }
        Colored.WriteLine("User successfully updated", ConsoleColor.DarkGreen);
    }

    public void Delete(int id)
    {
        var user = GetAll().FirstOrDefault(x => x.Id == id);
        if (user is null)
            throw new NotFoundException("User Not Found");

        string command = $"delete from Users where Id = {user.Id}";
        var result = AppDbContext.NonQueryExecute(command);
        if(result == 0)
            throw new CommandIsFailedException();

        Colored.WriteLine("User successfully deleted", ConsoleColor.DarkGreen);
    }

    public List<User> GetAll()
    {
        List<User> users = new List<User>();
        string query = "select * from Users";
        DataTable dt = AppDbContext.QueryExecute(query);
        foreach (DataRow row in dt.Rows)
        {
            User user = new User()
            {
                Id = (int)row["Id"],
                Name = row["Name"].ToString(),
                Email = row["Email"].ToString()
            };
            users.Add(user);
        }
        return users;
    }
    public User GetById(int id)
    {
        foreach (var user in GetAll())
        {
            if(user.Id == id)
                return user;
        }
        throw new NotFoundException("User not found");
    }


}
