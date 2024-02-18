namespace Keeper.Domen.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetRoles();

    Task<bool> IsRoleUniq(string role);
}
