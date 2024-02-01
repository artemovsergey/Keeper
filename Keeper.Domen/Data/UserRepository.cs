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


public class UserRepository : IUserRepository
{

    private readonly KeeperContext _db;
    public UserRepository(KeeperContext db)
    {
        _db = db;
    }

    public async Task<int> Count()
    {
        return await _db.Users.CountAsync();
    }


    public async Task<IEnumerable<User>> Users(int pageIndex,
                                               int pageSize,
                                               string sortColumn,
                                               string sortOrder,
                                               string filterColumn,
                                               string filterQuery)
    {

        if (!string.IsNullOrEmpty(sortColumn) && IsValidProperty(sortColumn))
        {
            sortOrder = !string.IsNullOrEmpty(sortOrder) && sortOrder.ToUpper() == "ASC"
            ? "ASC"
            : "DESC";
        }

        IQueryable<User> users = _db.Users;

        if (!string.IsNullOrEmpty(filterColumn) 
            && !string.IsNullOrEmpty(filterQuery)
            && IsValidProperty(filterColumn))
        { 
            //users = users.Where(u => $"{filterColumn}".Contains($"{filterQuery})"));
            users = users.Where($"{filterColumn}.Contains(@0)", filterQuery);

            Console.WriteLine($"Фильтрация: {users.Count()}");
        }

        return await users.OrderBy($"{sortColumn} {sortOrder}")
                              .Skip(pageIndex * pageSize)
                              .Take(pageSize)
                              
                              .ToListAsync();
    }

    public async Task Create(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task<User> Get(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task Edit(User user)
    {
        _db.Entry(user).State = EntityState.Modified;
        await _db.SaveChangesAsync(); 
    }

    public async Task Remove(int id)
    {
        var user = await _db.Users.FindAsync(id);

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
    }


    public static bool IsValidProperty(string propertyName,
                                   bool throwExceptionIfNotFound = true)
    {
        var prop = typeof(User).GetProperty(
        propertyName,

        BindingFlags.IgnoreCase |
        BindingFlags.Public |
        BindingFlags.Instance);
        if (prop == null && throwExceptionIfNotFound)
            throw new NotSupportedException(
            string.Format($"ERROR: Property '{propertyName}' does not exist.")
         );
        return prop != null;

    }

}
