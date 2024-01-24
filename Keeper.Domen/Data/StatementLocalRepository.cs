using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data;

// реализация механизма хранения в локальной коллекции

public class StatementLocalRepository : IStatementRepository
{

    #region Конструктор_StatementLocalRepository
    private readonly List<Statement> statements = new List<Statement>();
    public StatementLocalRepository()
    {
        var statement1 = new Statement() { Id = 1 };
        var statement2 = new Statement() { Id = 2 };
        statements.Add(statement1);
        statements.Add(statement2);
    }
    #endregion

    public void CreateStatement()
    {
        var statement3 = new Statement() { Id = 3 };
        statements.Add(statement3);
    }

    // редактирование
    public Statement EditStatement(Statement statement)
    {
        throw new NotImplementedException();
    }

    public Statement GetStatement(int id)
    {
        var statement = statements.Where(s => s.Id == id).FirstOrDefault();
        return statement;
    }


    public IEnumerable<Statement> Statements()
    {
        return statements.ToList();
    }

    public IEnumerable<Statement> StatementsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> StatementsByDivision(string division)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> StatementsByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> StatementsByType(string type)
    {
        throw new NotImplementedException();
    }
}
