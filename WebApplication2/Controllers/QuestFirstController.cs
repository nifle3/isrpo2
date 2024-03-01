using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Array = WebApplication2.Models.Array;

namespace WebApplication2.Controllers;

public class QuestFirstController : Controller
{
    private readonly ILogger<QuestFirstController> _logger;

    public QuestFirstController(ILogger<QuestFirstController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var array = new Array();
        array.GenerateArray();
        array.CalculateAverageValue();
        
        return View(array);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}