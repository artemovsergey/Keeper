using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

public interface IUserService
{
    // регистрация пользователя
    void Sign(User user);

    // аутентификация пользователя
    void Auth(User user);

    // просмотр ранее поданных заявок
    IEnumerable<Statement> GetStatements(User user);


    User CreateUser();

    User GetUser();

    void AddUser(User user);

    IEnumerable<User> GetUsers();

    void DeleteUser();
    void EditUser();

    int CountUsers();

}
