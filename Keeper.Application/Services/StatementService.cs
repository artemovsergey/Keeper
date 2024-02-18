namespace Keeper.Domen.Services;

// сервис по работе с заявками, предосталяет данные для контроллера API
public class StatementService : IStatementService
{

    private readonly IStatementRepository _statementRepository;
    public StatementService(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    // регистрация заявки
    public void SignStatement()
    {

        // Валидации на строне сервера

        _statementRepository.CreateStatement();
    }

    // редактирование заявки
    public Statement EditStatement(Statement statement)
    {
        // провека пользователя методом CheckUser()

        // true, статус Отклонена, сообщение, режим только для чтения
        // false, установка даты и времени посещения, статус Одобрена, сообщение

        throw new NotImplementedException();
    }

    // получить заявку
    public Statement GetStatement(int id)
    {
       return _statementRepository.GetStatement(id);
    }

    // получить все заявки
    public IEnumerable<Statement> GetStatements()
    {
       return  _statementRepository.Statements();
    }

    public IEnumerable<Statement> GetStatementsByType(string type)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> GetStatementsByDivision(string division)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> GetStatementsByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Statement> GetStatementsByDate(DateTime date)
    {
        throw new NotImplementedException();
    }

}
