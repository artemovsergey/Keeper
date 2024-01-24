using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// функции посетителей

public interface IUserService
{

    // может зарегистрироваться
    void Sign(User user);

    // может авторизоваться
    void Auth(User user);

    // может посмотреть свои заявки
    IEnumerable<Statement> GetStatements(User user);

}
