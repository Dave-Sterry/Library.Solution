using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.BookCopies = new HashSet<BookCopy>();
      this.BookAuthors = new HashSet<BookAuthor>();
      this.Checkouts = new HashSet<Checkout>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }

    public ICollection<BookCopy> BookCopies { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<Checkout> Checkouts { get; set; }
  }
}