using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.BookLibraries = new HashSet<BookLibrary>();
      this.AuthorBooks = new HashSet<AuthorBook>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }
    public ICollection<AuthorBook> AuthorBooks { get; }
    public ICollection<BookLibrary> BookLibraries { get; }
  }
}