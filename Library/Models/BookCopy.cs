using System.Collections.Generic;

namespace Library.Models
{
  public class BookCopy
  {
    public BookCopy()
    {
      this.Books = new HashSet<Book>();
      this.BookAuthors = new HashSet<BookAuthor>();
      this.Checkouts = new HashSet<Checkout>();
      this.Libraries = new HashSet<Library>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }
    public int LibraryId { get; set; }
    public int Num_Copies { get; set; }
    public ICollection<Book> Books { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<Checkout> Checkouts { get; set; }
    public ICollection<Library> Libraries { get; set; }
  }
}