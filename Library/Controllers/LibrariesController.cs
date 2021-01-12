// using Microsoft.AspNetCore.Mvc;
// using Library.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;

// namespace Library.Controllers
// {
//   public class LibraryBranchesController : Controller
//   {

//     private readonly LibraryContext _db;
    
//     public LibraryBranchesController(LibraryContext db)
//     {
//       _db = db;
//     }

//     public ActionResult Index()
//     {
//       return View(_db.LibraryBranches.ToList());
//     }

//     public ActionResult Create()
//     {
//       ViewBag.BookId = new SelectList(_db.Books, "BookId", "BookName");
//       return View();
//     }
//     [HttpPost]
//     public ActionResult Create(LibraryBranch libraryBranch, int BookId)
//     {
//       _db.LibraryBranches.Add(libraryBranch);
//       if (BookId != 0)
//       {
//         _db.BookLibraries.Add(new BookLibrary() { BookId = BookId, LibraryId = libraryBranch.LibraryId });
//       }
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
//   }
// }