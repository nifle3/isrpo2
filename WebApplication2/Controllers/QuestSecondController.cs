using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class QuestSecondController : Controller
{
    private readonly ILogger<QuestSecondController> _logger;

    public QuestSecondController(ILogger<QuestSecondController> logger) =>
        _logger = logger;

    [HttpGet]
    public IActionResult Index() =>
        View();

    [HttpGet]
    public IActionResult Count(string text)
    {
        ViewBag.Text = text;
        ViewBag.Result = text.Count(p => p is '+' or '-');
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}