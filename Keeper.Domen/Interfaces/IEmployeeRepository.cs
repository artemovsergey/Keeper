namespace Keeper.Domen.Interfaces;

// описание функциональности механизма хранения

public interface IEmployeeRepository
{
    Employee GetEmployeeByCode(string code);

}
