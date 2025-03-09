using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_6.Data;
using Web_6.Models;

namespace Web_6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly Encrypter crpyt = new Encrypter(3);
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
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(User user, string ConfirmPass)
    {
        if (user.Pass != ConfirmPass)
        {
            ModelState.AddModelError("ConfirmPass", "Pass and Confirm must be same");
        }
        if (!ModelState.IsValid)
        {
            
            return View(user);
        }
        user.Pass = crpyt.Encrpyt(user.Pass);
        _context.Users.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Form");
    }
    public IActionResult Details(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user); 
        }
        var dbUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (dbUser == null)
        {
            return NotFound();
        }
        dbUser.Name = user.Name; 
        dbUser.Age = user.Age;

        _context.SaveChanges();
        return RedirectToAction("Form");
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
