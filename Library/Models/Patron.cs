using System.Collections.Generic;

namespace Library.Models
{
  public class Patron
  {
    public int LibCardId { get; set; }
    public string FirstName { get; set; }
    public string MidIn { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
  }
}