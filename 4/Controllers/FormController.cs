
using Microsoft.AspNetCore.Mvc;

namespace Core_1.Controllers;

class FormController:Controller{
    public IActionResult Index(){
        return View();
    }
}