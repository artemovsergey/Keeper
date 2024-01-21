using Keeper.Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data
{
    public class KeeperContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Statement> Statements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KeeperTestDatabase;Trusted_Connection=True;");
        }

    }
}
