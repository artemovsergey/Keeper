namespace Keeper.Domen.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetRoles();

    Task<bool> IsNameUniq(string role);
}
