using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
  public class CheckoutsController : Controller
  {
    private readonly LibraryContext _db;
    public CheckoutsController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Checkouts.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BookLibraryId = new SelectList(_db.BookLibraries, "BookLibraryId", "Num_Copies");
      ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Checkout checkout, int PatronId, int BookLibraryId)
    {
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // item.User = currentUser;
      _db.Checkouts.Add(checkout);
      if (PatronId != 0)
      {
        _db.Checkouts.Add(new Checkout() { PatronId = PatronId, CheckoutId = checkout.CheckoutId });
      }
      if(BookLibraryId != 0)
      {
        _db.BookLibraries.Add(new BookLibrary(){ BookLibraryId = BookLibraryId, CheckoutId = checkout.CheckoutId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}