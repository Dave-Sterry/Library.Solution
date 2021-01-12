using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
  public class LibraryBranchesController : Controller
  {

    private readonly LibraryContext _db;
    
    public LibraryBranchesController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.LibraryBranches.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(LibraryBranch libraryBranch, int BookId)
    {
      _db.LibraryBranches.Add(libraryBranch);
      if (BookId != 0)
      {
        _db.BookLibraries.Add(new BookLibrary() { BookId = BookId, LibraryBranchId = libraryBranch.LibraryBranchId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisLibraryBranch = _db.LibraryBranches
        .Include(libraryBranch => libraryBranch.BookLibraries)
        .ThenInclude(join => join.Book)
        .FirstOrDefault(libraryBranch => libraryBranch.LibraryBranchId == id);
      return View(thisLibraryBranch);
    }
    public ActionResult Edit(int id)
    {
      var thisLibraryBranch = _db.LibraryBranches.FirstOrDefault(libraryBranch => libraryBranch.LibraryBranchId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisLibraryBranch);
    }
    [HttpPost]
    public ActionResult Edit(LibraryBranch libraryBranch, int BookId)
    {
      if (BookId != 0)
      {
        _db.BookLibraries.Add(new BookLibrary() { BookId = BookId, LibraryBranchId = libraryBranch.LibraryBranchId });
      }
      _db.Entry(libraryBranch).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisLibraryBranch = _db.LibraryBranches.FirstOrDefault(libraryBranch => libraryBranch.LibraryBranchId == id);
      return View(thisLibraryBranch);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLibraryBranch = _db.LibraryBranches.FirstOrDefault(libraryBranch => libraryBranch.LibraryBranchId == id);
      _db.LibraryBranches.Remove(thisLibraryBranch);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}