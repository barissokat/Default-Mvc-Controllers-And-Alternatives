using DefaultMvcControllersAndAlternatives.DAL;
using DefaultMvcControllersAndAlternatives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultMvcControllersAndAlternatives.Controllers
{
    public class AlternativeCategoryController : Controller
    {
        BookContext db = new BookContext();
        // GET: AlternativeCategory
        public ActionResult Index()
        {
            return View(db.Categories);
        }
        public ActionResult Show(int id)
        {
            string categoryName = (from c in db.Categories where c.Id == id select c.Name).FirstOrDefault();
            ViewBag.Title = categoryName + " Books";
            ViewBag.Id = id;
            var books = (from b in db.Books where b.CategoryId == id select b).ToList();
            return View(books.OrderBy(x => x.Name).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult CreateBook(int id)
        {
            string categoryName = (from c in db.Categories where c.Id == id select c.Name).FirstOrDefault();
            ViewBag.CategoryName = categoryName;
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book, int id)
        {
            book.CategoryId = id;
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Show", new { id = book.CategoryId });
        }
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category editedCategory = db.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
            editedCategory.Name = category.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            Category deletedCategory = db.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
            db.Categories.Remove(deletedCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return View(category);
        }
    }
}