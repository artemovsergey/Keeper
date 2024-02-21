namespace Keeper.Domen.Data;

public class KeeperContext : DbContext
{
    public KeeperContext(DbContextOptions<KeeperContext> options) : base(options) 
    {

    }

    public KeeperContext()
    {
            
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Statement> Statements { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Departament> Departaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KeeperTestDatabase;Trusted_Connection=True;");
    }

}
