namespace ADO.NET.Task1.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
    public User()
    {
            
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Email: {Email}";
    }
}
