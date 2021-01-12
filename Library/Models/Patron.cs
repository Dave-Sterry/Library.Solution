using System.Collections.Generic;

namespace Library.Models
{
  public class Patron
  {

    public Patron()
    {
      //this.Checkouts = new HashSet<Checkout>();
    }
    public int PatronId { get; set; }
    private string _name;
    public string Name
    {
      get { return FirstName + " " + MidIn + " " + LastName; }
      set { _name = value; }
    }
    public string FirstName { get; set; }
    public string MidIn { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public Checkout Checkout { get; set; }
    //public ICollection<Checkout> Checkouts { get; set; }
  }
}