using ASM_App_Dev.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace ASM_App_Dev.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var booksToBuy = _context.Books.ToList();
            return View(booksToBuy);
        }

		    [HttpGet]
        public IActionResult Detail(int id)
		    {
        var product = _context.Books.SingleOrDefault(x => x.Id == id);
        return View(product);
		    }
    }
}
