using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// описание функциональности механизма хранения

public interface IEmployeeRepository
{
    Employee GetEmployeeByCode(string code);

}
