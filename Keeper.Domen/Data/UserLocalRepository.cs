using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data;


public class UserLocalRepository
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

    public Task Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task Edit(User user)
    {
        throw new NotImplementedException();
    }

    public Task Edit(int id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> Get(int id)
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Remove(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> Users()
    {
        return users;
    }


}
