using Keeper.Domen.Models;
using System.Data;

namespace Keeper.Web.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // выбор личной и групповой заявок

        return View("Index");
    }

    [HttpGet]
    public IActionResult CreateSelf()
    {

        return View("CreateSelf");
    }

    [HttpGet]
    public IActionResult CreateGroup()
    {
        return View("CreateGroup");
    }


    [HttpPost]
    public IActionResult Create(Statement statement)
    {
        // модель привязки формирует объект заявки Statement

        // валидация 

        try
        {
            _logger.LogInformation("Заявка успешно создана!");
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Ошибка создания заявки: {ex.Message}");
            return RedirectToAction();
        }

    }

}
