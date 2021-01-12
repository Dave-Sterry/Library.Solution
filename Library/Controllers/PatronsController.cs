using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
  public class PatronsController: Controller
  { 

    private readonly LibraryContext _db;

    public PatronsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patrons.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CheckoutId = new SelectList(_db.Checkouts, "CheckoutId", "CheckoutDate");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patron patron, int CheckoutId)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // item.User = currentUser;
      _db.Patrons.Add(patron);
      if (CheckoutId != 0)
      {
        _db.Checkouts.Add(new Checkout() { CheckoutId = CheckoutId, PatronId = patron.PatronId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPatron = _db.Patrons
          //.Include(patron => patron.Checkouts)
          // .ThenInclude(join => join.Checkout)
          // NOTES!!!!this doesn't want to be join.Checkout, but we are not sure what it should be yet. Check later?
          .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    public ActionResult Edit(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      ViewBag.CheckoutId = new SelectList(_db.Books, "CheckoutId", "Title"); // ViewBag only transfers data from controller to view
      return View(thisPatron);
    }
    
    [HttpPost]
    public ActionResult Edit(Patron patron, int CheckoutId)
    {
      if (CheckoutId != 0)
      {
        _db.Checkouts.Add(new Checkout() { CheckoutId = CheckoutId, PatronId = patron.PatronId });
      }
      _db.Entry(patron).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddBook(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      ViewBag.CheckoutId = new SelectList(_db.Books, "CheckoutId", "Title");
      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult AddBook(Patron patron, int CheckoutId)
    {
      if (CheckoutId != 0)
      // Check if CourseId is valid
      {
        var returnedJoin = _db.Checkouts.Any(join => join.PatronId == patron.PatronId && join.CheckoutId == CheckoutId);
        // Check if "Any" of this relationship exists, returns a bool
        if (!returnedJoin) 
        {
        // if the returnedJoin for that relationship if false, then add the relationship
          _db.Checkouts.Add(new Checkout() { CheckoutId =CheckoutId, PatronId = patron.PatronId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }   

    public ActionResult Delete(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
      _db.Patrons.Remove(thisPatron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  
    [HttpPost]
    public ActionResult DeleteBook(int joinId)
    {
      var joinEntry = _db.Checkouts.FirstOrDefault(entry => entry.CheckoutId == joinId);
      _db.Checkouts.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }

  
}