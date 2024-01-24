using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Services;

// реализация функций cервиса по работе с пользователями
// сервис предоставляет данные для сериализации контроллеру API
// данные он может просить у механизма хранения

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository =  userRepository;
    }

    public void Auth(User user)
    {
        // авторизация по логину и паролю

        throw new NotImplementedException();
    }

    public IEnumerable<Statement> GetStatements(User user)
    {
        throw new NotImplementedException();
    }

    public void Sign(User user)
    {

        // регистрация по почте и паролю
        // >= 8 length
        // up and down case
        // special symbol
        // save md5


        throw new NotImplementedException();
    }

    public void AddToBanList(User user)
    {
        throw new NotImplementedException();
    }

}
