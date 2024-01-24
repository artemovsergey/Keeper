using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// реализация механизма хранения в локальной коллекции

namespace Keeper.Domen.Data;


public class EmployLocalRepository : IEmployeeRepository
{

    public Employee GetEmployeeByCode(string code)
    {
        throw new NotImplementedException();
    }
}
