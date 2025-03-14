using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.Scripting;

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
        //Console.WriteLine("IN");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SessionTestCreate(User user, string ConfirmPass)
    {
        if (user.Pass != ConfirmPass)
        {
            ModelState.AddModelError("ConfirmPass", "Password needs to be the same");
        }

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Requests were stuck in back log !");
            return View();
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync(); 

        ViewData["CreateSuccess"] = "Success";

        return View();
    }
    public IActionResult Login()
    {
        if (HttpContext.Session.GetString("userId") == null)
        {
            return View();
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Name == user.Name && x.Pass == user.Pass);
        if(user == null)
        {
            ModelState.AddModelError("Invalid_Login","Invalid Login Attempt");
            return View();
        }
        HttpContext.Session.SetString("userName", $"{dbUser.Name}");
        HttpContext.Session.SetString("userId", $"{dbUser.Id}");

        return RedirectToAction("Index");

    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
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
