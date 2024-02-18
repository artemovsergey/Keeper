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
