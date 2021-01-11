using System.Collections.Generic;

namespace Library.Models
{
  public class Library
  {
    public Library()
    {
      this.BookCopies = new HashSet<BookCopy>();
      this.Checkouts = new HashSet<Checkout>();
    }
  public int LibraryId { get; set;}
  public string LibraryName { get; set; }
  public string Address { get; set; }
  public ICollection<BookCopy> BookCopies { get; set ;}
  public ICollection<Checkout> Checkouts { get; set; }
  
  }

}