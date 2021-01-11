using System.Collections.Generic;

namespace Library.Models
{
  public class Library
  {
    public Library()
    {
      this.BookLibraries = new HashSet<BookLibrary>();
    }
  public int LibraryId { get; set;}
  public string LibraryName { get; set; }
  public string Address { get; set; }
  public ICollection<BookLibrary> BookLibraries { get; }
  
  }

}