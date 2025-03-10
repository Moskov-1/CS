using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet]
    public async Task<IActionResult> Form()
    {

        var users = await _context.Users.ToListAsync();        // ASYNC FETCH
        return View(users);
    }

    // No Data => No Need for ASYNC.
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user, string ConfirmPass)
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
        await _context.SaveChangesAsync();          // ASYNC SAVE
        return RedirectToAction("Form");
    }
    public async Task<IActionResult> Details(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);       // FETCH ASYNC
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);       // FETCH ASYNC
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(User user)            // 2 ASYNCS'
    {
        if (!ModelState.IsValid)
        {
            return View(user); 
        }
        var dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);        // FETCH ASYNC
        if (dbUser == null)
        {
            return NotFound();
        }
        dbUser.Name = user.Name; 
        dbUser.Age = user.Age;

        await _context.SaveChangesAsync();              // SAVE ASYNC
        return RedirectToAction("Form");
    }
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);               // FETCH ASYNC
        if(user == null)
        {
            return NotFound();
        }
        return RedirectToAction("Form");
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> YesDelete(int id)                          // 2 ASYNC
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);                // FETCH ASYNC
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();                  // SAVE ASYNC
        return View(user);
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
