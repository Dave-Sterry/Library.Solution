using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{

  public class Checkout
  {
    public Checkout()
    {
      //this.Patrons = new HashSet<Patron>();
      this.BookLibraries = new HashSet<BookLibrary>();
    }
    public int CheckoutId { get; set; }
    public int BookLibraryId { get; set; }
    public int PatronId { get; set; }
    
    [DisplayName("Checkout Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime CheckoutDate { get; set; }

    [DisplayName("Due Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime DueDate { get; set; }

    [DisplayName("Return Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime ReturnDate { get; }

    public ICollection<BookLibrary> BookLibraries { get; }

    // public ICollection<Patron> Patrons { get; }
  }

}