using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Models;

public class Division
{
    public long Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Employee>? Employees { get; set; } = null;
}
