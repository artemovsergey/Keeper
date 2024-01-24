using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data;


public class UserLocalRepository : IUserRepository
{

    private readonly List<User> users = new List<User>();
    public UserLocalRepository()
    {

    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User Create()
    {
        return new User() { Id = 1, Email = "test@test.ru", Login = "test", Password = "test" };
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> Users()
    {
        return users;
    }

}
