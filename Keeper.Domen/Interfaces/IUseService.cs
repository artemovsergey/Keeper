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

    // регистрация пользователя
    void Sign(User user);

    // аутентификация пользователя
    void Auth(User user);

    // может посмотреть заявки пользователя
    IEnumerable<Statement> GetStatements(User user);

    // добавить пользователя в бан
    void AddToBanList(User user);

}
