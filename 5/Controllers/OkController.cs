using Microsoft.AspNetCore.Mvc;
using Core_1.Models;

namespace Core_1.Controllers;

public class OkController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Hello";
        return View("~/Views/Ok/Ok.cshtml");
    }

    [Route("text")]
    [Route("Ok/Text")]
    [Route("Ok/OkText")]
    public IActionResult OkText()
    {
        var ok = new OkText()
        {
            Id = 1,
            Title = "ok text 1",
            Text = "Nai kisu e nai"
        };


        return View("~/Views/Ok/Text.cshtml", ok);
    }
    [Route("Chat")]
    [Route("OkChat")]
    [Route("Ok/Chat")]
    [Route("Ok/OkChat")]

    public IActionResult OkChat()
    {
        var ok = new List<OkText>()
        {
            new OkText {Id = 1, Title = "ok text 1",
                    Text = "Nai kisu e nai"},
            new OkText {Id = 2, Title = "ok text 2",
                    Text = "Nai kisu e nai"},
            new OkText {Id = 3, Title = "ok text 3",
                    Text = "Nai kisu e nai"}
        };


        return View("~/Views/Ok/Chat.cshtml", ok);
    }

    [Route("work/{id?}")]
    public string? work(int? id)
    {
        return id != null ? Convert.ToString(id) : "null";
    }
}