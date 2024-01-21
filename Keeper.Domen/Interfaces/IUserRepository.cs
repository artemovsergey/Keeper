using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

public interface IUserRepository
{
    User Create();

    void AddUser(User user);

    IEnumerable<User> Users();

    int CountUsers();
}
