using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_6.Data;
using Web_6.Models;

namespace Web_6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("Works")]
    [HttpGet("Home/Works")]

    public string Works()
    {
        return "works";
    }
    [HttpGet]
    public IActionResult Form()
    {

        var users = _context.Users.ToList();
        return View(users);
    }
    [HttpPost]
    public IActionResult Form(User obj)
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
