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

    public async Task<int> Count()
    {
        return await _userRepository.Count();
    }

    public async Task<IEnumerable<User>> Users(int pageIndex,
                                               int pageSize,
                                               string sortColumn,
                                               string sortOrder,
                                               string filterColumn,
                                               string filterQuery)
    {
        return await _userRepository.Users(pageIndex,
                                           pageSize,
                                           sortColumn,
                                           sortOrder,
                                           filterColumn,
                                           filterQuery);
    }

    public async Task Sign(User user)
    {

        // регистрация по почте и паролю
        // >= 8 length
        // up and down case
        // special symbol
        // save md5

        await _userRepository.Create(user);
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



    public void AddToBanList(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.Get(id);
    }

    public async Task EditUser(User user)
    {
        await _userRepository.Edit(user);
    }

    public async Task RemoveUser(int id)
    {
        await _userRepository.Remove(id);
    }
}
