using System.Collections.Generic;

namespace Library.Models
{
  public class BookLibrary
  {
    public BookLibrary()
    {
      // this.Books = new HashSet<Book>();
      //this.Checkouts = new HashSet<Checkout>();
      // this.LibraryBranches = new HashSet<LibraryBranch>();
    }
    public int BookLibraryId { get; set; }
    public int BookId { get; set; }
    public int CheckoutId { get; set; } //might need to be removed later
    public int LibraryBranchId { get; set; }
    public int Num_Copies { get; set; }
    public Book Book { get; set; }
    public Checkout Checkout { get; set; }

    public LibraryBranch LibraryBranch { get; set; }
    //public ICollection<Book> Books { get; }
    // public ICollection<Checkout> Checkouts { get; }
    //public ICollection<LibraryBranch> LibraryBranches { get;}
  }
}