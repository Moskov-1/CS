using Microsoft.AspNetCore.Mvc;

namespace Core_1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}