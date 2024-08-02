using ADO.NET.Task1.DAL;
using ADO.NET.Task1.Models;
using System.Data;

namespace ADO.NET.Task1.Services;

public class UserService
{
    AppDbContext appDbContext = new AppDbContext();
    public void CreateUser(User user)
    {
        string command = $"insert into Users values('{user.Name}','{user.Email}')";
        int result = appDbContext.NonQueryExecute(command);
        if(result > 0)
        {
            Console.WriteLine($"User [{user.Name}] is succesfully added");
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }
    }
    public void GetAllUsers()
    {
        string command = "select * from Users";
        DataTable table = appDbContext.QueryExecute(command);
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine("ID: " + row["Id"].ToString() + ", Name: " + row["Name"].ToString() + ", Email: " + row["Email"].ToString());
        }
    }
    public bool GetById(int id)
    {
        string command = "select * from Users";
        DataTable table = appDbContext.QueryExecute(command);
        foreach(DataRow row in table.Rows)
        {
            if (row["Id"].ToString() == id.ToString())
            {
                Console.WriteLine("ID: " + row["Id"].ToString() + ", Name: " + row["Name"].ToString() + ", Email: " + row["Email"].ToString());
                return true;
            }
        }
        return false;
    }
    public void DeleteById(int id)
    {
        string select = "select * from Users";
        string delete = $"delete from Users where Id = {id}";
        DataTable table = appDbContext.QueryExecute(select);
        foreach (DataRow row in table.Rows)
        {
            if (row["Id"].ToString() == id.ToString())
            {
               int result = appDbContext.NonQueryExecute(delete);
                if(result > 0)
                {
                    Console.WriteLine("User deleted succesfully");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
                return;
            }
        }
        Console.WriteLine("User with given Id is not found");
    }
    public void UpdateUser(int Id, User user)
    {
        if (!GetById(Id))
        {
            Console.WriteLine("Usser with given Id is not found");
            return;
        }
        string update = $"update Users set Name = '{user.Name}', Email = '{user.Email}' where Id = {Id}";
        int result = appDbContext.NonQueryExecute(update);
        if (result > 0)
        {
            Console.WriteLine("User updated succesfully");
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }
    }
}

