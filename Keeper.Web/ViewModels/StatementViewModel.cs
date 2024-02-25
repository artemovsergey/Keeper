using Keeper.Domen.Data;
using Keeper.Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Web.Models;

public class StatementViewModel
{
    

    public Statement Statement { get; set; }

    public Division SelectedDivision { get; set; }

    public IEnumerable<Division> Divisions { get; set; }

    public IEnumerable<Employee> Employees { get; set; }

    private readonly KeeperContext _db;
    public StatementViewModel(KeeperContext db)
    {
        _db = db;
        Divisions = _db.Divisions.Include(d => d.Employees).ToList();
        Console.WriteLine("Данные из модели загружены!");
    }

}
