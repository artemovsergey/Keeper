using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

public interface IStatementService
{

    // создать заявку
    void CreateStatement();

    // получить заявку
    Statement GetStatement(int id);

    // получить все заявки
    IEnumerable<Statement> GetStatements();

}
