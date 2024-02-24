using Keeper.Domen.Data;
using Keeper.Domen.Models;
using Keeper.Web.Models;
using System.Data;

namespace Keeper.Web.Controllers;

public class HomeController : Controller
{

  

    private readonly ILogger<HomeController> _logger;
    private readonly KeeperContext _db;

    public HomeController(ILogger<HomeController> logger, KeeperContext db)
    {
        _logger = logger;
        _db = db;
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
        var statementViewModel = new StatementViewModel(_db);

        Console.WriteLine("������ �������� ������������ � �������������!");
        return View("CreateSelf", statementViewModel);
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

        try
        {
            _logger.LogInformation("������ ������� �������!");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"������ �������� ������: {ex.Message}");
            return RedirectToAction();
        }

    }

}
