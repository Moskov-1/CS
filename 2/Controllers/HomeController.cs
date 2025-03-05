using Microsoft.AspNetCore.Mvc;

namespace Second.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
