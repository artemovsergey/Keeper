using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetRoles();

    Task<bool> IsRoleUniq(string role);
}
