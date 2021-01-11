using System.Collections.Generic;

namespace Library.Models
{
  public class BookAuthor
  {
    public BookAuthor()
    {
      this.Books = new HashSet<Book>();
      this.BookCopies = new HashSet<BookCopy>();
    }

    public int AuthorId { get; set; }
    public string Name { get; set; }
    public int BookId { get; set; }
    public string FirstName { get; set; }
    public string MidIn { get; set; }
    public string LastName { get; set; }

    public ICollection<Book> Books { get; set; }
    public ICollection<BookCopy> BookCopies { get; set; }
  }
}