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
    Task<IEnumerable<User>> Users(int pageIndex,
                                  int pageSize,
                                  string sortColumn,
                                  string sortOrder,
                                  string filterColumn,
                                  string filterQuery);
    Task Create(User user);
    Task<User> Get(int id);
    Task Edit(User user);
    Task Remove(int id);
    Task<int> Count();

    Task<bool> IsUniqEmail(User user);


}
