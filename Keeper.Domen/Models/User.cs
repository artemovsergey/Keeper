namespace Keeper.Domen.Models;
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public IEnumerable<Statement>? Statements { get; set; } = null;

    public Role? Role { get; set; }
    public int? RoleId { get; set; }

}
