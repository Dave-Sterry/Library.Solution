using System.Collections.Generic;

namespace Library.Models
{
  public class BookLibrary
  {
    public BookLibrary()
    {
      this.Books = new HashSet<Book>();
      this.Checkouts = new HashSet<Checkout>();
      this.Libraries = new HashSet<Library>();
    }
    public int BookLibraryId { get; set; }
    public int BookId { get; set; }
    public int LibraryId { get; set; }
    public int Num_Copies { get; set; }
    public ICollection<Book> Books { get; }
    public ICollection<Checkout> Checkouts { get; }
    public ICollection<Library> Libraries { get;}
  }
}