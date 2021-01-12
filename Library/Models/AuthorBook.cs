using System.Collections.Generic;

namespace Library.Models
{
  public class AuthorBook
  {
    public AuthorBook()
    {
      this.Books = new HashSet<Book>();
      this.Authors = new HashSet<Author>();
    }
    public int AuthorBookId { get; set; }
    public int AuthorId { get; set; }
    public int BookId { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }

    public ICollection<Book> Books { get; }
    public ICollection<Author> Authors { get; }
  }
}