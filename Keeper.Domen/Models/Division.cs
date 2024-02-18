
namespace Keeper.Domen.Models;

public class Division
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Employee>? Employees { get; set; } = null;
}
