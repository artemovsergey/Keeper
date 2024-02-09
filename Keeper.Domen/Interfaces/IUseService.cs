using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// функции сервиса по работе с посетителями

public interface IUserService
{

    Task<IEnumerable<User>> Users(int pageIndex,
                                  int pageSize,
                                  string sortColumn,
                                  string sortOrder,
                                  string filterColumn,
                                  string filterQuery);

    // регистрация пользователя
    Task Sign(User user);

    // аутентификация пользователя
    void Auth(User user);

    // может посмотреть заявки пользователя
    IEnumerable<Statement> GetStatements(User user);

    // добавить пользователя в бан
    void AddToBanList(User user);
    Task<User> GetUserById(int id);
    Task EditUser(User user);
    Task RemoveUser(int id);

    Task<int> Count();

    Task<bool> IsUniqEmail(User user);

}
