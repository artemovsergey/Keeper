using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Interfaces;

// механизм хранения заявок, т.е. что может делать репозиторий с заявками

public interface IStatementRepository
{

    // создать заявку
    void CreateStatement();

    // получить заявку
    Statement GetStatement(int id);

    // получить все заявки
    IEnumerable<Statement> Statements();

    // фильтрация по типу
    IEnumerable<Statement> StatementsByType(string type);

    // фильтрация по подразделению
    IEnumerable<Statement> StatementsByDivision(string division);

    // фильтрация по статусу
    IEnumerable<Statement> StatementsByStatus(string status);

    // фильтрация по дате
    IEnumerable<Statement> StatementsByDate(DateTime date);


    // редактирование заявки
    Statement EditStatement(Statement statement);


}
