using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq.Dynamic.Core;

namespace Keeper.Domen.Data;


public class RoleRepository : IRoleRepository
{

    private readonly KeeperContext _db;
    public RoleRepository(KeeperContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Role>> GetRoles()
    {
        return await _db.Roles.ToListAsync();
    }

    public async Task<bool> IsNameUniq(string role)
    {
       return await _db.Roles.AnyAsync(r => r.Name == role);
    }
}
