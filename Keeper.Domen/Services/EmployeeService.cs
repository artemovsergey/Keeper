using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Services;

// EmployeeService предоставляет данные для контроллера API которые будут сериализовываться

public class EmployeeService : IEmployeeService
{

    #region Конструктор_EmployeeService
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    #endregion

    public Employee Auth(string code)
    {
        throw new NotImplementedException();
    }

    public bool Open()
    {

        // системный звук

        // запись в базу данных в таблицу Visits

        throw new NotImplementedException();
    }


    public virtual Statement SearchStatementByQr()
    {
        throw new NotImplementedException();
    }
}
