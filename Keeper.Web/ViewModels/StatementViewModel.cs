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

    public StatementViewModel(KeeperContext db)
    {
        Divisions = db.Divisions.Include(d => d.Employees).ToList();
        Console.WriteLine("Данные из модели загружены!");
    }

}
