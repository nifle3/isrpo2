using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public sealed class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options) =>
        Database.EnsureCreated();

    public DbSet<Book> Books { set; get; }
}