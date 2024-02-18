namespace Keeper.Domen.Services;

// реализация функций cервиса по работе с бан листом
// сервис предоставляет данные для сериализации контроллеру API
// данные он может просить у механизма хранения

public class BanListService : IBanListService
{

    private readonly IBanListRepository _banListRepository;
    public BanListService(IBanListRepository banListRepository)
    {
        _banListRepository = banListRepository;
    }

    public void AddToBanList(User user)
    {

        // причина поле до 5000 символов

        throw new NotImplementedException();
    }

    public void DeleteFromBanList(User user)
    {
        throw new NotImplementedException();
    }
}
