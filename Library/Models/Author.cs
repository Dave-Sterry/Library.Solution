using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.Books = new HashSet<Book>();
      this.AuthorBooks = new HashSet<AuthorBook>();
    }
    public int AuthorId { get; set; }
    private string _name;
    
    public string Name 
    {
      get { return FirstName + " " + MidIn + " " + LastName; }
      set { _name = value; } 
    }
    public  string FirstName { get; set; }
    public  string MidIn { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; }
    public ICollection<AuthorBook> AuthorBooks { get; }

  }

}