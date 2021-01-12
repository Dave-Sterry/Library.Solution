using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    public BooksController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.BookId = new SelectList(_db.Authors, "AuthorId", "Name");
      ViewBag.BookId = new SelectList(_db.LibraryBranches, "LibraryBranchId", "LibraryName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Book book, int AuthorId, int LibraryBranchId)
    {
      _db.Books.Add(book);
      if (AuthorId != 0)
      {
        _db.AuthorBooks.Add( new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      if (LibraryBranchId != 0)
      {
        _db.BookLibraries.Add( new BookLibrary() { LibraryBranchId = LibraryBranchId, BookId = book.BookId } );
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
      .Include(book => book.AuthorBooks)
      .ThenInclude(join => join.Author)
      .Include(book => book.BookLibraries)
      .ThenInclude(join => join.LibraryBranch)
      .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      ViewBag.BookId = new SelectList(_db.Authors, "AuthorId", "Name");
      ViewBag.BookId = new SelectList(_db.LibraryBranches, "LibraryBranchId", "LibraryName");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book, int AuthorId, int LibraryBranchId)
    {
      _db.Books.Add(book);
      if (AuthorId != 0)
      {
        _db.AuthorBooks.Add( new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      if (LibraryBranchId != 0)
      {
        _db.BookLibraries.Add( new BookLibrary() { LibraryBranchId = LibraryBranchId, BookId = book.BookId } );
      }
      _db.Entry(book).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //add AddAuthor functionality? 


    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook= _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}