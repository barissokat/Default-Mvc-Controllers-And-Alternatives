using DefaultMvcControllersAndAlternatives.DAL;
using DefaultMvcControllersAndAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultMvcControllersAndAlternatives.Controllers
{
    public class AlternativeBookController : Controller
    {
        BookContext db = new BookContext();
        // GET: AlternativeBook
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult Create()
        {
            var categories = db.Categories.OrderBy(c => c.Name).ToList().Select(c => new SelectListItem
            {
                Selected = false,
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Edit(int id)
        {
            var categories = db.Categories.OrderBy(c => c.Name).ToList().Select(c => new SelectListItem
            {
                Selected = false,
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.Categories = categories;
            Book book = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            Book editedBook = db.Books.Where(b => b.Id == book.Id).FirstOrDefault();
            editedBook.CategoryId = book.CategoryId;
            editedBook.Name = book.Name;
            editedBook.ISBN = book.ISBN;
            editedBook.Author = book.Author;
            editedBook.Publisher = book.Publisher;
            editedBook.PublicationDate = book.PublicationDate;
            editedBook.Price = book.Price;
            editedBook.ReducedPrice = book.ReducedPrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            Book deletedBook = db.Books.Where(b => b.Id == book.Id).FirstOrDefault();
            db.Books.Remove(deletedBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult Details(int id)
        {
            var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }
    }
}