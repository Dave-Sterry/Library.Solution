using System.Collections.Generic;

namespace Library.Models
{

  public class Checkout
  {
    public int CheckoutId { get; get;}
    public int BookId { get; set; }
    public int LibCardId { get; set; }
    public int LibraryId { get; set; }
    
    [DisplayName("Checkout Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime CheckoutDate { get; set; }

    [DisplayName("Due Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime DueDate { get; set; }

    [DisplayName("Return Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
    public DateTime ReturnDate { get; set; }
  }

}