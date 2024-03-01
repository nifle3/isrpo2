using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class QuestThirdController : Controller
{
    private readonly ILogger<QuestThirdController> _logger;
    private readonly BookContext _context;

    public QuestThirdController(ILogger<QuestThirdController> logger, BookContext context) =>
        (_logger, _context) = (logger, context);

    [HttpGet]
    public async Task<ViewResult> Index(string? name, string? author, int? yearOfPublication)
    {
        ViewData["name"] = name;
        ViewData["author"] = author;
        ViewData["yearOfPublication"] = yearOfPublication;
        
        author ??= "";
        author += "%";
        author = "%" + author;
        
        name ??= "";
        name += "%";
        name = "%" + name;

        var books = _context.Books.Where(p =>
            EF.Functions.Like(p.Author, author) && 
            EF.Functions.Like(p.Name, name));

        if (yearOfPublication is not null && yearOfPublication != 0)
            books = books.Where(p => p.YearOfPublication == yearOfPublication);
        

        return View(await books.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create() =>
        View();

    [HttpPost]
    public async Task<RedirectToActionResult> CreateBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index", "QuestThird");
    }

    [HttpGet]
    public async Task<ViewResult> Update(int bookId) => 
        View(await _context.Books.FindAsync(bookId));

    [HttpPost]
    public async Task<RedirectToActionResult> UpdateBook(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index", "QuestThird");
    }

    [HttpGet]
    public async Task<RedirectToActionResult> DeleteBook(int bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        _context.Books.Remove(book ?? new Book());
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index", "QuestThird");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}