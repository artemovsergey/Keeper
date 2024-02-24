namespace Keeper.Domen.Models;

public class Employee
{

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Code { get; set; }

   
    public int DivisionId { get; set; }
    public  Division? Division { get; set; } = null;


    public int DepartamentId { get; set; }
    public Departament? Departament { get; set; } = null;


    public IEnumerable<Statement>? Statements { get; set; } = null;
}
