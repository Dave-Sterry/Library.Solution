using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library.Models
{
  public class LibraryContext : DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<BookLibrary> BookLibraries { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Patron> Patrons { get; set; }
    public LibraryContext(DbContextOptions options) : base(options) { } 
  }
}