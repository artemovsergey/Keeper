namespace Keeper.Domen.Interfaces;

public interface IBanListRepository
{
    void Add(User user);
    void Delete(User user);
}
