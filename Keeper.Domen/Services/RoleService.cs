using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;

namespace Keeper.Domen.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;
    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Role>> GetRoles()
    {
        return await _repository.GetRoles();
    }

    public async Task<bool> IsRoleUniq(string role)
    {
        return await _repository.IsNameUniq(role);
    }
}
