using Keeper.Web.Models;

namespace Keeper.Web.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly KeeperContext _db;
    private readonly StatementViewModel _vm;

    public HomeController(ILogger<HomeController> logger, KeeperContext db, StatementViewModel vm)
    {
        _logger = logger;
        _db = db;
        _vm = vm;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // ����� ������ � ��������� ������

        return View("Index");
    }

    [HttpGet]
    public IActionResult CreateSelf()
    {
        //var statementViewModel = new StatementViewModel(_db);
        return View("CreateSelf", _vm);
    }

    [HttpGet]
    public IActionResult CreateGroup()
    {
        return View("CreateGroup");
    }


    [HttpPost]
    public IActionResult Create([FromForm] Statement statement)
    {
        // ������ �������� ��������� ������ ������ Statement

        // ��������� 

        if (!ModelState.IsValid)
        {
            _logger.LogError("������ �� �������!");
            _vm.Statement = statement;
            return View("CreateSelf", _vm);
        }
      

        try
        {
            // ����� � API � ����� post

            _db.Statements.Add(statement);
            _db.SaveChanges();

            _logger.LogInformation("������ ������� �������!");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError($"������ �������� ������: {ex.Message}");
            return RedirectToAction();
        }

    }

}
