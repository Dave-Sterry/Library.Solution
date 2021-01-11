using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.AuthorBooks = new HashSet<AuthorBook>();
    }
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string MidIn { get; set; }
    public string LastName { get; set; }
    public ICollection<AuthorBook> AuthorBooks { get; }
  }

}