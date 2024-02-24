using System.ComponentModel.DataAnnotations;

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

    [Required]
    public DateTime? Begindate { get; set; } = null!;

    [Required]
    public DateTime Enddate { get; set; }

    public string Target { get; set; } = null!;
    public string Status { get; set; } = null!;

    // может быть личная и коллективная заявки
    public string? Group { get; set; } = null!;

    // может быть гость
    public int? UserId { get; set; }
    public User? User { get; set; }

    // сотрудник зависит от подразделения
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

}
