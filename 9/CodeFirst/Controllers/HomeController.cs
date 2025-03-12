using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CodeFirst.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TestMvcContext _context;
    public HomeController(ILogger<HomeController> logger, TestMvcContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult SessionTestCreate()
    {
        
        return View();
    }
    public async Task<IActionResult> SessionTestCreate(User user)
    {   

        HttpContext.Session.SetString("user", $"{user.Name}");
        HttpContext.Session.SetString("userId", $"{user.Id}");
        await _context.Users.AddAsync(user);
        ViewData["CreateSuccess"] = "Success";
        return View();
    }
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
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
