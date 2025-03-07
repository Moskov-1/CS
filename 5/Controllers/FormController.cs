using Core_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_1.Controllers
{
    public class FormController : Controller
    {
        // GET: /Form or /Form/Index
        [HttpGet]

        public IActionResult Index()
        {
            var person = new Person()
            {
                FavLang = null
            };
            return View("~/Views/Form/Index.cshtml", person);
        }

        // POST: /Form/Index
        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                return Content($"Name: {person.Name}, Age: {person.Age}, Fav: {person.FavLang}, Gender: {person.Gender}");
            }

            // Return the view with the model if validation fails
            return View("~/Views/Form/Index.cshtml", person);
        }

        // GET: /Form/Test
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Content("Test Form");
        }
    }
}
