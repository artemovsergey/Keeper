using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// функции сервиса по работе с заявками

public interface IStatementService
{

    void SignStatement();

    Statement EditStatement(Statement statement);

    Statement GetStatement(int id);

    IEnumerable<Statement> GetStatements();
    IEnumerable<Statement> GetStatementsByType(string type);
    IEnumerable<Statement> GetStatementsByDivision(string division);
    IEnumerable<Statement> GetStatementsByStatus(string status);
    IEnumerable<Statement> GetStatementsByDate(DateTime date);
}
