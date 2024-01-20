using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Models;

public partial class Statement
{

    public int Id { get; set; }
    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Patronimic { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Company { get; set; }
    public string? Note { get; set; }
    public string Passportserial { get; set; } = null!;
    public string Passportnumber { get; set; } = null!;
    public string? Photo { get; set; }
    public DateTime Birthday { get; set; }
    public byte[]? Attachfile { get; set; }
    public string Subdivision { get; set; } = null!;
    public string Employ { get; set; } = null!;
    public DateTime Begindate { get; set; }
    public DateTime Enddate { get; set; }
    public string Target { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Group { get; set; } = null!;

    public User? User { get; set; }
}
