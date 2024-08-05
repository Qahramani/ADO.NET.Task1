using ADO.NET.Task1.Models;

namespace ADO.NET.Task1.Services.Interfaces;

public interface IUserService
{
     void Create(User user);
     void Update(int Id,User user);
    void Delete(int id);

    User GetById(int id);
    List<User> GetAll();


}
