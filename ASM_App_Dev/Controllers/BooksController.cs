using ASM_App_Dev.Data;
using ASM_App_Dev.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace ASM_App_Dev.Controllers
{
    public class BooksController : Controller
    {
        // 1 - Declare ApplicationDbContext
        private ApplicationDbContext _context;
        public  BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 2 - View Book Data
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Books.ToList();
            return View(books);
        }

        //3 - Create Book Data
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var newBook = new Book
            {
                NameBook = book.NameBook,
                QuantityBook = book.QuantityBook,
                Price = book.Price,
                InformationBook = book.InformationBook,
                CreatedAt  = book.CreatedAt
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
