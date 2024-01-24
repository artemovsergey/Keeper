using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data;


public class BanListLocalRepository : IBanListRepository
{

    private readonly List<User> banList = new List<User>();

    public void Add(User user)
    {
        banList.Add(user);
    }

    public void Delete(User user)
    {
        banList.Remove(user);
    }
}
