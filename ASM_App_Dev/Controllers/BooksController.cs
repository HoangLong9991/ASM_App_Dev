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
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Books.ToList();
            return View(books);
        }

    }
}
