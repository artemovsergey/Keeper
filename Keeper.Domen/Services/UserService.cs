using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        Console.WriteLine("Создался новый объект сервиса!");
        _userRepository =  userRepository;
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public User CreateUser()
    {
       return _userRepository.Create();
    }

    public void DeleteUser()
    {
        throw new NotImplementedException();
    }

    public void EditUser()
    {
        throw new NotImplementedException();
    }

    public User GetUser()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsers()
    {
        return _userRepository.Users();
    }

    public int CountUsers()
    {
       return _userRepository.CountUsers();
    }

}
