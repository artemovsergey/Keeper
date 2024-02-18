﻿namespace Keeper.Domen.Models;

public class Employee
{

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Code { get; set; }

   
    public int DivisionId { get; set; }
    public virtual Division? Division { get; set; }

    
    public int DepartamentId { get; set; }
    
    [NotMapped]
    public virtual Departament? Departament { get; set; }


    public IEnumerable<Statement>? Statements { get; set; } = null;
}
