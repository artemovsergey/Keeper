namespace Keeper.Web.Controllers;

public class UserController : Controller
{
    private readonly ILogger<User> _logger;
    public UserController(ILogger<User> logger)
    {
       _logger = logger;
    }

    [HttpGet]
    public IActionResult Sign()
    {
        @ViewData["Title"] = "Регистрация";
        return View();
    }

    [HttpPost]
    public IActionResult SignPost()
    {
        try
        {

            return RedirectToAction("Auth", "User");
        }
        catch (Exception)
        {

            //throw;
            return View("Sign");
        }

    }


    [HttpGet]
    public IActionResult Auth()
    {
        @ViewData["Title"] = "Авторизация";
        return View();
    }

    [HttpPost]
    public IActionResult AuthPost()
    {

        try
        {

            return RedirectToAction("Index", "Home");

        }
        catch (Exception)
        {

            //throw;
            return View("Auth");
        }
     
    }

}
