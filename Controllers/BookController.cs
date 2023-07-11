using Book_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management_System.Controllers
{
    public class BookController : Controller
    {
        
        public ActionResult Index()
        {
            List<BookCRUD> list = BookCRUD.GetAllBookList();
            return View(list);
        }

        // GET: BookController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCRUD b)
        {
            BookCRUD.AddBook(b);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController1/Edit/5
        public ActionResult Edit(int id)
        {
            BookCRUD b = BookCRUD.GetBookById(id);
            return View(b);
        }

        // POST: BookController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookCRUD b)
        {
            try
            {
                BookCRUD.UpdateBook(b);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController1/Delete/5
        public ActionResult Delete(int id)
        {
            BookCRUD b = BookCRUD.GetBookById(id);
            return View(b);
        }

        // POST: BookController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookCRUD b)
        {
            try
            {
                BookCRUD.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
