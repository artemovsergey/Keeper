using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Services;

public class StatementService : IStatementService
{

    #region Конструктор_StatementService
    private readonly IStatementRepository _statementRepository;
    public StatementService(IStatementRepository statementRepository)
    {
        Console.WriteLine("Создался новый объект сервиса заявок!");
        _statementRepository = statementRepository;
    }
    #endregion


    public void CreateStatement()
    {
        _statementRepository.CreateStatement();
    }

    public Statement GetStatement(int id)
    {
       return _statementRepository.GetStatement(id);
    }

    public IEnumerable<Statement> GetStatements()
    {
       return  _statementRepository.Statements();
    }


}
