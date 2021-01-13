using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.AuthorBooks = new HashSet<AuthorBook>();
      this.BookLibraries = new HashSet<BookLibrary>();
      // this.Authors = new HashSet<Author>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }
    public virtual ApplicationUser User { get; set; }
//     public Author Author { get; set; }
//     public ICollection<Author> Authors { get; }
    public ICollection<AuthorBook> AuthorBooks { get; set; }
    public ICollection<BookLibrary> BookLibraries { get; }
  }
}